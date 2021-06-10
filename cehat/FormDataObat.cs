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
    public partial class FormDataObat : Form
    {
        private readonly Obat obat = new Obat();
        private int id;

        // agar form draggable walaupun borderless
        private bool mousedown;
        private Point offset;

        public FormDataObat()
        {
            InitializeComponent();
        }

        private void displayData()
        {
            try
            {
                dataGridView1.DataSource = Akses.Tabel().Obats.
                                           Select(x => new { x.Id, x.Nama, Dosis = x.DosisObat, EfekSamping = x.EfekObat })
                                           .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void resetTb()
        {
            textBoxNamaObat.Text = "";
            textBoxDosisObat.Text = "";
            textBoxEfekSamping.Text = "";

            buttonTambah.Enabled = true;
            buttonUbah.Enabled = false;
            buttonHapus.Enabled = false;
        }

       
        private void FormDataObat_Load(object sender, EventArgs e)
        {
            displayData();
            resetTb();

            lblCari.BackColor = System.Drawing.Color.Transparent;
            dataGridView1.Columns[0].Width = 5;
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNamaObat.Text != "" && textBoxDosisObat.Text != "" && textBoxEfekSamping.Text != "")
                {
                    if (obat.Tambah(textBoxNamaObat.Text, textBoxDosisObat.Text, textBoxEfekSamping.Text))
                    {
                        MessageBox.Show("Obat baru berhasil ditambahkan!");
                    }
                    else { MessageBox.Show("Obat baru gagal ditambahkan, kemungkinan karena obat yang ditambahkan sudah ada"); }

                }
                else if (textBoxNamaObat.Text != "" && textBoxDosisObat.Text != "")
                {
                    if (obat.Tambah(namaObat: textBoxNamaObat.Text, dosis: textBoxDosisObat.Text))
                    {
                        MessageBox.Show("Obat baru berhasil ditambahkan!");
                    }
                    else { MessageBox.Show("Obat baru gagal ditambahkan, kemungkinan karena obat yang ditambahkan sudah ada"); }
                }
                else if (textBoxNamaObat.Text != "" && textBoxEfekSamping.Text != "")
                {
                    if (obat.Tambah(namaObat: textBoxNamaObat.Text, efek: textBoxEfekSamping.Text))
                    {
                        MessageBox.Show("Obat baru berhasil ditambahkan!");
                    }
                    else { MessageBox.Show("Obat baru gagal ditambahkan, kemungkinan karena obat yang ditambahkan sudah ada"); }
                }
                else if (textBoxNamaObat.Text != "")
                {
                    if (obat.Tambah(namaObat: textBoxNamaObat.Text))
                    {
                        MessageBox.Show("Obat baru berhasil ditambahkan!");
                    }
                    else { MessageBox.Show("Obat baru gagal ditambahkan, kemungkinan karena obat yang ditambahkan sudah ada"); }
                }
                else
                {
                    MessageBox.Show("Data informasinya tidak boleh kosong!");
                }
            }
            catch (DbEntityValidationException) { MessageBox.Show("Data informasinya tidak boleh kosong dan tidak boleh didahului spasi"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            resetTb();
            displayData();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            resetTb();
            displayData();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNamaObat.Text != "" && textBoxDosisObat.Text != "" && textBoxEfekSamping.Text != "")
                {
                    if (obat.Ubah(id, namaObat: textBoxNamaObat.Text, dosis: textBoxDosisObat.Text, efek: textBoxEfekSamping.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!"); MessageBox.Show("1");
                    }
                    else { MessageBox.Show("Data gagal diubah, kemungkinan karena data yang ditambahkan sudah ada"); }
                }
                else if (textBoxNamaObat.Text != "" && textBoxDosisObat.Text != "")
                {
                    if (obat.Ubah(id, namaObat: textBoxNamaObat.Text, dosis: textBoxDosisObat.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!"); MessageBox.Show("2");
                    }
                    else { MessageBox.Show("Data gagal diubah, kemungkinan karena data yang ditambahkan sudah ada"); }
                }
                else if (textBoxNamaObat.Text != "" && textBoxEfekSamping.Text != "")
                {
                    if (obat.Ubah(id, namaObat: textBoxNamaObat.Text, efek: textBoxEfekSamping.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!"); MessageBox.Show("3");
                    }
                    else { MessageBox.Show("Data gagal diubah, kemungkinan karena data yang ditambahkan sudah ada"); }
                }
                else if (textBoxDosisObat.Text != "" && textBoxEfekSamping.Text != "")
                {
                    if (obat.Ubah(id, dosis: textBoxDosisObat.Text, efek: textBoxEfekSamping.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!"); MessageBox.Show("4");
                    }
                    else { MessageBox.Show("Data gagal diubah, kemungkinan karena data yang ditambahkan sudah ada"); }
                }
                else if (textBoxNamaObat.Text != "")
                {
                    if (obat.Ubah(id, namaObat: textBoxNamaObat.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!"); MessageBox.Show("5");
                    }
                    else { MessageBox.Show("Data gagal diubah, kemungkinan karena data yang ditambahkan sudah ada"); }
                }
                else if (textBoxDosisObat.Text != "")
                {
                    if (obat.Ubah(id, dosis: textBoxDosisObat.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!"); MessageBox.Show("6");
                    }
                    else { MessageBox.Show("Data gagal diubah, kemungkinan karena data yang ditambahkan sudah ada"); }
                }
                else if (textBoxEfekSamping.Text != "")
                {
                    if (obat.Ubah(id, efek: textBoxEfekSamping.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!"); MessageBox.Show("7");
                    }
                    else { MessageBox.Show("Data gagal diubah, kemungkinan karena data yang ditambahkan sudah ada"); }
                }
                else
                {
                    MessageBox.Show("Isi data yang ingin Anda ubah. Jika tidak ingin mengubah elemen data tertentu maka kosongkan isiannya.");
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
                if (obat.Hapus(id: id))
                {
                    displayData();
                    resetTb();
                    MessageBox.Show("Data berhasil dihapus!");
                }
                else { MessageBox.Show("Data gagal dihapus!"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "\n" + ex.StackTrace); }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormMenuAdmin menu = new FormMenuAdmin();
            menu.Show();
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxNamaObat.Text = "";
            textBoxDosisObat.Text = "";
            textBoxEfekSamping.Text = "";
            buttonTambah.Enabled = true;
            buttonHapus.Enabled = false;
            buttonUbah.Enabled = false;

            int baris = e.RowIndex;
            if (baris >= 0)
            {
                buttonTambah.Enabled = false;
                buttonHapus.Enabled = true;
                buttonUbah.Enabled = true;

                id = (int)dataGridView1.Rows[baris].Cells[0].Value;
                textBoxNamaObat.Text = dataGridView1.Rows[baris].Cells[1].Value.ToString();

                if(dataGridView1.Rows[baris].Cells[2].Value != null)
                {
                    textBoxDosisObat.Text = dataGridView1.Rows[baris].Cells[2].Value.ToString();
                }

                if (dataGridView1.Rows[baris].Cells[3].Value != null)
                {
                    textBoxEfekSamping.Text = dataGridView1.Rows[baris].Cells[3].Value.ToString();
                }
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Akses.Tabel().Obats
                                       .Where(x => x.Nama.Contains(tbCari.Text) || x.DosisObat.Contains(tbCari.Text) || x.EfekObat.Contains(tbCari.Text))
                                       .Select(x => new { x.Id, x.Nama, Dosis = x.DosisObat, EfekSamping = x.EfekObat }).ToList();
        }
    }
}
