using Business.Concrete;
using DataAccess.Abstract;
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
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine();
            Console.WriteLine("*****Add****");
            
            carManager.Add(new Car() { Id = 7, Description = "rreqrqrr" });
           
            Console.WriteLine();
            Console.WriteLine("*****Get All****");
            ShowGetAll(carManager);
           
            Console.WriteLine();
            Console.WriteLine("*****Get By Id****");
            Car car = carManager.GetById(3);
            Console.WriteLine(car.Description);

            Console.WriteLine();
            Console.WriteLine("*****Delete****");
            carManager.Delete(car);

            Console.WriteLine();
            Console.WriteLine("*****Get All****");
            ShowGetAll(carManager);

           
            Console.WriteLine();
            Console.WriteLine("*****Update****");
            carManager.Update(new Car() { Id = 7, Description = "Performance car" });

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
