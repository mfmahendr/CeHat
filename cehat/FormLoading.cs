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
    public partial class FormLoading : Form
    {
        #region Atribut
        // agar form draggable walaupun borderless
        bool mousedown;
        private Point offset;
        #endregion

        #region Constructor
        public FormLoading()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
        private void FormLoading_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            pictureBox1.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 5;
            if (panel2.Width >= 800)
            {
                timer1.Stop();
                Cursor = Cursors.Default;
                pictureBox1.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Hide();
        }

        private void FormLoading_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mousedown = true;
        }

        private void FormLoading_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown == true)
            {
                Point currentSceenPos = PointToScreen(e.Location);
                Location = new Point(currentSceenPos.X - offset.X, currentSceenPos.Y - offset.Y);
            }
        }

        private void FormLoading_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }
        #endregion
    }
}