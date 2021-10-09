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
           
          
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
    
        }

        //public void check(Car car)
        //{

        //}

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



        public IDataResult<List<CarRentDetailDto>> GetCarRentDetail(int carId)
        {
            return new SuccessDataResult<List<CarRentDetailDto>>(_rentalDal.GetCarRentDetailByCar(carId));
        }
        //public void check() {
        //    _rentalDal.CheckCarForRent(_car);
        //}



        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
