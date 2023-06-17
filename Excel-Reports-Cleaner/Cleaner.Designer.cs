namespace Excel_Reports_Cleaner
{
    partial class frmCleaner
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.pbLoad = new System.Windows.Forms.PictureBox();
            this.pbClean = new System.Windows.Forms.PictureBox();
            this.pBarClean = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClean)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // tbFile
            // 
            this.tbFile.Enabled = false;
            this.tbFile.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFile.Location = new System.Drawing.Point(57, 33);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(321, 22);
            this.tbFile.TabIndex = 1;
            // 
            // pbLoad
            // 
            this.pbLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLoad.Image = global::Excel_Reports_Cleaner.Properties.Resources.folder;
            this.pbLoad.Location = new System.Drawing.Point(384, 12);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(50, 53);
            this.pbLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoad.TabIndex = 2;
            this.pbLoad.TabStop = false;
            this.pbLoad.Click += new System.EventHandler(this.pbCargar_Click);
            // 
            // pbClean
            // 
            this.pbClean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClean.Enabled = false;
            this.pbClean.Image = global::Excel_Reports_Cleaner.Properties.Resources.broom;
            this.pbClean.Location = new System.Drawing.Point(384, 86);
            this.pbClean.Name = "pbClean";
            this.pbClean.Size = new System.Drawing.Size(50, 53);
            this.pbClean.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClean.TabIndex = 3;
            this.pbClean.TabStop = false;
            this.pbClean.Click += new System.EventHandler(this.pbClean_Click);
            // 
            // pBarClean
            // 
            this.pBarClean.Location = new System.Drawing.Point(16, 101);
            this.pBarClean.Name = "pBarClean";
            this.pBarClean.Size = new System.Drawing.Size(362, 23);
            this.pBarClean.TabIndex = 4;
            // 
            // frmCleaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 160);
            this.Controls.Add(this.pBarClean);
            this.Controls.Add(this.pbClean);
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmCleaner";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel Reports Cleaner";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCleaner_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClean)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.PictureBox pbLoad;
        private System.Windows.Forms.PictureBox pbClean;
        private System.Windows.Forms.ProgressBar pBarClean;
    }
}

