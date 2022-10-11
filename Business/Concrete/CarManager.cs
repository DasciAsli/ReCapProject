 using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;
        public CarManager(ICarDal carDal)
        {
            _cardal = carDal;
        }

        //[SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //business code
            _cardal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(Car car)
        {
            _cardal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {          
           return new SuccessDataResult<List<Car>>(_cardal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetails(),Messages.CarsDetailsListed) ;
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int brandId)
        {

            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarsDetailsByBrandId(brandId), Messages.CarsDetailsByBrandIdListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int colorId)
        {
            
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarsDetailsByColorId(colorId),Messages.CarsDetailsByColorIdListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _cardal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }

        public IDataResult<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_cardal.GetCarDetailsByCarId(carId), Messages.CarDetailsByCarIdListed);
        }

        public IDataResult<Car> GetCarByCarId(int carId)
        {
            return new SuccessDataResult<Car>(_cardal.Get(c => c.CarId == carId), Messages.CarByCarIdFiltered); 
        }
    }
}
