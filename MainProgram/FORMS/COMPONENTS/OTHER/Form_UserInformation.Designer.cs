namespace MainProgram.FORMS.COMPONENTS.OTHER
{
    partial class FormUserInformation
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
            this.PB_ProfilePicture = new System.Windows.Forms.PictureBox();
            this.L_UserName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_ProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_ProfilePicture
            // 
            this.PB_ProfilePicture.BackColor = System.Drawing.Color.Transparent;
            this.PB_ProfilePicture.Image = global::MainProgram.Properties.Resources.UserAvatar3;
            this.PB_ProfilePicture.Location = new System.Drawing.Point(12, 1);
            this.PB_ProfilePicture.Name = "PB_ProfilePicture";
            this.PB_ProfilePicture.Size = new System.Drawing.Size(153, 160);
            this.PB_ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_ProfilePicture.TabIndex = 0;
            this.PB_ProfilePicture.TabStop = false;
            this.PB_ProfilePicture.DoubleClick += new System.EventHandler(this.PB_ProfilePicture_DoubleClick);
            // 
            // L_UserName
            // 
            this.L_UserName.BackColor = System.Drawing.Color.Transparent;
            this.L_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.L_UserName.ForeColor = System.Drawing.Color.White;
            this.L_UserName.Location = new System.Drawing.Point(0, 164);
            this.L_UserName.Name = "L_UserName";
            this.L_UserName.Size = new System.Drawing.Size(177, 16);
            this.L_UserName.TabIndex = 1;
            this.L_UserName.Text = "LABEL";
            this.L_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.L_UserName.DoubleClick += new System.EventHandler(this.L_UserName_DoubleClick);
            // 
            // Form_UserInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(177, 179);
            this.Controls.Add(this.L_UserName);
            this.Controls.Add(this.PB_ProfilePicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUserInformation";
            this.Text = "Form_UserInformation";
            this.Load += new System.EventHandler(this.Form_UserInformation_Load);
            this.DoubleClick += new System.EventHandler(this.Form_UserInformation_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.PB_ProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_ProfilePicture;
        private System.Windows.Forms.Label L_UserName;
    }
}