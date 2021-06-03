namespace cehat
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Windows.Forms;

    [Table("Rating")]
    public partial class Rating
    {
        public int Id { get; set; }

        [Column("Rating")]
        public int? RatingAplikasi { get; set; }

        public string KritikSaran { get; set; }

        bool status;
        private readonly CeHatContext dbo = Akses.Tabel();

        public bool Tambah(int ratingaplikasi, string kritiksaran)
        {
            status = false;

            dbo.Ratings.Add(new Rating()
            {
                RatingAplikasi = ratingaplikasi,
                KritikSaran = kritiksaran
            });
            dbo.SaveChanges();
            status = true;

            return status;
        }

        public decimal Rataan()
        {
            var rataan = Math.Round(Convert.ToDecimal(dbo.Ratings
            .Where(c => c.RatingAplikasi != null)
            .Average(c => c.RatingAplikasi)),2);

            return rataan;

        }
    }
} 
