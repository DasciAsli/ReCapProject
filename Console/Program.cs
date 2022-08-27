using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        Car car = new Car() { BrandId = 2, ColorId = 2, ModelYear = new DateTime(2019, 2, 1), Description = "HATA BOYA EZİK ÇİZİK GÖÇÜK VS YOKTUR", DailyPrice = 0 };
        CarManager carManager = new CarManager(new EFCarDal(new CheckCarDal()));
        carManager.Add(car);
        

    }
}