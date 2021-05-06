using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    public abstract class Informasi
    {
        private int id;
        private string nama;

        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }

        public void Tambah()
        {
            
        }
        public void Ubah() { }
    }
}
