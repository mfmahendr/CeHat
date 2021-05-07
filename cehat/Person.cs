using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    public abstract class Person
    {
        public int Id { get; set; }
    }

    public class User : Person
    {
        private string nama;

        public User(string nama)
        {
            this.nama = nama;
        }

        public void Halo(string nama)
        {
            Console.WriteLine($"Halo {nama}, selamat datang di aplikasi CeHat");
        }
        
        public void TambahGejala()
        {
        
        }
     }
}
