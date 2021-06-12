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
    public partial class FormMenuAdmin : Form
    {
        // agar form draggable walaupun borderless
        bool mousedown;
        private Point offset;

        public FormMenuAdmin()
        {
            InitializeComponent();
        }

        private void pbDataAdmin_Click(object sender, EventArgs e)
        {
            FormDataAdmin data = new FormDataAdmin();
            data.Show();
            this.Hide();
        }

        private void pbDataGejala_Click(object sender, EventArgs e)
        {
            FormDataGejala data = new FormDataGejala();
            data.Show();
            this.Hide();
        }

        private void pbDataObat_Click(object sender, EventArgs e)
        {
            FormDataObat data = new FormDataObat();
            data.Show();
            this.Hide();
        }

        private void pbDataPenyakit_Click(object sender, EventArgs e)
        {
            FormDataPenyakit data = new FormDataPenyakit();
            data.Show();
            this.Hide();
        }

        private void pbAturanGejala_Click(object sender, EventArgs e)
        {
            FormAturanGejala data = new FormAturanGejala();
            data.Show();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormLoginAdmin login = new FormLoginAdmin();
            login.Show();
            this.Hide();
        }

        private void pbAturanObat_Click(object sender, EventArgs e)
        {
            FormAturanObat data = new FormAturanObat();
            data.Show();
            this.Hide();
        }

        private void FormMenuAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
