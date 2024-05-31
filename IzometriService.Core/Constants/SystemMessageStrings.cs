using System;
using System.Collections.Generic;
using System.Text;

namespace IzometriService.Core.Constants
{
    public static class ResultMessages
    {

        public static string Successful = "Başarılı";
        public static string IsNullAndIsEmpty = "Bu alan boş geçilemez";
        public static string IsValidEmail = "Lütfen geçerli bir email giriniz";

    }

    public static class AspectMessages
    {
        public static string WrongValidationType => "Yanlış doğrulama türü.";

        public static string WrongLoggerType => "Yanlış Kaydedici Türü";
    }
}
