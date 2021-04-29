using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    public abstract class Person
    {
        private int id;
        
    }

    public class Admin : Person
    {
        private string username;
        private string password;

        public Admin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool IsPassCorrect(string inputPass)
        {
            if (inputPass.Equals(password))
                return true;
            else
                return false;
        }
        public bool IsUserCorrect(string inputPass)
        {
            if (inputPass.Equals(username))
                return true;
            else
                return false;
        }

        public void Login()
        {

        }

        public void UbahUsername()
        {

        }
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
            Console.Write($"Halo {nama}, selamat datang di aplikasi CeHat");
        }
        
        public void TambahGejala()
        {
        
        }
     }
}
