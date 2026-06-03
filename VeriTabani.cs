using System;
using System.Data;
// Az önce kurduğumuz kütüphaneyi buraya çağırıyoruz
using MySql.Data.MySqlClient;

namespace TiyatroBiletSistemi
{
   
        public static class VeriTabani
        {
            // Bağlantı bilgilerin (XAMPP/WampServer kullanıyorsan genelde şifre boştur)
            // Eğer MySQL için şifre belirlediysen Pwd= kısmına onu yazmalısın.
            private static string connectionString = "Server=localhost;Database=TiyatroDB;Uid=root;Pwd=nesli4345oZ.;";

            // Bu metot projedeki diğer formlardan veri tabanına kolayca bağlanmanı sağlayacak
            public static MySqlConnection BaglantiAl()
            {
                return new MySqlConnection(connectionString);
            }
        }
}
