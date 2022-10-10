using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    //Buradaki amaç kendi middleware'mizi yazmak
    //Apimizdeki Program.csde olan yaşam döngüsünün içerisine hata yakalama için yazdığımız middleware'ıda ekleyeceğiz
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
