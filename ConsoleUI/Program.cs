using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryTests();

            //EFAdd();

            //EFTests();

          
                CarManager carManager = new CarManager(new EfCarDal());
                carManager.Add(new Car { Id = 4, BrandId = 2, ColorId = 1, ModelYear = "1985", DailyPrice = 2.35M, Description = "h" });
            

        }

        private static void EFTests()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> cars = carManager.GetAll();

            foreach (var car in cars)
            {
                ShowCar(car);
            }

            Console.WriteLine("******GetByBrandId*****");
            List<Car> cars2 = carManager.GetCarsByBrandId(2);
            foreach (var car in cars2)
            {
                ShowCar(car);
            }

            Console.WriteLine("******GetByColorId*****");
            List<Car> cars3 = carManager.GetCarsByColorId(1);
            foreach (var car in cars3)
            {
                ShowCar(car);
            }
        }

        private static void ShowCar(Car car)
        {
            Console.WriteLine("Id= {0} Description= {1}", car.Id, car.Description);
        }

        private static void EFAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { Id = 2, BrandId = 1, ColorId = 1, ModelYear = "1985", DailyPrice = 2.35M, Description = "Family Car" });
        }

        private static void InMemoryTests()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine();
            Console.WriteLine("*****Add****");

            carManager.Add(new Car { Id = 7, Description = "rreqrqrr" });

            Console.WriteLine();
            Console.WriteLine("*****Get All****");
            ShowGetAll(carManager);

            //Console.WriteLine();
            //Console.WriteLine("*****Get By Id****");
            //Car car = carManager.GetById(3);
            //Console.WriteLine(car.Description);

            //Console.WriteLine();
            //Console.WriteLine("*****Delete****");
            //carManager.Delete(car);

            Console.WriteLine();
            Console.WriteLine("*****Get All****");
            ShowGetAll(carManager);


            Console.WriteLine();
            Console.WriteLine("*****Update****");
            carManager.Update(new Car { Id = 7, Description = "Performance car" });

            Console.WriteLine();
            Console.WriteLine("*****Get All****");
            ShowGetAll(carManager);
        }

        private static void ShowGetAll(CarManager carManager)
        {
            List<Car> cars = carManager.GetAll();
            foreach (var c in cars)
            {


                Console.Write(c.Id);
                Console.WriteLine(c.Description);

            }
        }
    }
}
