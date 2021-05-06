using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    public class Penyakit : Informasi // isinya akan ada di database
    {
        private Obat obat;
        private Gejala gejala;

        public Penyakit(string nama, Gejala gejala, Obat obat = null)
        {
            Nama = nama;
            this.gejala = gejala;
            this.obat = obat;
        }

        public bool ShowInfoPenyakit()
        {
            bool isSuccess = false;
            Console.WriteLine($"Penyakit yang mungkin anda derita: " + Nama);
            Console.WriteLine("Gejala yang biasanya dialami: ");
            foreach(string i in gejala.GejalaPenyakit)
            {
                Console.WriteLine(i);
            }
            if (obat != null) 
            {
                Console.WriteLine("Saran obat: " + obat.Nama);
                if(obat.Dosis != null)
                {
                    Console.WriteLine("Dosis obat: " + obat.Dosis);
                }
                if(obat.EfekSamping != null)
                {
                    Console.WriteLine("Efek samping:" + obat.EfekSamping);
                }
            }
            return isSuccess;
        }

        public new bool Tambah(Penyakit penyakit)
        {
            throw new NotImplementedException();
        }

        public bool CekInfo(Penyakit penyakit)
        {
            throw new NotImplementedException();
        }
    }
}
