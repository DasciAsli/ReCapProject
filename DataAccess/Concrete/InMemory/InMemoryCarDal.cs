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
        List<Car> cars = null;
        public InMemoryCarDal()
        {
            cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,ModelYear=new DateTime(1995,01,01),DailyPrice=15000,Description="Car1 açıklaması" },
                new Car{CarId=2,BrandId=1,ColorId=4,ModelYear=new DateTime(1993,01,10),DailyPrice=30000,Description="Car2 açıklaması" },
                new Car{CarId=3,BrandId=1,ColorId=3,ModelYear=new DateTime(1990,01,21),DailyPrice=45000,Description="Car3 açıklaması" }
            };
        }

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            carToDelete = cars.SingleOrDefault(c => c.CarId == car.CarId);
            cars.Remove(carToDelete);
        }       

        public void Update(Car car)
        {
            Car carToUpdate = null;
            carToUpdate = cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return filter==null? cars: throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetailsByBrandId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
