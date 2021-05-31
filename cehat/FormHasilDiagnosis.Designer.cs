
namespace cehat
{
    partial class FormHasilDiagnosis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHasilDiagnosis));
            this.tbNamaPenyakit = new System.Windows.Forms.TextBox();
            this.tbDeskripsiPenyakit = new System.Windows.Forms.TextBox();
            this.tbNamaObat = new System.Windows.Forms.TextBox();
            this.tbDosis = new System.Windows.Forms.TextBox();
            this.tbEfekSamping = new System.Windows.Forms.TextBox();
            this.buttonUlangi = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNamaPenyakit
            // 
            this.tbNamaPenyakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbNamaPenyakit.Location = new System.Drawing.Point(34, 145);
            this.tbNamaPenyakit.Name = "tbNamaPenyakit";
            this.tbNamaPenyakit.Size = new System.Drawing.Size(312, 30);
            this.tbNamaPenyakit.TabIndex = 0;
            // 
            // tbDeskripsiPenyakit
            // 
            this.tbDeskripsiPenyakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbDeskripsiPenyakit.Location = new System.Drawing.Point(34, 207);
            this.tbDeskripsiPenyakit.Multiline = true;
            this.tbDeskripsiPenyakit.Name = "tbDeskripsiPenyakit";
            this.tbDeskripsiPenyakit.Size = new System.Drawing.Size(312, 190);
            this.tbDeskripsiPenyakit.TabIndex = 1;
            // 
            // tbNamaObat
            // 
            this.tbNamaObat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbNamaObat.Location = new System.Drawing.Point(448, 145);
            this.tbNamaObat.Name = "tbNamaObat";
            this.tbNamaObat.Size = new System.Drawing.Size(312, 30);
            this.tbNamaObat.TabIndex = 2;
            // 
            // tbDosis
            // 
            this.tbDosis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbDosis.Location = new System.Drawing.Point(448, 207);
            this.tbDosis.Multiline = true;
            this.tbDosis.Name = "tbDosis";
            this.tbDosis.Size = new System.Drawing.Size(312, 81);
            this.tbDosis.TabIndex = 3;
            // 
            // tbEfekSamping
            // 
            this.tbEfekSamping.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbEfekSamping.Location = new System.Drawing.Point(448, 323);
            this.tbEfekSamping.Multiline = true;
            this.tbEfekSamping.Name = "tbEfekSamping";
            this.tbEfekSamping.Size = new System.Drawing.Size(312, 74);
            this.tbEfekSamping.TabIndex = 4;
            // 
            // buttonUlangi
            // 
            this.buttonUlangi.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonUlangi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUlangi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUlangi.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.buttonUlangi.ForeColor = System.Drawing.Color.White;
            this.buttonUlangi.Location = new System.Drawing.Point(539, 414);
            this.buttonUlangi.Name = "buttonUlangi";
            this.buttonUlangi.Size = new System.Drawing.Size(103, 39);
            this.buttonUlangi.TabIndex = 19;
            this.buttonUlangi.Text = "Ulangi";
            this.buttonUlangi.UseVisualStyleBackColor = false;
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.buttonMenu.ForeColor = System.Drawing.Color.White;
            this.buttonMenu.Location = new System.Drawing.Point(657, 414);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(103, 39);
            this.buttonMenu.TabIndex = 20;
            this.buttonMenu.Text = "Menu";
            this.buttonMenu.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 32);
            this.panel1.TabIndex = 42;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(772, 4);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 41;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // FormHasilDiagnosis
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.buttonUlangi);
            this.Controls.Add(this.tbEfekSamping);
            this.Controls.Add(this.tbDosis);
            this.Controls.Add(this.tbNamaObat);
            this.Controls.Add(this.tbDeskripsiPenyakit);
            this.Controls.Add(this.tbNamaPenyakit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHasilDiagnosis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHasilDiagnosis";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNamaPenyakit;
        private System.Windows.Forms.TextBox tbDeskripsiPenyakit;
        private System.Windows.Forms.TextBox tbNamaObat;
        private System.Windows.Forms.TextBox tbDosis;
        private System.Windows.Forms.TextBox tbEfekSamping;
        private System.Windows.Forms.Button buttonUlangi;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}