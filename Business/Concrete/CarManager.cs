using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if ((car.Description.Length >= 2) && (car.DailyPrice > 0))
            {
                _carDal.Add(car);
                Console.WriteLine("Added");
            }
            else
            {
                Console.WriteLine("The car could not get added to the cars. Make sure the following conditions are fit.\n *The description must have at least two characters.\n *The daily price must be greater than 0.");
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Deleted");
        }

        public List<Car> GetAll()
        {

            return _carDal.GetAll();
          
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        //public Car GetById(int id)
        //{
        //    return _carDal.GetById(id);
        //}

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Updated");

        }
    }
}
