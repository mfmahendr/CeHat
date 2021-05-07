using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cehat.Entities;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
                using (var db = new DataModel())
                {
                    var query = from administrator in db.Admins
                                where administrator.username == textBoxUsername.Text
                                where administrator.password == textBoxPassword.Text
                                select administrator;

                    foreach (var item in query)
                    {
                        Admin admin = new Admin(item.username, item.password);
                        if (admin.IsCorrect(textBoxUsername.Text, textBoxPassword.Text))
                        {
                            MessageBox.Show("Login Berhasil!");

                            this.Hide();
                            FormMenuAdmin menus = new FormMenuAdmin();
                            menus.Show();
                        }
                        else
                        {
                            MessageBox.Show("Login Gagal, Coba Lagi!");
                        }
                    }
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

