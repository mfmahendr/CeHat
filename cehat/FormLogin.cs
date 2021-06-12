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
    public partial class FormLogin : Form
    {
        bool mousedown;
        private Point offset;
        
        public FormLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormLoginAdmin login_admin = new FormLoginAdmin();
            login_admin.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormLoginUser login_user = new FormLoginUser();
            login_user.Show();
            this.Hide();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mousedown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mousedown == true)
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
            this.Close();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
