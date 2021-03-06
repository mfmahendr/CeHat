using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Validation;

namespace cehat
{


    public partial class FormDataAdmin : Form
    {
         private readonly Admin admin = new Admin();
        private int id;
        
        // agar form draggable walaupun borderless
        bool mousedown;
        private Point offset;

        public FormDataAdmin()
        {
            InitializeComponent();
        }

        private void DisplayData()
        {
            try
            {
                dataGridView1.DataSource = admin.GetListSemuaDataBerdasarkan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            tbCari.Text = "";

            buttonTambah.Enabled = true;
            buttonUbah.Enabled = false;
            buttonHapus.Enabled = false;
        }
       
        private void FormDataAdmin_Load(object sender, EventArgs e)
        {
            DisplayData();
            Reset();

            dataGridView1.Columns[0].Width = 30;
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    if (admin.Tambah(textBox1.Text, textBox2.Text))
                    {
                        MessageBox.Show("Admin baru berhasil ditambahkan!");
                    }
                    else
                    {
                        MessageBox.Show("Username sudah digunakan, coba lagi!");
                    }

                    Reset();
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Username dan password tidak boleh kosong!");
                }
        }
            catch (DbEntityValidationException) { MessageBox.Show("Data informasinya tidak boleh kosong dan tidak boleh didahului spasi"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {

                    if (admin.Ubah(id, textBox1.Text, textBox2.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!");
                    }
                    else { MessageBox.Show("Data gagal diubah!"); }
                }
                else if (textBox1.Text != "")
                {

                    if (admin.Ubah(id, username: textBox1.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!");
                    }
                    else { MessageBox.Show("Data gagal diubah!"); }
                }
                else if (textBox2.Text != "")
                {
                    if (admin.Ubah(id, password: textBox2.Text))
                    {
                        MessageBox.Show("Data berhasil diubah!");
                    }
                    else { MessageBox.Show("Data gagal diubah!"); }
                }
                else
                {
                    MessageBox.Show("Username atau password harus diisi");
                }

                DisplayData();
                Reset();
            }
            catch (DbEntityValidationException) { MessageBox.Show("Data informasinya tidak boleh kosong dan tidak boleh didahului spasi"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
                    if (admin.Hapus(Id: id))
                    {
                        DisplayData();
                        Reset();
                        MessageBox.Show("Data berhasil dihapus!");
                    }
                }
                    
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + "\n" + ex.StackTrace); }
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
            this.Hide();
            FormMenuAdmin menu = new FormMenuAdmin();
            menu.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Reset();
            DisplayData();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            buttonTambah.Enabled = true;
            buttonHapus.Enabled = false;
            buttonUbah.Enabled = false;

            if (e.RowIndex >= 0)
            {
                buttonTambah.Enabled = false;
                buttonHapus.Enabled = true;
                buttonUbah.Enabled = true;

                id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void tbCari_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Akses.Tabel().Admins.Where(y => y.Username.Contains(tbCari.Text) || y.Password.Contains(tbCari.Text)).ToList();
        }

        private void FormDataAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
