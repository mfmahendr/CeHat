namespace cehat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin : Person
    {
        [Required]
        [StringLength(80)]
        public string username { get; set; }

        [Required]
        [StringLength(80)]
        public string password { get; set; }
    }
}
