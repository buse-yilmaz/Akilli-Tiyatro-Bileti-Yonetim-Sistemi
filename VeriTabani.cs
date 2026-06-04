using System;
using System.Data;
// Az önce kurduğumuz kütüphaneyi buraya çağırıyoruz
using MySql.Data.MySqlClient;

namespace TiyatroBiletSistemi
{
   
        public static class VeriTabani
        {
            
            private static string connectionString = "Server=localhost;Database=TiyatroDB;Uid=root;Pwd=nesli4345oZ.;";

            
            public static MySqlConnection BaglantiAl()
            {
                return new MySqlConnection(connectionString);
            }
        }
}
