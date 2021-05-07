namespace cehat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblGejala")]
    public partial class TblGejala // class Gejala
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblGejala()
        {
            TblDetails = new HashSet<TblDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Gejala { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblDetail> TblDetails { get; set; }

        public bool Terjawab(bool jawaban, bool status)
        {
            if (jawaban == true)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            return status;
        }

        public bool IsExist(string gejalaDicek)
        {
            bool isExist = false;
            if (gejalaDicek == Gejala) { isExist = true; }
            return isExist;
        }

        public void Tambah(Gejala gejala)
        {
            throw new NotImplementedException();
        }
    }
}
