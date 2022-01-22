﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IRentalService
    {
        IDataResult<List<CarRentDetailDto>> GetCarRentDetail();
        IDataResult<List<CarRentFullDto>> GetCarRentFull();
        IDataResult<List<CarRentDetailDto>> GetCarRentDetailById(int carId);

        IResult IsCarEverRented(int carId);
        IResult IsCarReturned(int carId);
        IResult IsAvailableForRent(int carId);

     

        IDataResult<Rental> GetById(int id);

        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
