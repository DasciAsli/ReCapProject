using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
                              Description=c.Description,
                              ColorName=j.ColorName,
                              BrandName=b.BrandName,
                              DailyPrice =c.DailyPrice
                            };
                return result.ToList();


            } 
        }
    }
}
