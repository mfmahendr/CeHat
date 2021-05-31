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
    public partial class FormAturanGejala : Form
    {
        //AturanGejala aturan = new AturanGejala();
        public FormAturanGejala()
        {
            InitializeComponent();
        }

        private void DisplayData()
        {
            try
            {
                //dataGridView1.DataSource = Aturan.GetAturanGejala();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IsiComboBox()
        {
            comboBoxPenyakit.DataSource = Akses.Tabel().Penyakits.Select(x => x.Nama).ToList();
            comboBoxGejala.DataSource = Akses.Tabel().Gejalas.Select(x => x.DetailGejala).ToList();
        }

        private void ResetTb()
        {
            comboBoxPenyakit.SelectedItem = null;
            comboBoxGejala.SelectedItem = null;

            buttonTambah.Enabled = true;

            buttonHapus.Enabled = false;
        }

        private void FormAturanGejala_Load(object sender, EventArgs e)
        {
            comboBoxPenyakit.Items.Clear();
            comboBoxGejala.Items.Clear();

            IsiComboBox();
            ResetTb();
            DisplayData();

            lblCari.BackColor = System.Drawing.Color.Transparent;
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            if (comboBoxPenyakit.Text.ToString() != "" && comboBoxGejala.Text.ToString() != "")
            {
                //using (SqlConnection con = new SqlConnection(path))
                //{
                //    aturan.IdPenyakit = int.Parse(comboBoxPenyakit.Text);
                //    aturan.IdGejala = int.Parse(comboBoxGejala.Text.ToString());

                //    con.Open();

                //    SqlCommand cmd = con.CreateCommand();
                //    cmd.CommandType = CommandType.Text;
                //    cmd.CommandText = "insert into AturanGejala values('" + aturan.IdPenyakit + "', '" + aturan.IdPenyakit + "')";
                //    cmd.ExecuteNonQuery();

                //    con.Close();
                //}

                ResetTb();
                DisplayData();
                MessageBox.Show("Aturan baru berhasil ditambahkan!");
            }
            else
            {
                MessageBox.Show("Data aturan tidak boleh kosong!");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            ResetTb();
            DisplayData();
        }

        private void cbCariPenyakit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //using (SqlConnection con = new SqlConnection(path))
            //{
            //    con.Open();

            //    SqlCommand cmd = con.CreateCommand();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "select DetailGejala from AturanGejala where NamaPenyakit = '" + cbCariPenyakit.Text.ToString() + "'";
            //    cmd.ExecuteNonQuery();

            //    DataTable dt = new DataTable();
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    da.Fill(dt);

            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        comboBoxGejala.Items.Add(dr["DetailGejala"].ToString()); //////////////////////////////////////////////////
            //    }

            //    con.Close();
            //}
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            //using (SqlConnection con = new SqlConnection(path))
            //{
            //    con.Open();

            //    SqlCommand cmd = con.CreateCommand();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "delete from AturanGejala where NamaPenyakit = '" + aturan.IdPenyakit + "' and DetailGejala = '" + aturan.IdGejala + "'";
            //    cmd.ExecuteNonQuery();

            //    displayData();
            //    resetTb();
            //    MessageBox.Show("Data berhasil dihapus!");

            //    con.Close();
            //}
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

        private void tbCari_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
