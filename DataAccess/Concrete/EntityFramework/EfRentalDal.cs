
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public void CheckCarForRent(Car car)
        {
            throw new NotImplementedException();
        }

        public List<CarRentDetailDto> GetCarRentDetailByCar(int carId)
        {
            var resultlist = GetRentalDetails();
            return resultlist.Where(c => c.CarId == carId).ToList();
   
        }

        //public void CheckCarForRent(Car car)
        //{
        //    var result = GetRentalDetails();
        //    foreach (var item in result)
        //    {
        //        if (item.CarId == car.Id)
        //        {
        //            Console.WriteLine(item.CarId + "/" + item.RentalId + " / " + item.ReturnDate);
        //        }

        //    }
        //}







        public List<CarRentDetailDto> GetRentalDetails()
    {

        using (CarRentalContext context = new CarRentalContext())
        {
            var result = from c in context.Cars
                         join r in context.Rentals
                         on c.Id equals r.CarId into temp
                         from t in temp.DefaultIfEmpty()
                         select new CarRentDetailDto { CarId = c.Id, RentalId = t.Id, ReturnDate = t.ReturnDate };



            return result.ToList();
        }


    }


} 
}
