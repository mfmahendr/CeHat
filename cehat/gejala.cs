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

        public void Soal(string gejala)
        {
            Console.WriteLine($"Apakah anda mengalami {gejala} ?");
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
    }
}
