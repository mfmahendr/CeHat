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
        private readonly Gejala gejala = new Gejala();
        private int id;

        // agar form draggable walaupun borderless
        bool mousedown;
        private Point offset;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mousedown = true;
        }

        public FormDataGejala()
        {
            InitializeComponent();
        }

        private void DisplayData()
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

        private void Reset()
        {
            textBox1.Text = "";

            buttonTambah.Enabled = true;
            buttonUbah.Enabled = false;
            buttonHapus.Enabled = false;
        }

        
        private void FormDataGejala_Load(object sender, EventArgs e)
        {
            DisplayData();
            Reset();

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

                    Reset();
                    DisplayData();
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
                    DisplayData();
                    Reset();
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
                string message = "Yakin ingin hapus data?";
                string caption = "Konfirmasi";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (gejala.Hapus(id: id))
                    {
                        DisplayData();
                        Reset();
                        MessageBox.Show("Data berhasil dihapus!");
                    }
                    else { MessageBox.Show("Data gagal dihapus!"); }
                }
                    
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "\n" + ex.StackTrace); }
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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Reset();
            DisplayData();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = "";
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
                textBox1.Text = dataGridView1.Rows[baris].Cells[1].Value.ToString();
            }
            
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Akses.Tabel().Gejalas.Where(x => x.DetailGejala.Contains(tbCari.Text))
                                       .Select(x => new { x.Id, Gejala = x.DetailGejala }).ToList();
        }

        private void FormDataGejala_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

