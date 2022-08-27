using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : ICarDal
    {
        ICheckCarDal _checkCarDal;
        public EFCarDal(ICheckCarDal checkCarDal)
        {
            _checkCarDal = checkCarDal;
        }

        public void Add(Car entity)
        {
            if (_checkCarDal.IfCheckTrue(entity))
            {
                using (ReCapProjectContext context = new ReCapProjectContext())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
                Console.WriteLine("Kayıt başarılı");

            }
            else
            {
                Console.WriteLine("Araba kaydı başarısız.");
            }
           
        }

        public void Delete(Car entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
           
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
           
        }

        public void Update(Car entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var updateddEntity = context.Entry(entity);
                updateddEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
