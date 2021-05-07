namespace cehat.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblDetail")]
    public partial class TblDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int IdPenyakit { get; set; }

        public int IdGejala { get; set; }

        public virtual TblGejala TblGejala { get; set; }

        public virtual TblPenyakit TblPenyakit { get; set; }
    }
}
