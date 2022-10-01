using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result= from c in context.Cars
                            join b in context.Brands
                            on c.BrandId equals b.BrandId
                            join j in context.Colors
                            on c.ColorId equals j.ColorId
                            select new CarDetailDto
                            {
                              CarId=c.CarId,
                              ColorName=j.ColorName,
                              BrandName=b.BrandName,
                              ModelYear=c.ModelYear,
                              DailyPrice =c.DailyPrice,
                              Description=c.Description
                            };
                return result.ToList();
            } 
        }   

        public List<CarDetailDto> GetCarsDetailsByBrandId(int brandId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join j in context.Colors
                             on c.ColorId equals j.ColorId
                             where b.BrandId== brandId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 ColorName = j.ColorName,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }

        }

        public List<CarDetailDto> GetCarsDetailsByColorId(int colorId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join j in context.Colors
                             on c.ColorId equals j.ColorId
                             where j.ColorId == colorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 ColorName = j.ColorName,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetailsByCarId(int carId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join j in context.Colors
                             on c.ColorId equals j.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 ColorName = j.ColorName,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.SingleOrDefault(c=>c.CarId==carId);
            }
        }
    }
}
