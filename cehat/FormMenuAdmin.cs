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
        public FormMenuAdmin()
        {
            InitializeComponent();
        }

        private void pbDataAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataAdmin data = new FormDataAdmin();
            data.Show();
        }

        private void pbDataGejala_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataGejala data = new FormDataGejala();
            data.Show();
        }

        private void pbDataObat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataObat data = new FormDataObat();
            data.Show();
        }

        private void pbDataPenyakit_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDataPenyakit data = new FormDataPenyakit();
            data.Show();
        }

        private void pbAturanGejala_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAturanGejala data = new FormAturanGejala();
            data.Show();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLoginAdmin login = new FormLoginAdmin();
            login.Show();
        }

        private void pbAturanObat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAturanObat data = new FormAturanObat();
            data.Show();
        }
    }
}
