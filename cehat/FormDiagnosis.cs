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
        private AturanGejala aturan = new AturanGejala();
        private Gejala gejala = new Gejala();
        private List<int> kumpulanIdGejala;
        private bool status;
        private int tempId;

        // agar form draggable walaupun borderless
        private bool mousedown;
        private Point offset;

        public FormDiagnosis()
        {
            InitializeComponent();
        }

        private void CheckedList()
        {
            try
            {
                clGejala.DataSource = gejala.GetListDetailGejala();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Reset()
        {
            status = false;

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
            string message = "Serius ingin keluar?";
            string caption = "Konfirmasi";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
            //this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuUser menu = new FormMenuUser();
            menu.Show();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int jumlahGejalaTerpilih = clGejala.CheckedItems.Count;
            try
            {
                // memilih id penyakit yang memiliki jumlah id gejala yang sama
                //var kumpulanIdPenyakit = Akses.Tabel().AturanGejalas.GroupBy(x => x.IdPenyakit).Where(y => y.Count() == jumlahGejalaTerpilih).ToList();
                var kumpulanIdPenyakit = aturan.GetIdPenyakitBerdasarkan(jumlahGejalaTerpilih);

                if (kumpulanIdPenyakit.Count() != 0)
                {
                    List<int> listIdGejalaTerpilih = new List<int>();

                    foreach (var gejalaTerpilih in clGejala.CheckedItems)
                    {
                        //tempId = Akses.Tabel().Gejalas.Where(x => x.DetailGejala == gejalaTerpilih.ToString()).Select(x => x.Id).Single();
                        tempId = gejala.GetIdBerdasarkan(gejalaTerpilih.ToString());
                        listIdGejalaTerpilih.Add(tempId);
                    }

                    // Mengecek setiap list id gejala dari penyakit dengan jumlah gejala yang sama
                    // dengan list id gejala yang dipilih
                    foreach (var idPenyakit in kumpulanIdPenyakit)
                    {
                        // mendapatkan kumpulan id gejala dari id penyakit
                        kumpulanIdGejala = aturan.GetIdGejalaBerdasarkan(idPenyakit.Key);


                        status = Enumerable.SequenceEqual(listIdGejalaTerpilih.OrderBy(x => x), kumpulanIdGejala.OrderBy(x => x));
                        if (status)
                        {
                            MessageBox.Show(status.ToString());
                            FormHasilDiagnosis laporanHasil = new FormHasilDiagnosis(idPenyakit.Key);
                            laporanHasil.Show();
                            this.Hide();
                        }
                    }

                    if (!status)
                        MessageBox.Show("Mohon maaf, penyakit Anda tidak ditemukan.");
                }
                else
                    MessageBox.Show("Mohon maaf, penyakit Anda tidak ditemukan.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Reset();
        }
    }
}
