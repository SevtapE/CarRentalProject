
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
 

        public List<CarRentDetailDto> GetCarRentDetailByCar(int carId)
        {
            var resultlist = GetRentalDetails();
            return resultlist.Where(c => c.CarId == carId).ToList();
   
        }


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
