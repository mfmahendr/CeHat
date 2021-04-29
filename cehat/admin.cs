using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    public abstract class person
    {
        private string name;
    }

    public class admin : person
    {
        public void login()
        {

        }

        public void ubahUsername()
        {

        }
    }
    public class user : person
    {
        public void halo()
        {
        
        }
        
        public void tambahGejala()
        {
        
        }
     }
}
