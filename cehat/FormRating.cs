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
    public partial class FormRating : Form
    {
        string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBCehat.mdf;Integrated Security=True";
<<<<<<< HEAD
        
        // agar form draggable walaupun borderless
        bool mousedown;
        private Point offset;
        
=======
        private Rating rating = new Rating();
>>>>>>> dfcd46c0418fa8f6cab4ab14403513cbbbae4306
        public FormRating()
        {
            InitializeComponent();
        }

        private void reset()
        {
            textBox1.Text = "";
            comboBox1.SelectedItem = null;
        }
        private void FormRating_Load(object sender, EventArgs e)
        {
            List<int> listRating = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            comboBox1.Items.Add(listRating);

            label1.Text = Convert.ToString(rating.Rataan());
            reset();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.ToString() != "" && textBox1.Text!= "")
            {
                rating.Tambah(int.Parse(comboBox1.Text), textBox1.Text);

                label1.Text = Convert.ToString(rating.Rataan());
                reset();
                MessageBox.Show("Terimakasih atas evaluasinya!");
            }
            else
            {
                MessageBox.Show("Data rating tidak boleh kosong!");
            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMenuUser menu = new FormMenuUser();
            menu.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
