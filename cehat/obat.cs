using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    public class Obat : Informasi
    {
        private string dosis;
        private string efekSamping;
        public string Dosis { get => dosis; set => dosis = value; }
        public string EfekSamping { get => efekSamping; set => efekSamping = value; }
    
        public Obat(string nama, string dosis = null, string efekSamping = null)
        {
            Nama = nama;
            Dosis = dosis;
            EfekSamping = efekSamping;
        }

    }

}
