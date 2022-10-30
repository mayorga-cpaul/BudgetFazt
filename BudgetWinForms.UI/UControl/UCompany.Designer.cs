namespace BudgetWinForms.UI.UControl
{
    partial class UCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCompany));
            this.nightLabel4 = new ReaLTaiizor.Controls.NightLabel();
            this.txtName = new ReaLTaiizor.Controls.NightLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nightLabel4
            // 
            this.nightLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nightLabel4.AutoSize = true;
            this.nightLabel4.BackColor = System.Drawing.Color.Transparent;
            this.nightLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nightLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(192)))));
            this.nightLabel4.Location = new System.Drawing.Point(105, 20);
            this.nightLabel4.Name = "nightLabel4";
            this.nightLabel4.Size = new System.Drawing.Size(137, 20);
            this.nightLabel4.TabIndex = 18;
            this.nightLabel4.Text = "Nombre compañia:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.AutoSize = true;
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(153)))), ((int)(((byte)(192)))));
            this.txtName.Location = new System.Drawing.Point(248, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(55, 20);
            this.txtName.TabIndex = 19;
            this.txtName.Text = "<Test>";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // UCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.nightLabel4);
            this.Name = "UCompany";
            this.Size = new System.Drawing.Size(351, 68);
            this.Load += new System.EventHandler(this.UCompany_Load);
            this.Click += new System.EventHandler(this.UCompany_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.NightLabel nightLabel4;
        private ReaLTaiizor.Controls.NightLabel txtName;
        private PictureBox pictureBox1;
    }
}
