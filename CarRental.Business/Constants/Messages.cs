using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Constants
{
    public static class Messages
    {
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UsersListed = "Kullanıcılar listelendi.";
        public static string UsersNotFound = "Kullanıcı bulunamadı.";
        public static string MaintanceTime = "Bakım saati.";
        public static string ImageLimitExceeded = "Araca kayıtlı resim sayısını aşmış bulunmaktasınız.";
        public static string DefaultCarImage = "Araca kayıtlı bir resim bulunamadığı için default resim görüntülenmektedir.";
        public static string NotFound = "Kayitli bir veri bulunamadi.";
        public static string AuthorizationDenied = "Bu işleme yetkiniz bulunmamaktadır.";
        public static string EmailAlreadyExists = "Bu mail adresinde zaten bir kullanıcı bulunmaktadır.";
        public static string CarNotFound = "Verilen parametrede bir araç bulunamadı.";
    }
}
