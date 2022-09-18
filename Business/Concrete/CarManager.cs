 using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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

        [SecuredOperation("car.add")]
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
