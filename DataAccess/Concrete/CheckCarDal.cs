using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CheckCarDal :ICheckCarDal
    {
        public bool IfCheckTrue(Car car)
        {
            if ((car.Description).Length > 2 && car.DailyPrice > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
