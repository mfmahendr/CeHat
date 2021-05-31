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
    public partial class FormDataGejala : Form
    {
        private Gejala gejala = new Gejala();
        private int id;

        public FormDataGejala()
        {
            InitializeComponent();
        }

        private void displayData()
        {
            try
            {
                dataGridView1.DataSource = Akses.Tabel().Gejalas.Select(x => new { x.Id, Gejala = x.DetailGejala }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void resetTb()
        {
            textBox1.Text = "";

            buttonTambah.Enabled = true;
            buttonUbah.Enabled = false;
            buttonHapus.Enabled = false;
        }

        
        private void FormDataGejala_Load(object sender, EventArgs e)
        {
            displayData();
            resetTb();

            lblCari.BackColor = System.Drawing.Color.Transparent;
            dataGridView1.Columns[0].Width = 50;
        }

        
        private void buttonTambah_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    if (gejala.Tambah(textBox1.Text))
                    {
                        MessageBox.Show("Gejala baru berhasil ditambahkan!");
                    }
                    else { MessageBox.Show("Gejala baru gagal ditambahkan, kemungkinan karena gejala yang ditambahkan sudah ada"); }

                    resetTb();
                    displayData();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("Gejala tidak boleh kosong!");
            }
        }


        private void buttonUbah_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                
                if (gejala.Ubah(id, textBox1.Text))
                {
                    MessageBox.Show("Data berhasil diubah!");
                    displayData();
                    resetTb();
                }
                else { MessageBox.Show("Data gagal diubah, kemungkinan karena gejala yang ditambahkan sudah ada"); }
            }
            else
            {
                MessageBox.Show("Detail gejala harus diisi!");
            }            
        }


        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (gejala.Hapus(id: id))
                {
                    displayData();
                    resetTb();
                    MessageBox.Show("Data berhasil dihapus!");
                }
                else { MessageBox.Show("Data gagal dihapus!"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "\n" + ex.StackTrace); }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMenuAdmin menu = new FormMenuAdmin();
            menu.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            resetTb();
            displayData();
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
                textBox1.Text = dataGridView1.Rows[baris].Cells[1].Value.ToString();
            }
            else
            {
                textBox1.Text = "";
                buttonTambah.Enabled = true;
                buttonHapus.Enabled = false;
                buttonUbah.Enabled = false;
            }
            
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Akses.Tabel().Gejalas.Where(x => x.DetailGejala.Contains(tbCari.Text))
                                       .Select(x => new { x.Id, Gejala = x.DetailGejala }).ToList();
        }
    }
}

