using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileManipulate;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

 
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileManipulateService _fileManipulateService;
     
        public CarImageManager(ICarImageDal carImageDal, IFileManipulateService fileManipulateService)
        {
            _carImageDal = carImageDal;
            _fileManipulateService = fileManipulateService;
           

        }
   
        public IResult Add(CarImage carImage)
        {
          
          var result=  BusinessRuler.Run(CheckIfCarImageCountExceed(carImage.CarId));
            if(result!=null)
            {
                return result;
            }
           var info= _fileManipulateService.Add(carImage.ImagePath);
         
            carImage.ImagePath = info.FullName;
            carImage.Date = info.CreationTime;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileManipulateService.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
          
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = CheckIfTheCarHasAnyImage(carId);
            if (!result.Success)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>{ new CarImage { ImagePath = @"/Images/CarImages/DefaultImage.jpg" } });
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId==carId));

        }

        public IResult Update(CarImage carImage)
        {
            var oldCarImage = _carImageDal.Get(ci => ci.Id == carImage.Id);
           
           var info=_fileManipulateService.Update(oldCarImage.ImagePath,carImage.ImagePath);
            carImage.ImagePath = info.FullName;
            carImage.Date = info.CreationTime;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }




        private IResult CheckIfCarImageCountExceed(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageCountExceeded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfTheCarHasAnyImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        //private IResult CheckIfCarImageFileProcessed(int carId)
        //{
        //    var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
        //    if (result >= 5)
        //    {
        //        return new ErrorResult(Messages.CarImageCountExceeded);
        //    }
        //    return new SuccessResult();
       // }
    }
}
