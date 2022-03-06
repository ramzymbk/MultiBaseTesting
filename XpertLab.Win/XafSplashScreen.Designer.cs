namespace XpertLab.Win {
    partial class XafSplashScreen
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
            this.progressBarControl = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.labelCopyright = new DevExpress.XtraEditors.LabelControl();
            this.labelStatus = new DevExpress.XtraEditors.LabelControl();
            this.peImage = new DevExpress.XtraEditors.PictureEdit();
            this.pcApplicationName = new DevExpress.XtraEditors.PanelControl();
            this.labelSubtitle = new DevExpress.XtraEditors.LabelControl();
            this.labelApplicationName = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcApplicationName)).BeginInit();
            this.pcApplicationName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarControl
            // 
            this.progressBarControl.EditValue = 0;
            this.progressBarControl.Location = new System.Drawing.Point(86, 334);
            this.progressBarControl.Margin = new System.Windows.Forms.Padding(4);
            this.progressBarControl.Name = "progressBarControl";
            // 
            // 
            // 
            this.progressBarControl.Properties.Appearance.BackColor2 = System.Drawing.Color.Blue;
            this.progressBarControl.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.progressBarControl.Properties.AppearanceDisabled.BackColor2 = System.Drawing.Color.Blue;
            this.progressBarControl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.progressBarControl.Properties.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(114)))), ((int)(((byte)(0)))));
            this.progressBarControl.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.progressBarControl.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.progressBarControl.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressBarControl.Properties.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.progressBarControl.Size = new System.Drawing.Size(408, 20);
            this.progressBarControl.TabIndex = 5;
            // 
            // labelCopyright
            // 
            this.labelCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelCopyright.Location = new System.Drawing.Point(28, 399);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(4);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(186, 16);
            this.labelCopyright.TabIndex = 6;
            this.labelCopyright.Text = "Tous droits réservés à XpertSoft";
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(88, 311);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(76, 16);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Démarrage...";
            // 
            // peImage
            // 
            this.peImage.Location = new System.Drawing.Point(14, 15);
            this.peImage.Margin = new System.Windows.Forms.Padding(4);
            this.peImage.Name = "peImage";
            // 
            // 
            // 
            this.peImage.Properties.AllowFocused = false;
            this.peImage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.peImage.Properties.Appearance.Options.UseBackColor = true;
            this.peImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.peImage.Properties.ShowMenu = false;
            this.peImage.Size = new System.Drawing.Size(497, 222);
            this.peImage.TabIndex = 9;
            this.peImage.Visible = false;
            // 
            // pcApplicationName
            // 
            this.pcApplicationName.Appearance.BackColor = System.Drawing.Color.Teal;
            this.pcApplicationName.Appearance.Options.UseBackColor = true;
            this.pcApplicationName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcApplicationName.Controls.Add(this.labelSubtitle);
            this.pcApplicationName.Controls.Add(this.labelApplicationName);
            this.pcApplicationName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcApplicationName.Location = new System.Drawing.Point(1, 1);
            this.pcApplicationName.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pcApplicationName.Margin = new System.Windows.Forms.Padding(4);
            this.pcApplicationName.Name = "pcApplicationName";
            this.pcApplicationName.Size = new System.Drawing.Size(600, 271);
            this.pcApplicationName.TabIndex = 10;
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSubtitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(188)))));
            this.labelSubtitle.Appearance.Options.UseFont = true;
            this.labelSubtitle.Appearance.Options.UseForeColor = true;
            this.labelSubtitle.Location = new System.Drawing.Point(100, 161);
            this.labelSubtitle.Margin = new System.Windows.Forms.Padding(4);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(440, 30);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "Gestion des laboratoires d\'analyses médicales";
            // 
            // labelApplicationName
            // 
            this.labelApplicationName.Appearance.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelApplicationName.Appearance.ForeColor = System.Drawing.SystemColors.Window;
            this.labelApplicationName.Appearance.Options.UseFont = true;
            this.labelApplicationName.Appearance.Options.UseForeColor = true;
            this.labelApplicationName.Location = new System.Drawing.Point(100, 103);
            this.labelApplicationName.Margin = new System.Windows.Forms.Padding(4);
            this.labelApplicationName.Name = "labelApplicationName";
            this.labelApplicationName.Size = new System.Drawing.Size(184, 59);
            this.labelApplicationName.TabIndex = 0;
            this.labelApplicationName.Text = "XpertLab";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::XpertLab.Win.Properties.Resources.medical_41_icon_icons1;
            this.pictureBox1.Location = new System.Drawing.Point(500, 366);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 94);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // XafSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(602, 464);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pcApplicationName);
            this.Controls.Add(this.peImage);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.progressBarControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "XafSplashScreen";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.XafSplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcApplicationName)).EndInit();
            this.pcApplicationName.ResumeLayout(false);
            this.pcApplicationName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl progressBarControl;
        private DevExpress.XtraEditors.LabelControl labelCopyright;
        private DevExpress.XtraEditors.LabelControl labelStatus;
        private DevExpress.XtraEditors.PictureEdit peImage;
        private DevExpress.XtraEditors.PanelControl pcApplicationName;
        private DevExpress.XtraEditors.LabelControl labelSubtitle;
        private DevExpress.XtraEditors.LabelControl labelApplicationName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
