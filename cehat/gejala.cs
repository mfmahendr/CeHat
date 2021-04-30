using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    public class Gejala
    {
        private int id;
        private List<string> gejala;
        private bool status;
        private bool jawaban;

        public int Id { get => id; set => id = value; }
        public List<string> GejalaPenyakit { get => gejala; set => gejala = value; }

        public Gejala(List<string> gejala)
        {
            this.gejala = gejala;
        }
             
        public void Terjawab(bool jawaban, bool status)
        {
            if(jawaban = true)
            {
                status = true;
            }
            else
            {
                status = false;
            }
        }

        public bool IsExist(string gejalaDicek)
        {
            bool isExist = false;
            foreach(string i in this.gejala)
            {
                if (gejalaDicek == i) { isExist = true; }
            }

            return isExist;
        }

        public void Tambah(List<string> gejala)
        {
            List<string> gejalaTambahan = new List<string>();
            foreach(string i in gejala)
            {
                if (!IsExist(i))
                {
                    gejalaTambahan.Add(i);
                    Console.WriteLine("Gejala masukan belum ada sehingga informasi penyakit baru bisa ditambahkan. Tapi cari tahu dulu penyakit apa yang dideritanya");
                                    }
                else { Console.WriteLine("Gejala sudah ada"); }
            }

            string namaPenyakitTambahan = Console.ReadLine();
            Console.WriteLine("Apa nama obatnya?");
            string namaObat = Console.ReadLine();
            Console.WriteLine("Dosisnya bagaimana?");
            string dosisObat = Console.ReadLine();
            Console.WriteLine("Apa efek samping obat?");
            string efekSampingObat = Console.ReadLine();
            Penyakit tambahanPenyakit = new Penyakit(namaPenyakitTambahan, new Gejala(gejalaTambahan), new Obat(namaObat, dosisObat, efekSampingObat));
        }
    }
}
