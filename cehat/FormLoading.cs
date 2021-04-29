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
        public FormLoading()
        {
            InitializeComponent();
        }
        private void FormLoading_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= 759)
            {
                timer1.Stop();
                FormLogin login = new FormLogin();
                login.Show();
                this.Hide();
            }
        }

        
    }
}