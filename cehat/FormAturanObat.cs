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
using System.Data.Entity.Validation;

namespace cehat
{
    public partial class FormAturanObat : Form
    {
        #region Atribut
        private readonly AturanObat aturan = new AturanObat();
        private readonly Penyakit penyakit = new Penyakit();
        private readonly Obat obat = new Obat();

        // agar form draggable walaupun borderless
        private bool mousedown;
        private Point offset;
        private int idPenyakit;
        private int? idObat;
        #endregion

        #region Method
        private void DisplayData()
        {
            try
            {
                dataGridView1.DataSource = aturan.GetAturanObat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IsiComboBox()
        {
            comboBoxPenyakit.DataSource = penyakit.GetListNamaPenyakit().ToList();
            comboBoxObat.DataSource = obat.GetListNamaObat().ToList();
        }

        private void Reset()
        {
            comboBoxPenyakit.SelectedItem = null;
            comboBoxObat.SelectedItem = null;

            idPenyakit = 0;
            idObat = null;

            buttonTambah.Enabled = true;
            buttonHapus.Enabled = false;
        }

        #endregion

        #region Konstruktor
        public FormAturanObat()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMenuAdmin menu = new FormMenuAdmin();
            menu.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string message = "Yakin ingin keluar?";
            string caption = "Konfirmasi";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FormAturanObat_Load(object sender, EventArgs e)
        {
            comboBoxPenyakit.Items.Clear();
            comboBoxObat.Items.Clear();

            IsiComboBox();
            Reset();
            DisplayData();

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPenyakit.SelectedItem != null && idObat != null)
                {
                    if (aturan.Tambah((int)idPenyakit, idObat))
                    {
                        MessageBox.Show("Data berhasil ditambahkan!");
                    }
                    else
                    {
                        MessageBox.Show("Data gagal ditambahkan, kemungkinan karena data yang ditambahkan sudah ada");
                    }
                }
                else if (comboBoxPenyakit.SelectedItem != null)
                {
                    if (aturan.Tambah(idPenyakit, null))
                    {
                        MessageBox.Show("Data berhasil ditambahkan!");
                    }
                    else
                    {
                        MessageBox.Show("Data gagal ditambahkan, kemungkinan karena data yang ditambahkan sudah ada");
                    }
                }
                else
                {
                    MessageBox.Show("Data informasi tidak boleh kosong!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Sumber exception" + ex.Source + "\n Stack Trace: " + ex.StackTrace + "\n Message: " + ex.Message); }
            Reset();
            DisplayData();
        }

        private void buttonHapus_Click(object sender, EventArgs e) 
        {
            try
            {
                string message = "Yakin ingin hapus data?";
                string caption = "Konfirmasi";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (aturan.Hapus(aturan.IdPenyakit, aturan.IdObat))
                    {
                        MessageBox.Show("Data berhasil dihapus!");
                    }
                    else { MessageBox.Show("Data gagal dihapus!"); }
                }
                    
            }
            catch (ArgumentNullException) { MessageBox.Show("Data gagal dihapus, kemungkinan karena terdapat dua atau lebih record"); }
            catch (Exception ex) { MessageBox.Show(ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace); }

            DisplayData();
            Reset();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Reset();
            DisplayData();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            comboBoxObat.Text = "";
            comboBoxPenyakit.Text = "";

            int baris = e.RowIndex;
            if (baris >= 0)
            {
                buttonTambah.Enabled = false;
                buttonHapus.Enabled = true;

                idPenyakit = (int)dataGridView1.Rows[baris].Cells[0].Value;
                idObat = (int?)dataGridView1.Rows[baris].Cells[1].Value;

                comboBoxPenyakit.Text = penyakit.GetNamaBerdasarkan(idPenyakit);

                if (idObat != null) 
                {
                    comboBoxObat.Text = obat.GetNamaBerdasarkan((int)idObat);
                }
                else { comboBoxObat.Text = ""; }
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aturan.GetAturanObat(tbCari.Text);
        }

        private void comboBox_Click(object sender, EventArgs e)
        {
            buttonTambah.Enabled = true;
            buttonHapus.Enabled = false;
        }

        private void comboBoxPenyakit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxPenyakit.SelectedItem != null)
                idPenyakit = penyakit.GetIdBerdasarkan(comboBoxPenyakit.SelectedItem.ToString());
        }

        private void comboBoxObat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxObat.SelectedItem != null)
                idObat = obat.GetIdBerdasarkan(comboBoxObat.SelectedItem.ToString());
        }
        #endregion

        private void FormAturanObat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
