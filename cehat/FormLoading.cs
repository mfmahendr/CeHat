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
    public partial class FormLoading : Form
    {
        public FormLoading()
        {
            InitializeComponent();
        }
        private void FormLoading_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= 800)
            {
                timer1.Stop();
                pictureBox1.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Hide();
        }
    }
}