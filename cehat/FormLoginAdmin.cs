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

        #region Atribut
        private readonly Admin admin = new Admin();
        // agar form draggable walaupun borderless
        private bool mousedown;
        private Point offset;
        #endregion

        #region Constructor
        // Constructor
        public FormLoginAdmin()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
        private void FormLoginAdmin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text != "" && textBoxPassword.Text != "")
            {
                try
                {
                    if (admin.CekBerdasarkan(textBoxUsername.Text, textBoxPassword.Text))
                    {
                        MessageBox.Show("Login Berhasil!");
                        FormMenuAdmin menu = new FormMenuAdmin();
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah!!");
                    }
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }
            else if (textBoxUsername.Text == "" && textBoxPassword.Text == "")
            {
                MessageBox.Show("Username dan password belum diisi");
            }
            else if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Password belum diisi");
            }
            else
            {
                MessageBox.Show("Username belum diisi");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Hide();
        }

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
        #endregion
    }
}

