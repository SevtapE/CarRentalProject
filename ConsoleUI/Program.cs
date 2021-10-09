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
            // ResultTest();

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //Color color = new Color { Name = "Blue" };
            //colorManager.Add(color);
            //var result= colorManager.GetAll().Data;
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Id+"/"+item.Name);
            //}

            //RentalUpdateTest();
            // RentalAddTest();

            //RentalDeleteTest();
            // CarRentDetailTest();

            //CarRentDetailByCarTest();

            // UserTest();

            //UserUpdateTest();
            //UserDeleteTest();

            // CustomerAddTest();

    
            // UserAddTest();
            // Console.WriteLine(customerManager.Add(customer).Message);

            //rentalManager.check();
        }

        private static void UserAddTest()
        {
            User user = new User { FirstName = "Bob", LastName = "Robinson", Email = "bobrobyy@sng.ss", Password = "ehs4442l" };
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(user);
        }


        private static void CustomerAddTest()
        {
            Customer customer = new Customer { FirstName = "Lesly", LastName = "Robinson", Email = "resy@sng.ss", Password = "ehsffl", CompanyName = "Verifyings" };
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(customer);
        }

        private static void UserDeleteTest()
        {
            User user = new User { UserId = 1002, FirstName = "Cessy", LastName = "Rob", Email = "cessy@sng.ss", Password = "ehskal" };
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Delete(user);
        }

        private static void UserUpdateTest()
        {
            User user = new User { UserId = 1002, FirstName = "Cessy", LastName = "Rob", Email = "cessy@sng.ss", Password = "ehskal" };
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Update(user);
        }

        private static void UserTest()
        {
            User user = new User { FirstName = "Cessy", LastName = "Rob", Email = "cessy@jds.ss", Password = "ehskal" };
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(user);

        }

        private static void CarRentDetailByCarTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            var resultlist = rentalManager.GetCarRentDetail(1005).Data;
            foreach (var item in resultlist)
            {
                Console.WriteLine(item.CarId + "/" + item.RentalId + "/" + item.ReturnDate);

            }
        }

        private static void CarRentDetailTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetCarRentDetail();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CarId + "/" + item.ReturnDate);
            }
        }

        private static void RentalDeleteTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental { Id = 8, CarId = 1005, CustomerId = 3, RentDate = new DateTime(2021, 10, 6), ReturnDate = new DateTime(2021, 10, 8) };

            Console.WriteLine(rentalManager.Delete(rental).Message);
        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental { CarId = 1005, CustomerId = 3, RentDate = new DateTime(2021, 10, 6) };
            rentalManager.Add(rental);
        }

        private static void RentalUpdateTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental { Id = 8, CarId = 1005, CustomerId = 3, RentDate = new DateTime(2021, 10, 6), ReturnDate = new DateTime(2021, 10, 8) };

            Console.WriteLine(rentalManager.Update(rental).Message);
        }

        private static void ResultTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("**Get All**");
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine("ColorId= {0} Color Name= {1}", color.Id, color.Name);
            }
            Console.WriteLine(result.Message);
        }

        private static void ColorOperationsTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("**Get All**");
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine("ColorId= {0} Color Name= {1}", color.Id, color.Name);
            }
            Console.WriteLine(result.Message);
            Console.WriteLine("**Get By Id**");
            Color color2;
            color2 = colorManager.GetById(1).Data;
            Console.WriteLine(color2.Name);

            Console.WriteLine("**Add**");
            colorManager.Add(new Color { Name = "Orange" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("ColorId= {0} Color Name= {1}", color.Id, color.Name);
            }


            Console.WriteLine("**Update**");
            colorManager.Update(new Color { Id = 2, Name = "Yellow" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("ColorId= {0} Color Name= {1}", color.Id, color.Name);
            }
            Console.WriteLine("**Delete**");
            colorManager.Delete(new Color { Id = 6, Name = "Blue" });
            foreach (var color in colorManager.GetAll().Data)
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
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("BrandId= {0} Brand Name= {1}", brand.Id, brand.Name);
            }
            Console.WriteLine("**Get By Id**");
            Brand brand2;
            brand2 = brandManager.GetById(3).Data;
            Console.WriteLine(brand2.Name);

            Console.WriteLine("**Update**");
            brandManager.Update(new Brand { Id = 2, Name = "Mazda" });
            foreach (var brand in brandManager.GetAll().Data)
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
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1} - {2}", car.Id, car.Description, car.DailyPrice);
            }

            Console.WriteLine("**Get Car By Id**");
            ShowCar(carManager.GetById(7).Data);
            Console.WriteLine("**Get Cars By Brand Id**");
            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine("{0} - {1} - {2}", car.Id, car.Description, car.DailyPrice);
            }
            Console.WriteLine("**Get Cars By Color Id**");
            foreach (var car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine("{0} - {1} - {2}", car.Id, car.Description, car.DailyPrice);
            }

            Console.WriteLine("**Update**");

            carManager.Update(new Car { Id = 7, DailyPrice = 500, Description = "AXT7", ColorId = 1, BrandId = 2, ModelYear = "2021" });
            ShowCar(carManager.GetById(7).Data);

            Console.WriteLine("**Delete**");
            carManager.Delete(new Car { Id = 7, DailyPrice = 500, Description = "AXT7", ColorId = 1, BrandId = 2, ModelYear = "2021" });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1} - {2}", car.Id, car.Description, car.DailyPrice);
            }
        }

        private static void DtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetail().Data)
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
            List<Car> cars = carManager.GetAll().Data;

            foreach (var car in cars)
            {
                ShowCar(car);
            }

            Console.WriteLine("******GetByBrandId*****");
            List<Car> cars2 = carManager.GetCarsByBrandId(2).Data;
            foreach (var car in cars2)
            {
                ShowCar(car);
            }

            Console.WriteLine("******GetByColorId*****");
            List<Car> cars3 = carManager.GetCarsByColorId(1).Data;
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
            List<Car> cars = carManager.GetAll().Data;
            foreach (var c in cars)
            {


                Console.Write(c.Id);
                Console.WriteLine(c.Description);

            }
        }
    }
}
