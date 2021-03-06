using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {

        
            using (CarRentalContext context=new CarRentalContext())
            {


                var result = from b in context.Brands
                             join c in context.Cars
                             on b.Id equals c.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDto { CarId=c.Id, ColorId=c.ColorId,BrandId=c.BrandId, CarName = c.Description, BrandName = b.Name, ColorName = cl.Name, ModelYear=c.ModelYear, DailyPrice = c.DailyPrice };

             

                return filter == null ? result.ToList() : result.Where(filter).ToList();

                #region old version

                //var result = from b in context.Brands
                //             join c in context.Cars
                //             on b.Id equals c.BrandId
                //             join cl in context.Colors
                //             on c.ColorId equals cl.Id
                //             select new CarDetailDto { CarName = c.Description, BrandName = b.Name, ColorName = cl.Name, DailyPrice = c.DailyPrice };

                //return result.ToList();
                #endregion


            }
        }

        public CarDetailDto GetCarDetail(Expression<Func<CarDetailDto, bool>> filter)
        {


            using (CarRentalContext context = new CarRentalContext())
            {


                var result = from b in context.Brands
                             join c in context.Cars
                             on b.Id equals c.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDto { CarId = c.Id, ColorId = c.ColorId, BrandId = c.BrandId, CarName = c.Description, BrandName = b.Name, ColorName = cl.Name, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice };

                return result.SingleOrDefault(filter);


            }
        }


    }
}
