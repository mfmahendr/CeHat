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
    public partial class FormLoginUser : Form
    {
        public FormLoginUser()
        {
            InitializeComponent();
        }

        private void FormLoginUser_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            User user = new User(textBoxNama.Text);
            MessageBox.Show($"Halo {textBoxNama.Text}, Selamat Datang di Aplikasi CeHat!");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin login = new FormLogin();
            login.Show();
        }
    }
}
