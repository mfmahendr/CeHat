using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin("admin","admin");

            if (admin.IsUserCorrect(textBoxUsername.Text) &&
                admin.IsPassCorrect(textBoxPassword.Text))
            {
                MessageBox.Show("Login Berhasil!");
            }

            else
            {
                MessageBox.Show("Login Gagal, Coba Lagi!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin login = new FormLogin();
            login.Show();
        }
    }
}
