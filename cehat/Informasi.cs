using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cehat
{
    public abstract class Informasi
    {

        protected CeHatContext dbo = Akses.Tabel();
        protected bool status;

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nama { get; set; }

        public void Tambah() { }
        public void Ubah() { }
    }
}
