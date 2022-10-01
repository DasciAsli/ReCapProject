using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public static string CarsDetailsByBrandIdListed = "Marka Id'ye göre arabaların detayları listelendi";
        public static string CarsDetailsByColorIdListed = "Renk Id'ye göre arabaların detayları listelendi";

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
        public static string BrandGetByIdListed = "Marka Id'ye göre getirildi";

        //UserMessages
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserGetById = "Kullanıcı Id'ye göre getirildi";


        //CustomerMessages
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomersListed = "Müşteriler listelendi";
        public static string CustomerGetById = "Müşteri Id'ye göre getirildi";
        public static string CustomerDetailsListed = "Müşteri detayları listelendi";


        //RentalMessages
        public static string RentalAdded = "Kiralama başarılı";
        public static string RentalDeleted = "Kiralama kaydı silindi";
        public static string RentalUpdated = "Kiralama kaydı güncellendi";
        public static string RentalsListed = "Kiralama kayıtları listelendi";
        public static string RentalGetById = "Kiralama kaydı Id'ye göre getirildi";
        public static string RentalDetailsListed = "Kiralamaların detayları listelendi";

        //ImageMessages
        public static string ImageAdded = "Resim eklendi";
        public static string ImageDeleted= "Resim silindi";
        public static string ImageUpdated= "Resim güncellendi";
        public static string ImagesListed = "Resimler listelendi";
        public static string ImagesFiltered = "Resimler filtrelendi";

        //AuthMessages
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string UserRegistered = "Kullanıcı kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Hatalı parola";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AuthorizationDenied = "Yetkiniz yok";
        
    }
}

