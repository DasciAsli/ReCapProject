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
    }

    private static void CarDetailsTest()
    {
        CarManager carManager = new CarManager(new EFCarDal(new CheckCarDal()));
        foreach (var car in carManager.GetCarDetails())
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(car.Description + "\n" + car.BrandName + "\n" + car.ColorName + "\n" + car.DailyPrice);
        }
    }

    private static void ColorTest()
    {
        ColorManager colorManager = new ColorManager(new EFColorDal());
      
        foreach (var color in colorManager.GetAll())
        {
            Console.WriteLine(color.ColorName);
        }


        Color color4 = new Color {ColorId=4, ColorName = "Mor" };
        colorManager.Update(color4);
        Console.WriteLine("*****************");

        foreach (var color in colorManager.GetAll())
        {
            Console.WriteLine(color.ColorName);
        }
    }

    private static void BrandTest()
    {
        BrandManager brandManager = new BrandManager(new EFBrandDal());
        foreach (var brand in brandManager.GetAll())
        {
            Console.WriteLine(brand.BrandName);
        }
    }

    private static void CarTest()
    {
        Car car1 = new Car() { BrandId = 2, ColorId = 2, ModelYear = new DateTime(2019, 2, 1), Description = "HATA BOYA EZİK ÇİZİK GÖÇÜK VS YOKTUR", DailyPrice = 50 };
        CarManager carManager = new CarManager(new EFCarDal(new CheckCarDal()));
        foreach (var car in carManager.GetAll())
        {
            Console.WriteLine(car.Description);
        }
    }
}