namespace BudgetWinForms.UI.Views
{
    partial class FrmGestionProject
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgProjects = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisableProject = new ReaLTaiizor.Controls.NightButton();
            this.btnEnableProject = new ReaLTaiizor.Controls.NightButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgProjects
            // 
            this.dtgProjects.AllowUserToResizeRows = false;
            this.dtgProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgProjects.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtgProjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgProjects.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgProjects.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgProjects.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgProjects.ColumnHeadersHeight = 39;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgProjects.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgProjects.EnableHeadersVisualStyles = false;
            this.dtgProjects.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dtgProjects.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dtgProjects.Location = new System.Drawing.Point(35, 71);
            this.dtgProjects.MultiSelect = false;
            this.dtgProjects.Name = "dtgProjects";
            this.dtgProjects.ReadOnly = true;
            this.dtgProjects.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgProjects.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgProjects.RowHeadersWidth = 51;
            this.dtgProjects.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgProjects.RowTemplate.Height = 29;
            this.dtgProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProjects.Size = new System.Drawing.Size(707, 276);
            this.dtgProjects.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(58, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "Gestionar";
            // 
            // btnDisableProject
            // 
            this.btnDisableProject.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDisableProject.BackColor = System.Drawing.Color.Transparent;
            this.btnDisableProject.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDisableProject.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDisableProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDisableProject.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDisableProject.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDisableProject.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.btnDisableProject.Location = new System.Drawing.Point(394, 378);
            this.btnDisableProject.MinimumSize = new System.Drawing.Size(144, 47);
            this.btnDisableProject.Name = "btnDisableProject";
            this.btnDisableProject.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDisableProject.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.btnDisableProject.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDisableProject.PressedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnDisableProject.Radius = 20;
            this.btnDisableProject.Size = new System.Drawing.Size(240, 53);
            this.btnDisableProject.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.btnDisableProject.TabIndex = 47;
            this.btnDisableProject.Text = "Inhabilitar proyecto";
            this.btnDisableProject.Click += new System.EventHandler(this.btnDisableProject_Click);
            // 
            // btnEnableProject
            // 
            this.btnEnableProject.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEnableProject.BackColor = System.Drawing.Color.Transparent;
            this.btnEnableProject.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEnableProject.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEnableProject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnEnableProject.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnEnableProject.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnEnableProject.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.btnEnableProject.Location = new System.Drawing.Point(148, 378);
            this.btnEnableProject.MinimumSize = new System.Drawing.Size(144, 47);
            this.btnEnableProject.Name = "btnEnableProject";
            this.btnEnableProject.NormalBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnEnableProject.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.btnEnableProject.PressedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnEnableProject.PressedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnEnableProject.Radius = 20;
            this.btnEnableProject.Size = new System.Drawing.Size(240, 53);
            this.btnEnableProject.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.btnEnableProject.TabIndex = 48;
            this.btnEnableProject.Text = "Habilitar proyecto";
            this.btnEnableProject.Click += new System.EventHandler(this.btnEnableProject_Click);
            // 
            // FrmGestionProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(775, 457);
            this.Controls.Add(this.btnEnableProject);
            this.Controls.Add(this.btnDisableProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgProjects);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmGestionProject";
            this.Text = "FrmGestionProject";
            this.Load += new System.EventHandler(this.FrmGestionProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.PoisonDataGridView dtgProjects;
        private Label label1;
        private ReaLTaiizor.Controls.NightButton btnDisableProject;
        private ReaLTaiizor.Controls.NightButton btnEnableProject;
    }
}