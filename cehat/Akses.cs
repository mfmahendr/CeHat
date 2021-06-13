using System;
using System.Collections.Generic;
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

        public static CeHatContext Tabel()
        {
            if(dbo == null)
            {
                dbo = new CeHatContext();
            }
            return dbo;
        }
    }
}
