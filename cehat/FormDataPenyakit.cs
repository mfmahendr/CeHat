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
    public partial class FormDataPenyakit : Form
    {
        // agar form draggable walaupun borderless
        private bool mousedown;
        private Point offset;

        private int id;

        private Penyakit penyakit = new Penyakit();

        public FormDataPenyakit()
        {
            InitializeComponent();
        }

        private void displayData()
        {
            try
            {
                dataGridView1.DataSource = Akses.Tabel().Penyakits.Select(x => new { x.Id, x.Nama, Detail = x.DetailPenyakit }).ToList();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void resetTb()
        {
            textBoxNamaPenyakit.Text = "";
            textBoxDeskripsi.Text = "";

            buttonTambah.Enabled = true;
            buttonUbah.Enabled = false;
            buttonHapus.Enabled = false;

        }

        private void FormDataPenyakit_Load(object sender, EventArgs e)
        {
            displayData();
            resetTb();

            lblCari.BackColor = System.Drawing.Color.Transparent;
            dataGridView1.Columns[0].Width = 30;
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNamaPenyakit.Text != "" && textBoxDeskripsi.Text != "")
                {
                    if (penyakit.Tambah(textBoxNamaPenyakit.Text, textBoxDeskripsi.Text))
                    {
                        MessageBox.Show("Penyakit baru berhasil ditambahkan!");
                    }
                    else { MessageBox.Show("Penyakit baru gagal ditambahkan, kemungkinan karena penyakit yang ditambahkan sudah ada"); }

                    resetTb();
                    displayData();
                }
                else
                {
                    MessageBox.Show("Data penyakit dan detail informasinya tidak boleh kosong!");
                }
            }
            catch (DbEntityValidationException) { MessageBox.Show("Data informasinya tidak boleh kosong dan tidak boleh didahului spasi"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            displayData();
            resetTb();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNamaPenyakit.Text != "" && textBoxDeskripsi.Text != "")
                {
                    if (penyakit.Ubah(id, textBoxNamaPenyakit.Text, textBoxDeskripsi.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!");
                    }
                    else { MessageBox.Show("Data gagal diubah, kemungkinan karena penyakit yang ditambahkan sudah ada"); }
                }
                else if (textBoxNamaPenyakit.Text != "")
                {
                    if (penyakit.Ubah(id, penyakit: textBoxNamaPenyakit.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!");
                    }
                    else { MessageBox.Show("Data gagal diubah, kemungkinan karena penyakit yang ditambahkan sudah ada"); }
                }
                else if (textBoxDeskripsi.Text != "")
                {
                    if (penyakit.Ubah(id, detailBaru: textBoxDeskripsi.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!");
                    }
                    else { MessageBox.Show("Data gagal diubah, kemungkinan karena penyakit yang ditambahkan sudah ada"); }
                }
                else
                {
                    MessageBox.Show("Nama penyakit dan detailnya harus diisi!");
                }
            }
            catch (DbEntityValidationException) { MessageBox.Show("Data informasinya tidak boleh kosong dan tidak boleh didahului spasi"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            displayData();
            resetTb();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (penyakit.Hapus(id: id))
                {
                    displayData();
                    resetTb();
                    MessageBox.Show("Data berhasil dihapus!");
                }
                else { MessageBox.Show("Data gagal dihapus!"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "\n" + ex.StackTrace); }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuAdmin menu = new FormMenuAdmin();
            menu.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;
            if (baris >= 0 && kolom == 0)
            {
                buttonTambah.Enabled = false;
                buttonHapus.Enabled = true;
                buttonUbah.Enabled = true;

                id = (int)dataGridView1.Rows[baris].Cells[0].Value;
                textBoxNamaPenyakit.Text = dataGridView1.Rows[baris].Cells[1].Value.ToString();
                textBoxDeskripsi.Text = dataGridView1.Rows[baris].Cells[2].Value.ToString();
            }
            else
            {
                textBoxNamaPenyakit.Text = "";
                textBoxDeskripsi.Text = "";
                buttonTambah.Enabled = true;
                buttonHapus.Enabled = false;
                buttonUbah.Enabled = false;
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Akses.Tabel().Penyakits
                                       .Where(x => x.Nama.Contains(tbCari.Text) || x.DetailPenyakit.Contains(tbCari.Text))
                                       .Select(x => new { x.Id, x.Nama, Detail = x.DetailPenyakit }).ToList();
        }
    }
}
