using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    public class User : Person
    {
        public static string Halo(string nama)
        {
            string halo = $"Halo {nama}, selamat datang di aplikasi CeHat!";
            return halo;
        }
    }
}
