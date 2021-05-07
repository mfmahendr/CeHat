namespace cehat.Entities
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
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public Admin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool IsCorrect(string inputUsername, string inputPass)
        {
            if (inputPass.Equals(password) && inputPass.Equals(username))
                return true;
            else
                return false;
        }

    }
    }
