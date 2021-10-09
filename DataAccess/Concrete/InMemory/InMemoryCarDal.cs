using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        

        public InMemoryCarDal()
        {
            _cars = new List<Car>
        {
            new Car{Id=1,BrandId=1,ColorId=1,ModelYear="2020",DailyPrice=300.5M,Description="Sports car"},
            new Car{Id=2,BrandId=2,ColorId=3,ModelYear="2002",DailyPrice=100,Description="Family car"},
            new Car{Id=3,BrandId=1,ColorId=1,ModelYear="2021",DailyPrice=150,Description="Hatchback car"},
            new Car{Id=4,BrandId=1,ColorId=2,ModelYear="1987",DailyPrice=180,Description="4*4 car"},
            new Car{Id=5,BrandId=3,ColorId=4,ModelYear="1938",DailyPrice=80,Description="Van"},
        };

         
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        //public Car GetById(int id)
        //{
        //    return _cars.SingleOrDefault(c => c.Id == id);
        //}

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c =>c.Id==car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
        }

        List<CarDetailDto> ICarDal.GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
