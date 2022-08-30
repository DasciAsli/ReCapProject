using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //CarMessages
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted= "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarsDetailsListed = "Arabaların detayları listelendi";
        public static string CarsByBrandIdListed = "Marka Id'ye göre arabalar listelendi";
        public static string CarsByColorIdListed = "Renk Id'ye göre arabalar listelendi";

        //ColorMessages
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorGetByIdListed = "Renk Id'ye göre getirildi";

        //BrandMessages
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandListed = "Markalar listelendi";
        public static string BrandGetByIdListed = "Marka Id'ye göre listelendi";
    }
}

