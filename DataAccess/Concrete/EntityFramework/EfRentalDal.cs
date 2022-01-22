
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public List<CarRentFullDto> GetCarRentFull(Expression<Func<CarRentFullDto, bool>> filter = null)
        {


            using (CarRentalContext context = new CarRentalContext())
            {


                var result =
                    from b in context.Brands
                    join c in context.Cars
                    on b.Id equals c.BrandId
                    join r in context.Rentals
                    on c.Id equals r.CarId
                    join cs in context.Customers
                    on r.CustomerId equals cs.Id
                   join u in context.Users
                   on cs.UserId equals u.Id
                    select new CarRentFullDto { RentalId = r.Id, CarId = c.Id, BrandId = c.BrandId, CustomerId=r.CustomerId, UserId=u.Id, FirstName=u.FirstName,LastName=u.LastName, BrandName = b.Name, CarName = c.Description, RentDate = r.RentDate, ReturnDate = r.ReturnDate };



                return filter == null ? result.ToList() : result.Where(filter).ToList();



            }

        }


    }
}
