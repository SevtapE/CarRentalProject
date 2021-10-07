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

            // EFTests();

            //NewBusinessRule();
            // EFAddTest2();

            // DtoTest();

            //CarOperationsTest();

            //BrandOperationsTest();

            //ColorOperationsTest();
        }

        private static void ColorOperationsTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("**Get All**");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ColorId= {0} Color Name= {1}", color.Id, color.Name);
            }
            Console.WriteLine("**Get By Id**");
            Color color2;
            color2 = colorManager.GetById(1);
            Console.WriteLine(color2.Name);

            Console.WriteLine("**Add**");
            colorManager.Add(new Color { Name = "Orange" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ColorId= {0} Color Name= {1}", color.Id, color.Name);
            }


            Console.WriteLine("**Update**");
            colorManager.Update(new Color { Id = 2, Name = "Yellow" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ColorId= {0} Color Name= {1}", color.Id, color.Name);
            }
            Console.WriteLine("**Delete**");
            colorManager.Delete(new Color { Id = 6, Name = "Blue" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ColorId= {0} Color Name= {1}", color.Id, color.Name);
            }
        }

        private static void BrandOperationsTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Console.WriteLine("**Add**");
            //brandManager.Add(new Brand { Name = "Cadillac" });

            Console.WriteLine("**Get All**");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("BrandId= {0} Brand Name= {1}", brand.Id, brand.Name);
            }
            Console.WriteLine("**Get By Id**");
            Brand brand2;
            brand2 = brandManager.GetById(3);
            Console.WriteLine(brand2.Name);

            Console.WriteLine("**Update**");
            brandManager.Update(new Brand { Id = 2, Name = "Mazda" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("BrandId= {0} Brand Name= {1}", brand.Id, brand.Name);
            }

            //Console.WriteLine("**Delete**");
            //brandManager.Delete(new Brand { Id = 4, Name = "Mazda" });
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine("BrandId= {0} Brand Name= {1}", brand.Id, brand.Name);
            //}
        }

        private static void CarOperationsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //Console.WriteLine("**Add**");
            //carManager.Add(new Car { Description = "TCX368", BrandId = 2, ColorId = 1, ModelYear = "2021", DailyPrice = 300 });

            Console.WriteLine("**Get All**");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} - {1} - {2}", car.Id, car.Description, car.DailyPrice);
            }

            Console.WriteLine("**Get Car By Id**");
            ShowCar(carManager.GetById(7));
            Console.WriteLine("**Get Cars By Brand Id**");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("{0} - {1} - {2}", car.Id, car.Description, car.DailyPrice);
            }
            Console.WriteLine("**Get Cars By Color Id**");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("{0} - {1} - {2}", car.Id, car.Description, car.DailyPrice);
            }

            Console.WriteLine("**Update**");

            carManager.Update(new Car { Id = 7, DailyPrice = 500, Description = "AXT7", ColorId = 1, BrandId = 2, ModelYear = "2021" });
            ShowCar(carManager.GetById(7));

            Console.WriteLine("**Delete**");
            carManager.Delete(new Car { Id = 7, DailyPrice = 500, Description = "AXT7", ColorId = 1, BrandId = 2, ModelYear = "2021" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} - {1} - {2}", car.Id, car.Description, car.DailyPrice);
            }
        }

        private static void DtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetail())
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }

        private static void EFAddTest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = "2015", DailyPrice = 6.78m, Description = "hewkekrlwkr" });
        }

        private static void NewBusinessRule()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car {  BrandId = 2, ColorId = 1, ModelYear = "1985", DailyPrice = 2.35M, Description = "h" });
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
            carManager.Add(new Car { BrandId = 1, ColorId = 1, ModelYear = "1985", DailyPrice = 2.35M, Description = "Family Car" });
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
