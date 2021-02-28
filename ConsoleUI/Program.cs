﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntifyFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            

        }

        private static void AddRentaltest()
        {
            IRentalService rentalService = new RentalManager(new EfRentalDal());

            rentalService.Add(new Rental
            {
                CarId = 2,
                CustomerId = 1,
                RentDate = new DateTime(2020, 6, 3, 12, 20, 12),
                ReturnDate = null
            });
        }

        private static void AddCustomerTest()
        {
            ICustomerService customerService = new CustomerManager(new EfCustomerDal());
            customerService.Add(new Customer { UserId = 1004, CompanyName = "merkez" });
        }

        private static void AddUserTest()
        {
            IUserService userService = new UserManager(new EfUserDal());
            userService.Add(new User { FirstName = "aslı", LastName = "sıla", Email = "aa111@gmail.com", Password = "122" });
        }

        private static void DeleteColorTest(ColorManager colorManager)
        {
            colorManager.Delete(new Color { Id = 1002 });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0} -- {1}", color.Id, color.Name);
            }
        }

        private static void UpdateColorTest(ColorManager colorManager)
        {
            colorManager.Update(new Color { Id = 3, Name = "Navy Blue" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0} -- {1}", color.Id, color.Name);
            }
        }

        private static void AddColorTest(ColorManager colorManager)
        {
            colorManager.Add(new Color { Name = "Purple" });
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0} -- {1}", color.Id, color.Name);
            }
        }

        private static void ReadGetByIdColorTest(ColorManager colorManager)
        {
            Console.WriteLine("{0}", colorManager.GetById(1).Data.Name);
        }

        private static void ReadColorsTest(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0} -- {1}", color.Id, color.Name);
            }
        }

        private static void GetByIdCarTest(CarManager carManager)
        {
            Console.WriteLine(carManager.GetById(1).Data.Description);
        }

        private static void CarDetailTest(CarManager carManager)
        {
            var results = carManager.GetCarDetails();
            foreach (var car in results.Data)
            {
                Console.WriteLine("{0} -- {1} -- {2} -- {3}", car.BrandName, car.Name, car.ColorName, car.DailyPrice);
            }
            Console.WriteLine(results.Message);

        }

        private static void DeleteBrandTest(BrandManager brandManager)
        {
            brandManager.Delete(new Brand { Id = 1003 });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0} -- {1}", brand.Id, brand.Name);
            }
        }

        private static void UpdateBrandTest(BrandManager brandManager)
        {
            brandManager.Update(new Brand { Id = 2, Name = "Alfa Romeo" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0} -- {1}", brand.Id, brand.Name);
            }
        }

        private static void AddBrandTest(BrandManager brandManager)
        {
            brandManager.Add(new Brand { Name = "Bentley" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0} -- {1}", brand.Id, brand.Name);
            }
        }

        private static void ReadBrandGetByIdTest(BrandManager brandManager)
        {
            Console.WriteLine("{0}", brandManager.GetById(2).Data.Name);
        }

        private static void ReadBrandTest(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0} -- {1}", brand.Id, brand.Name);
            }
        }

        private static void DeleteCarTest(CarManager carManager)
        {
            carManager.Delete(new Car { Id = 2002 });
            GetAllCarList(carManager);
        }

        private static void UpdateCarTest(CarManager carManager)
        {
            carManager.Update(new Car { Id = 1, BrandId = 4, ColorId = 3, ModelYear = 2011, DailyPrice = 123.345, Description = "araba-3" });
            GetAllCarList(carManager);
        }

        private static void AddCarTest(CarManager carManager)
        {
            

            var result = carManager.Add(new Car { BrandId = 4, ColorId = 3, ModelYear = 2005, DailyPrice = 123.345, Description = "araba-3" });
            Console.WriteLine(result.Message);
        }



        private static void PrintSingleElement(Car car)
        {
            Console.WriteLine("{0}. Araba Model = {1}, Renk = {2} ,Yıl = {3} ,Fiyat = {4} ,Açıklama = {5}",
                                car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
        }

        private static void GetAllCarList(ICarService carManager)
        {
            var results = carManager.GetAll();
            foreach (var car in results.Data)
            {
                Console.WriteLine("{0}. Araba Model = {1}, Renk = {2} ,Yıl = {3} ,Fiyat = {4} ,Açıklama = {5}",
                     car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);

            }
            Console.WriteLine(results.Message);
            
        }
    }
}
