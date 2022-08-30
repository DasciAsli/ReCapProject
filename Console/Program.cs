using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Drawing;
using System.Xml.Linq;
using Color = Entities.Concrete.Color;

internal class Program
{
    private static void Main(string[] args)
    {
        //CarTest();

        //BrandTest();

        //ColorTest();

        //CarDetailsTest();

        //UserTest();

        //CustomerTest();

        //RentalTest();

    }

    private static void RentalTest()
    {
        RentalManager rentalManager = new RentalManager(new EFRentalDal());
        var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2022, 08, 30), ReturnDate = new DateTime(2022, 08, 31) });
        Console.WriteLine(result.Message);
    }

    private static void CustomerTest()
    {
        CustomerManager customerManager = new CustomerManager(new EFCustomerDal());

        Console.WriteLine(customerManager.Add(new Customer { UserId = 1, CompanyName = "X" }).Message);
    }

    private static void UserTest()
    {
        UserManager userManager = new UserManager(new EfUserDal());
        userManager.Add(new User { FirstName = "Asli", LastName = "Sak", Email = "asli@gmail.com", Password = "123" });
        foreach (var user in userManager.GetAll().Data)
        {
            Console.WriteLine(user.FirstName + " , " + user.LastName);
        }
    }

    private static void CarDetailsTest()
    {
        CarManager carManager = new CarManager(new EFCarDal());
        foreach (var car in carManager.GetCarDetails().Data)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(car.Description + "\n" + car.BrandName + "\n" + car.ColorName + "\n" + car.DailyPrice);
        }
    }

    private static void ColorTest()
    {
        ColorManager colorManager = new ColorManager(new EFColorDal());
      
        foreach (var color in colorManager.GetAll().Data)
        {
            Console.WriteLine(color.ColorName);
        }


        Color color4 = new Color {ColorId=4, ColorName = "Fuşya" };
        colorManager.Update(color4);
        Console.WriteLine("*****************");

        foreach (var color in colorManager.GetAll().Data)
        {
            Console.WriteLine(color.ColorName);
        }
    }

    private static void BrandTest()
    {
        BrandManager brandManager = new BrandManager(new EFBrandDal());
        foreach (var brand in brandManager.GetAll().Data)
        {
            Console.WriteLine(brand.BrandName);
        }
    }

    private static void CarTest()
    {
        Car car1 = new Car() { BrandId = 2, ColorId = 2, ModelYear = new DateTime(2017, 2, 1), Description = "2.el hasarsız ", DailyPrice = 450 };
        CarManager carManager = new CarManager(new EFCarDal());
        carManager.Add(car1);
        foreach (var car in carManager.GetAll().Data)
        {
            Console.WriteLine(car.Description);
        }
    }
}