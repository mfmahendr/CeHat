using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    public class Diagnosis
    {
        private string gejala1 = "demam";
        private string gejala2 = "bersin-bersin";
        private string gejala3 = "hidung tersumbat dan berair";
        private string gejala4 = "sakit kepala ringan";
        private string gejala5 = "batuk";
        private string gejala6 = "sesak nafas";
        private string gejala7 = "demam tinggi";
        private string gejala8 = "kondisi di mana sering buang air besar";
        private string gejala9 = "lebih encernya tinja";
        private string gejala10 = "mules pada perut";
        private string gejala11 = "nyeri di ulu hati";
        private string gejala12 = "kembung pada perut dan terasa penuh";
        private string gejala13 = "mual saat atau setelah makan";
        private string gejala14 = "naiknya asam lambung";

        List<string> daftarGejala1 = new List<string>();
        List<string> daftarGejala2 = new List<string>();
        List<string> daftarGejala3 = new List<string>();
        List<string> daftarGejala4 = new List<string>();

        Penyakit penyakit1, penyakit2, penyakit3, penyakit4;
        Gejala gejalaFlu, gejalaCovid, gejalaDiare, gejalaMaag;
        Obat obatFlu, obatDiare, obatMaag;

        public void GenerateInformasi()
        {
            // inisialisasi informasi penyakit flu
            daftarGejala1.Add(gejala1);
            daftarGejala1.Add(gejala2);
            daftarGejala1.Add(gejala3);
            daftarGejala1.Add(gejala4);
            daftarGejala1.Add(gejala5);

            string paracetamol = "Acetaminophen (Paracetamol)";
            string dosisParacetamol = "325–650 mg tiap 4–6 jam atau 1.000 mg tiap 6–8 jam untuk dewasa";
            string efekParacetamol = "Demam, Muncul ruam kulit yang terasa gatal, Sakit tenggorokan, " +
                "muncul sariawan, nyeri punggung, tubuh terasa lemah Kulit atau mata berwarna kekuningan " +
                "timbul memar pada kulit, urine berwarna keruh atau berdarah, tinja berwarna hitam atau BAB berdarah";
            gejalaFlu = new Gejala(daftarGejala1);
            obatFlu = new Obat(paracetamol, dosisParacetamol, efekParacetamol);
            penyakit1 = new Penyakit("Flu", gejalaFlu, obatFlu);

            //i inisialisasi penyakit Covid-19
            daftarGejala2.Add(gejala1);
            daftarGejala2.Add(gejala5);
            daftarGejala2.Add(gejala6);
            daftarGejala2.Add(gejala7);
            gejalaCovid = new Gejala(daftarGejala2);
            penyakit2 = new Penyakit("Covid-19", gejalaCovid);

            // inisialisasi penyakit diare
            daftarGejala3.Add(gejala8);
            daftarGejala3.Add(gejala9);
            daftarGejala3.Add(gejala10);
            string dosisOralit = "Di atas 12 tahun: 12 gelas pada 3 jam pertama, kemudian 2 gelas tiap kali diare";
            string efekSampingOralit = "hipertensi, sakit kepala, pusing, letih, perubahan suasana hati, rasa tidak nyaman di perut, kembung";
            gejalaDiare = new Gejala(daftarGejala3);
            obatDiare = new Obat("Oralit",  dosisOralit, efekSampingOralit);
            penyakit3 = new Penyakit("diare", gejalaDiare, obatDiare);

            // inisialisasi penyakit maag
            daftarGejala4.Add(gejala10);
            daftarGejala4.Add(gejala11);
            daftarGejala4.Add(gejala12);
            daftarGejala4.Add(gejala13);
            daftarGejala4.Add(gejala14);
            string namaObatMaag = "Antasida";
            string dosisObatMaag = "Untuk Dewasa: 1-2 tablet, 3-4 kali per hari. Anak (6-12 tahun) : 0.5-1 tablet, 3-4 kali per har";
            string efekSampingObatMaag = "diare, perut kembung, mual dan muntah, kram perut, sembelit";
            gejalaMaag = new Gejala(daftarGejala4);
            obatMaag = new Obat(namaObatMaag, dosisObatMaag, efekSampingObatMaag);
            penyakit4 = new Penyakit("Maag", gejalaMaag, obatMaag);

            

        }

        public string Soal(string gejala)
        {
            return "Apakah anda mengalami " + gejala +" ?";
        }

        public Penyakit DiagnosisPenyakit() 
        {
            Penyakit hasil = null;

            //// lebih kurang begini

            // labelXXX.Text = Soal(gejala1);
            // if(buttonClick_Yes())
            // {
            //     labelXXX.Text = Soal(gejala6);
            //     menanpilkan label
            //     if(buttonClick_Yes())
            //     {
            //          hasil = penyakit2;
            //     }
            //     if(buttonClick_No())
            //     {
            //          hasil = penyakit1;
            //     }
            //  }
            //
            //  if(buttonClick_No())
            //  {
            //      labelXXX.Text = Soal(gejala10)
            //      menampilkan label
            //      if(buttonClick_Yes)
            //      {
            //          labelXXX.Text = Soal(gejala8);
            //          menampilkan label;
            //          if(buttonClick_Yes)
            //          {
            //              hasil = penyakit3;
            //          }
            //
            //          if(buttonClick_No)
            //          {
            //              labelXXX.Text = Soal(gejala11);
            //              menampilkan label;
            //              if(buttonClick_Yes)
            //              {
            //                  hasil = penyakit4
            //              }
            //              if(buttonClick_No)
            //              {
            //                  hasil = null;
            //              }
            //          }
            //      }
            //  }

            return hasil;
        }

        public void showHasil(Penyakit hasil)
        {
            hasil.ShowInfoPenyakit();
        }
        
    }
}
