namespace BudgetWinForms.UI.UControl
{
    partial class UCAddBudget
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAddBudget));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nightLabel4 = new ReaLTaiizor.Controls.NightLabel();
            this.nightLabel1 = new ReaLTaiizor.Controls.NightLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // nightLabel4
            // 
            this.nightLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nightLabel4.AutoSize = true;
            this.nightLabel4.BackColor = System.Drawing.Color.Transparent;
            this.nightLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nightLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nightLabel4.Location = new System.Drawing.Point(9, 90);
            this.nightLabel4.Name = "nightLabel4";
            this.nightLabel4.Size = new System.Drawing.Size(67, 20);
            this.nightLabel4.TabIndex = 19;
            this.nightLabel4.Text = "Nombre:";
            // 
            // nightLabel1
            // 
            this.nightLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nightLabel1.AutoSize = true;
            this.nightLabel1.BackColor = System.Drawing.Color.Transparent;
            this.nightLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nightLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nightLabel1.Location = new System.Drawing.Point(9, 110);
            this.nightLabel1.Name = "nightLabel1";
            this.nightLabel1.Size = new System.Drawing.Size(67, 20);
            this.nightLabel1.TabIndex = 20;
            this.nightLabel1.Text = "Nombre:";
            // 
            // UCAddBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.Controls.Add(this.nightLabel1);
            this.Controls.Add(this.nightLabel4);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UCAddBudget";
            this.Size = new System.Drawing.Size(142, 150);
            this.Click += new System.EventHandler(this.UCAddBudget_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.NightLabel nightLabel4;
        private ReaLTaiizor.Controls.NightLabel nightLabel1;
    }
}
