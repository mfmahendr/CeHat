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
    public partial class FormHasilDiagnosis : Form
    {
        #region Field
        private readonly AturanObat aturanObat = new AturanObat();
        private readonly HasilDiagnosis hasilDiagnosis = new HasilDiagnosis();
        private readonly Penyakit penyakit = new Penyakit();
        private readonly Obat obat = new Obat();
        private readonly string namaObat;
        private readonly string dosisObat;
        private readonly string efekObat;

        // agar form draggable walaupun borderless
        bool mousedown;
        private Point offset;
        #endregion

        #region Konstruktor
        public FormHasilDiagnosis(int idPenyakit)
        {
            InitializeComponent();
            namaObat = "Tidak ada";
            dosisObat = string.Empty;
            efekObat = string.Empty;

            string namaPenyakit = penyakit.GetNamaBerdasarkan(idPenyakit);
            hasilDiagnosis.UbahFrekuensi(namaPenyakit);

            try
            {
                tbNamaPenyakit.Text = penyakit.GetNamaBerdasarkan(idPenyakit);
                tbDeskripsiPenyakit.Text = penyakit.GetDeskripsiBerdasarkan(idPenyakit);

                int? idObat = aturanObat.GetIdObat(idPenyakit);

                if (idObat != null)
                {
                    namaObat = obat.GetNamaBerdasarkan(idPenyakit);
                    dosisObat = obat.GetDosisBerdasarkan(idPenyakit);
                    efekObat = obat.GetEfekSampingBerdasarkan(idPenyakit);
                }
            }
            catch (InvalidOperationException)
            {
                namaObat = "Tidak ada";
                dosisObat = string.Empty;
                efekObat = string.Empty;
            }

            tbNamaObat.Text = namaObat;
            tbDosis.Text = dosisObat;
            tbEfekSamping.Text = efekObat;
        }
        #endregion

        #region event
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

        private void buttonUlangi_Click(object sender, EventArgs e)
        {
            FormDiagnosis formDiagnosis = new FormDiagnosis();
            formDiagnosis.Show();
            this.Hide();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            FormMenuUser menu = new FormMenuUser();
            menu.Show();
            this.Hide();
        }
        #endregion
    }
}
