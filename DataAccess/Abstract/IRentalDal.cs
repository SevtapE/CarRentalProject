using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IRentalDal:IEntityRepository<Rental>
    {
        List<CarRentDetailDto> GetRentalDetails();
        List<CarRentFullDto> GetCarRentFull(Expression<Func<CarRentFullDto, bool>> filter = null);
        List<CarRentDetailDto> GetCarRentDetailByCar(int carId);
     
    }
}
