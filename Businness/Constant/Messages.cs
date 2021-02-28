using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Constant
{
    public class Messages
    {
        public static string Added = "veri tabanına eklendi";
        public static string InvalidName = "geçersiz ismi.";
        public static string Listed = "listelendi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string Deleted = "verita banından silindi";
        public static string Updated = "veri tabanında güncellendi.";
        public static string Rented = "=>araç daha önce kiralandı";
        public static string RentOk="=>kiralama işlemi tamamlandı";

        public static string DirectoryNotExists = "Resimler klasörü bulunamadı";

        public static string ImageCountOverflow = "Resim sayısı olası sınırı aştı";
        public static string DefaultImageName = "DefaultImage.Jpg";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
    }
}
