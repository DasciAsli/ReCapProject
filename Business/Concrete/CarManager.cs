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
        ICarDal _cardal;
        public CarManager(ICarDal carDal)
        {
            _cardal = carDal;
        }

        public void Add(Car car)
        {
            _cardal.Add(car);
        }

        public void Delete(Car car)
        {
            _cardal.Delete(car);
        }

        public List<Car> GetAll()
        {
           return _cardal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            return _cardal.GetAll(c => c.BrandId == BrandId);
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            return _cardal.GetAll(c => c.ColorId == ColorId);
        }

        public void Update(Car car)
        {
            _cardal.Update(car);
        }
    }
}
