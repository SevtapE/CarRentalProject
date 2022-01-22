using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
     
     

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
         
         
        }

        public IResult Add(Rental rental)
        {
            var result = IsAvailableForRent(rental.CarId);
           if (result.Success)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                return new ErrorResult(result.Message);
            }
    
        }

   

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<CarRentDetailDto>> GetCarRentDetail()
        {
            return new SuccessDataResult<List<CarRentDetailDto>>(_rentalDal.GetRentalDetails());
        }




        public IDataResult<List<CarRentDetailDto>> GetCarRentDetailById(int carId)
        {
            return new SuccessDataResult<List<CarRentDetailDto>>(_rentalDal.GetCarRentDetailByCar(carId));
        }

        public IDataResult<List<CarRentFullDto>> GetCarRentFull()
        {
            return new SuccessDataResult<List<CarRentFullDto>>(_rentalDal.GetCarRentFull());
        }

        public IResult IsAvailableForRent(int carId)
        {
          if(IsCarEverRented(carId).Success)
            {
                if (IsCarReturned(carId).Success)
                {
                    return new SuccessResult(Messages.RentalAdded);
                }
                return new ErrorResult(Messages.CarNotAvailable);
            }
            return new SuccessResult(Messages.RentalAdded);
        }

       public IResult IsCarEverRented(int carId)
        {
           
            if (_rentalDal.GetAll(r => r.CarId == carId).Any())
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

       public IResult IsCarReturned(int carId)
        {
            if(_rentalDal.GetAll(r => (r.CarId == carId) && (r.ReturnDate == null)).Any())
            {
                return new ErrorResult();
            }
           
            return new SuccessResult();
        }

     



        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
