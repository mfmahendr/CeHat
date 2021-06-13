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
    public partial class FormAturanGejala : Form
    {
        #region Atribut
        private readonly AturanGejala aturan = new AturanGejala();
        private readonly Penyakit penyakit = new Penyakit();
        private readonly Gejala gejala = new Gejala();
        private int idPenyakit;
        private int idGejala;

        // agar form draggable walaupun borderless
        private bool mousedown;
        private Point offset;
        #endregion

        #region Konstruktor
        public FormAturanGejala()
        {
            InitializeComponent();
        }
        #endregion

        #region Method
        private void DisplayData()
        {
            try
            {
                dataGridView1.DataSource = aturan.GetAturanGejala();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IsiComboBox()
        {
            comboBoxPenyakit.DataSource = penyakit.GetListNamaPenyakit();
            comboBoxGejala.DataSource = gejala.GetListDetailGejala();
        }

        private void Reset()
        {
            comboBoxPenyakit.SelectedItem = null;
            comboBoxGejala.SelectedItem = null;

            idPenyakit = 0;
            idGejala = 0;

            buttonTambah.Enabled = true;
            buttonHapus.Enabled = false;
        }
        #endregion

        #region Event

        #region Event UI
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
        #endregion

        private void FormAturanGejala_Load(object sender, EventArgs e)
        {
            comboBoxPenyakit.Items.Clear();
            comboBoxGejala.Items.Clear();

            IsiComboBox();
            Reset();
            DisplayData();

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPenyakit.SelectedItem != null && comboBoxGejala.SelectedItem != null)
                {
                    if (aturan.Tambah(idPenyakit, idGejala))
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
                    MessageBox.Show("Data aturan tidak boleh kosong! Silakan pilih data yang akan ditambahkan");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Source + "\n" + ex.StackTrace + "\n" + ex.Message + "\n" + ex.HelpLink); }
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
                    if (aturan.Hapus(idPenyakit, idGejala))
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
            comboBoxGejala.Text = "";
            comboBoxPenyakit.Text = "";

            int baris = e.RowIndex;
            if (baris >= 0)
            {
                buttonTambah.Enabled = false;
                buttonHapus.Enabled = true;

                idPenyakit = (int)dataGridView1.Rows[baris].Cells[0].Value;
                idGejala = (int)dataGridView1.Rows[baris].Cells[1].Value;

                comboBoxPenyakit.Text = penyakit.GetNamaBerdasarkan(idPenyakit);
                comboBoxGejala.Text = gejala.GetDetailGejala(idGejala);
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aturan.GetAturanGejala(tbCari.Text);
        }

        private void comboBoxPenyakit_Click(object sender, EventArgs e)
        {
            buttonTambah.Enabled = true;
            buttonHapus.Enabled = false;
        }

        private void comboBoxPenyakit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPenyakit.SelectedItem != null)
                idPenyakit = penyakit.GetIdBerdasarkan(comboBoxPenyakit.SelectedItem.ToString());
        }

        private void comboBoxGejala_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGejala.SelectedItem != null)
                idGejala = gejala.GetIdBerdasarkan(comboBoxGejala.SelectedItem.ToString());
        }
        #endregion

        private void FormAturanGejala_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
