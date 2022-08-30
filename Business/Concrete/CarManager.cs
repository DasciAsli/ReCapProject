using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Car car)
        {
            _cardal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            
        }

        public IResult Delete(Car car)
        {
            _cardal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {          
           return new SuccessDataResult<List<Car>>(_cardal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetails(),Messages.CarsDetailsListed) ;
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int BrandId)
        {

            return new SuccessDataResult<List<Car>>(_cardal.GetAll(c => c.BrandId == BrandId), Messages.CarsByBrandIdListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int ColorId)
        {
            
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(c => c.ColorId == ColorId),Messages.CarsByColorIdListed);
        }

        public IResult Update(Car car)
        {
            _cardal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
