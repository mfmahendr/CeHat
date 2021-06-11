using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cehat
{
    
    // Singleton class (implementasi Singleton Design Pattern)
    public class Akses
    {
        private static CeHatContext dbo;
        private static SqlConnection dbCehatSqlConnection;
        private static string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBCehat.mdf;Integrated Security=True";

        public static CeHatContext Tabel()
        {
            if(dbo == null)
            {
                dbo = new CeHatContext();
            }
            return dbo;
        }

        public static SqlConnection GetSqlConnection()
        {
            if (dbCehatSqlConnection == null)
            {
                dbCehatSqlConnection = new SqlConnection(path);
            }

            return dbCehatSqlConnection;
        }

        public static SqlConnection GetSqlConnection(string connString)
        {
            if (dbCehatSqlConnection == null)
            {
                dbCehatSqlConnection = new SqlConnection(connString);
            }

            return dbCehatSqlConnection;
        }
    }
}
