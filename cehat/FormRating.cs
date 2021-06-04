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
        
        // agar form draggable walaupun borderless
        bool mousedown;
        private Point offset;
        
        public FormRating()
        {
            InitializeComponent();
        }

        private void average()
        {
            using (SqlConnection con = new SqlConnection(path))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select cast(avg(Rating) as decimal (10,2)) from Rating";
                cmd.ExecuteNonQuery();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    label1.Text = dr.GetValue(0).ToString();
                }


                con.Close();
            }
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

            average();
            reset();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            Rating rate = new Rating();
            rate.RatingAplikasi = int.Parse(comboBox1.Text);
            rate.KritikSaran = textBox1.Text;

            if (comboBox1.Text.ToString() != "" && textBox1.Text!= "")
            {
                using (SqlConnection con = new SqlConnection(path))
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Rating values('"+rate.RatingAplikasi+"', '" + rate.KritikSaran + "')";
                    cmd.ExecuteNonQuery();

                    con.Close();
                }

                average();
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
