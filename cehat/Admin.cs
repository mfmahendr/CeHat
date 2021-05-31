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

    [Table("Admin")]
    public partial class Admin
    {
        private readonly CeHatContext dbo = Akses.Tabel();
        private Admin adminBaru;
        bool status;

        public int Id { get; set; }

        [StringLength(20)]
        public string Username { get; set; }

        [StringLength(20)]
        public string Password { get; set; }



        public List<Admin> GetListSemuaDataBerdasarkan()
        {
            return dbo.Admins.Select(x => x).ToList();
        }

        public List<Admin> GetListSemuaDataBerdasarkan(string username, string password)
        {
            return dbo.Admins.Where(x => x.Username == username && x.Password == password).Select(x => x).ToList();
        }

        public List<Admin> GetListSemuaDataBerdasarkan(string username)
        {
            return dbo.Admins.Where(x => x.Username == username).Select(x => x).ToList();
        }

        public List<Admin> GetListSemuaDataBerdasarkan(int id)
        {
            return dbo.Admins.Where(x => x.Id == id).ToList();
        }

        public List<string> GetListUsername()
        {
            return dbo.Admins.Select(x => x.Username).ToList();
        }

        public string GetUsername(int id)
        {
            return dbo.Admins.Where(x => x.Id == id).Select(x => x.Username).ToString();
        }

        public bool Login(string username, string password)
        {
            status = false;

            var items = dbo.Admins.Where(x => x.Username == username && x.Password == password);

            if (items.Count() != 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

        public bool Tambah(string username, string password)
        {
            if (!dbo.Admins.Any(x => x.Username == username))
            {
                adminBaru = new Admin()
                {
                    Username = username,
                    Password = password
                };

                dbo.Admins.Add(adminBaru);
                dbo.SaveChanges();
                status = true;

            }
            else
            {
                status = false;
            }

            var cek = dbo.Admins.Where(x => x.Username == username && x.Password == password).ToList();
            if (cek.Count == 0) { MessageBox.Show("Tidak tersimpan"); }
            else if(cek.Count == 1){ MessageBox.Show("Yessssssssssssssssssssss"); }
            else if(cek.Count > 1) { MessageBox.Show("Aneh"); }
            return status;
        }

        public bool Ubah(int kondisi, string username = "", string password = "")
        {
            if (username != "" && password != "")
            {
                if (!dbo.Admins.Any(x => x.Username == username) && !dbo.Admins.Any(x => x.Password == password))
                {
                    var admin = dbo.Admins.Where(x => x.Id == kondisi);
                    foreach (var x in admin)
                    {
                        x.Username = username;
                        x.Password = password;
                    }
                    status = true;
                }
                else { status = false; }
            }
            else if (username != "")
            {
                if (!dbo.Admins.Any(x => x.Username == username))
                {
                    var admin = dbo.Admins.Where(x => x.Id == kondisi);
                    foreach (var x in admin)
                    {
                        x.Username = username;
                    }
                    status = true;
                }
                else { status = false; }
            }
            else if (password != "")
            {
                if (!dbo.Admins.Any(x => x.Password == password))
                {
                    var admin = dbo.Admins.Where(x => x.Id == kondisi);
                    foreach (var x in admin)
                    {
                        x.Password = password;
                    }
                    status = true;
                }
                else { status = false; }
            }

            dbo.SaveChanges();
            return status;
        }

        public bool Hapus(int Id = 0, string username = "", string password = "")
        {
            if (Id != 0 && username != "" && password != "")
            {
                dbo.Admins.RemoveRange(dbo.Admins
                .Where(x =>x.Id == Id && x.Username == username && x.Password == password));

                status = true;
            }
            else if (username != "" && password !="")
            {
                dbo.Admins.RemoveRange(dbo.Admins
                .Where(x => x.Username == username && x.Password == password));

                status = true;
            }
            else if(Id != 0)
            {
                dbo.Admins.RemoveRange(dbo.Admins
                .Where(x => x.Id == Id));

                status = true;
            }
            else if(username != "")
            {
                dbo.Admins.RemoveRange(dbo.Admins
                .Where(x => x.Username == username));

                status = true;
            }
            else if(password != "")
            {
                dbo.Admins.RemoveRange(dbo.Admins
                .Where(x => x.Password == password));

                status = true;
            }
            else { status = false; }

            dbo.SaveChanges();
            return status;
        }
    }
}
