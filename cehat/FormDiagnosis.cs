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
    public partial class FormDiagnosis : Form
    {
        AturanGejala aturan = new AturanGejala();

        // agar form draggable walaupun borderless
        bool mousedown;
        private Point offset;

        public FormDiagnosis()
        {
            InitializeComponent();
        }

        private void CheckedList()
        {
            try
            {
                clGejala.DataSource = Gejala.GetListDetailGejala();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FormDiagnosis_Load(object sender, EventArgs e)
        {
            clGejala.Items.Clear();

            CheckedList();
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
            this.Hide();
            FormMenuUser menu = new FormMenuUser();
            menu.Show();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            var gejalaTerpilih = clGejala.CheckedItems;
            int jumlahGejalaTerpilih = gejalaTerpilih.Count;
            foreach(var cek in gejalaTerpilih)
            {
                MessageBox.Show(cek.ToString());
            }
            MessageBox.Show(jumlahGejalaTerpilih.ToString());
        }
    }
}
