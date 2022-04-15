using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICarService
    {
      
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetail();
        IDataResult<CarDetailDto> GetCarDetailByCarId(int carId);

        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
      
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

        IResult TransactionalAddTest(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int id);
    }
}
