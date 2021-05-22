using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace cehat
{
    public partial class FormLoginAdmin : Form
    {
        public FormLoginAdmin()
        {
            InitializeComponent();
        }

        private void FormLoginAdmin_Load(object sender, EventArgs e)
        {

        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (textBoxUsername.Text == "" && textBoxPassword.Text == "")
            {
                MessageBox.Show("Username dan password belum diisi");
            }
            else if(textBoxUsername.Text == "") 
            { 
                MessageBox.Show("Username belum diisi"); 
            }
            else if(textBoxPassword.Text == "")
            {
                MessageBox.Show("Password belum diisi");
            }
            else
            {
                pictureBox2.Enabled = false;
                try
                {
                    await Task.Run(() =>
                    {
                        using (var db = new CeHatDBContext())
                        {
                            var query = from a in db.Admins
                                        where a.username == textBoxUsername.Text
                                        && a.password == textBoxPassword.Text
                                        select a;

                            if (query.Count() != 0)
                            {
                                foreach (var item in query)
                                {
                                    Admin admin = new Admin
                                    {
                                        username = item.username,
                                        password = item.password
                                    };
                                    if (admin.username.Equals(textBoxUsername.Text) &&
                                    admin.password.Equals(textBoxPassword.Text))
                                    {
                                        MessageBox.Show("Login Berhasil!");

                                        this.Hide();
                                        FormMenuAdmin menus = new FormMenuAdmin();
                                        menus.Show();
                                    }
                                }
                            }
                            else { MessageBox.Show("Login gagal, username atau password yang Anda isikan salah. Coba lagi!"); }
                        }
                    });

                    pictureBox2.Enabled = true;

                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin login = new FormLogin();
            login.Show();
        }

        // agar form draggable walaupun borderless
        bool mousedown;
        private Point offset;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mousedown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown == true)
            {
                Point currentSceenPos = PointToScreen(e.Location);
                Location = new Point(currentSceenPos.X - offset.X, currentSceenPos.Y - offset.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}