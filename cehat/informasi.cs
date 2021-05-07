using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    public abstract class Informasi
    {
        public int Id { get; set; }
        public string Nama { get; set; }

        public void Tambah(){ }
        public void Ubah() { }
    }
}
