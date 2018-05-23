namespace MainProgram.FORMS.COMPONENTS.MAINPANEL
{
    partial class ProfileShow
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
            this.PBoxUser = new System.Windows.Forms.PictureBox();
            this.LblInterestsHeader = new System.Windows.Forms.Label();
            this.LblInterests = new System.Windows.Forms.Label();
            this.LblRegion = new System.Windows.Forms.Label();
            this.LblTelephoneNumber = new System.Windows.Forms.Label();
            this.LblEmail = new System.Windows.Forms.Label();
            this.LblQuote = new System.Windows.Forms.Label();
            this.LblDepartment = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.LbResidence = new System.Windows.Forms.Label();
            this.LbPorfolioHeader = new System.Windows.Forms.Label();
            this.LbPortfolio = new System.Windows.Forms.Label();
            this.BT_EditProfile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PBoxUser)).BeginInit();
            this.SuspendLayout();
            // 
            // PBoxUser
            // 
            this.PBoxUser.Image = global::MainProgram.Properties.Resources.UserAvatar3;
            this.PBoxUser.Location = new System.Drawing.Point(328, 15);
            this.PBoxUser.Margin = new System.Windows.Forms.Padding(4);
            this.PBoxUser.Name = "PBoxUser";
            this.PBoxUser.Size = new System.Drawing.Size(267, 246);
            this.PBoxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBoxUser.TabIndex = 1;
            this.PBoxUser.TabStop = false;
            // 
            // LblInterestsHeader
            // 
            this.LblInterestsHeader.AutoSize = true;
            this.LblInterestsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.LblInterestsHeader.ForeColor = System.Drawing.Color.White;
            this.LblInterestsHeader.Location = new System.Drawing.Point(20, 306);
            this.LblInterestsHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblInterestsHeader.Name = "LblInterestsHeader";
            this.LblInterestsHeader.Size = new System.Drawing.Size(67, 16);
            this.LblInterestsHeader.TabIndex = 7;
            this.LblInterestsHeader.Text = "Interests";
            // 
            // LblInterests
            // 
            this.LblInterests.AutoSize = true;
            this.LblInterests.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LblInterests.ForeColor = System.Drawing.Color.White;
            this.LblInterests.Location = new System.Drawing.Point(20, 335);
            this.LblInterests.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblInterests.Name = "LblInterests";
            this.LblInterests.Size = new System.Drawing.Size(118, 16);
            this.LblInterests.TabIndex = 6;
            this.LblInterests.Text = "[Work in progress]";
            // 
            // LblRegion
            // 
            this.LblRegion.AutoSize = true;
            this.LblRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LblRegion.ForeColor = System.Drawing.Color.White;
            this.LblRegion.Location = new System.Drawing.Point(20, 177);
            this.LblRegion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRegion.Name = "LblRegion";
            this.LblRegion.Size = new System.Drawing.Size(60, 16);
            this.LblRegion.TabIndex = 14;
            this.LblRegion.Text = "[Region]";
            // 
            // LblTelephoneNumber
            // 
            this.LblTelephoneNumber.AutoSize = true;
            this.LblTelephoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LblTelephoneNumber.ForeColor = System.Drawing.Color.White;
            this.LblTelephoneNumber.Location = new System.Drawing.Point(20, 132);
            this.LblTelephoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTelephoneNumber.Name = "LblTelephoneNumber";
            this.LblTelephoneNumber.Size = new System.Drawing.Size(103, 16);
            this.LblTelephoneNumber.TabIndex = 13;
            this.LblTelephoneNumber.Text = "[PhoneNumber]";
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LblEmail.ForeColor = System.Drawing.Color.White;
            this.LblEmail.Location = new System.Drawing.Point(20, 101);
            this.LblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(50, 16);
            this.LblEmail.TabIndex = 12;
            this.LblEmail.Text = "[Email]";
            // 
            // LblQuote
            // 
            this.LblQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LblQuote.ForeColor = System.Drawing.Color.White;
            this.LblQuote.Location = new System.Drawing.Point(20, 265);
            this.LblQuote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblQuote.Name = "LblQuote";
            this.LblQuote.Size = new System.Drawing.Size(447, 31);
            this.LblQuote.TabIndex = 11;
            this.LblQuote.Text = "[Quote]";
            // 
            // LblDepartment
            // 
            this.LblDepartment.AutoSize = true;
            this.LblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LblDepartment.ForeColor = System.Drawing.Color.White;
            this.LblDepartment.Location = new System.Drawing.Point(20, 69);
            this.LblDepartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblDepartment.Name = "LblDepartment";
            this.LblDepartment.Size = new System.Drawing.Size(86, 16);
            this.LblDepartment.TabIndex = 10;
            this.LblDepartment.Text = "[Department]";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.ForeColor = System.Drawing.Color.White;
            this.LblName.Location = new System.Drawing.Point(18, 15);
            this.LblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(92, 29);
            this.LblName.TabIndex = 9;
            this.LblName.Text = "[Name]";
            // 
            // LbResidence
            // 
            this.LbResidence.AutoSize = true;
            this.LbResidence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LbResidence.ForeColor = System.Drawing.Color.White;
            this.LbResidence.Location = new System.Drawing.Point(20, 204);
            this.LbResidence.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbResidence.Name = "LbResidence";
            this.LbResidence.Size = new System.Drawing.Size(82, 16);
            this.LbResidence.TabIndex = 16;
            this.LbResidence.Text = "[Residence]";
            // 
            // LbPorfolioHeader
            // 
            this.LbPorfolioHeader.AutoSize = true;
            this.LbPorfolioHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.LbPorfolioHeader.ForeColor = System.Drawing.Color.White;
            this.LbPorfolioHeader.Location = new System.Drawing.Point(20, 375);
            this.LbPorfolioHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbPorfolioHeader.Name = "LbPorfolioHeader";
            this.LbPorfolioHeader.Size = new System.Drawing.Size(66, 16);
            this.LbPorfolioHeader.TabIndex = 17;
            this.LbPorfolioHeader.Text = "Portfolio";
            // 
            // LbPortfolio
            // 
            this.LbPortfolio.AutoSize = true;
            this.LbPortfolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LbPortfolio.ForeColor = System.Drawing.Color.White;
            this.LbPortfolio.Location = new System.Drawing.Point(20, 400);
            this.LbPortfolio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbPortfolio.Name = "LbPortfolio";
            this.LbPortfolio.Size = new System.Drawing.Size(65, 16);
            this.LbPortfolio.TabIndex = 18;
            this.LbPortfolio.Text = "[Portfolio]";
            // 
            // BT_EditProfile
            // 
            this.BT_EditProfile.BackColor = System.Drawing.SystemColors.Window;
            this.BT_EditProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.BT_EditProfile.ForeColor = System.Drawing.Color.Black;
            this.BT_EditProfile.Location = new System.Drawing.Point(543, 469);
            this.BT_EditProfile.Margin = new System.Windows.Forms.Padding(4);
            this.BT_EditProfile.Name = "BT_EditProfile";
            this.BT_EditProfile.Size = new System.Drawing.Size(52, 29);
            this.BT_EditProfile.TabIndex = 97;
            this.BT_EditProfile.Text = "Edit";
            this.BT_EditProfile.UseVisualStyleBackColor = false;
            this.BT_EditProfile.Click += new System.EventHandler(this.BT_EditProfile_Click_1);
            // 
            // Profile_Show
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(608, 511);
            this.Controls.Add(this.BT_EditProfile);
            this.Controls.Add(this.LbPortfolio);
            this.Controls.Add(this.LbPorfolioHeader);
            this.Controls.Add(this.LbResidence);
            this.Controls.Add(this.LblRegion);
            this.Controls.Add(this.LblTelephoneNumber);
            this.Controls.Add(this.LblEmail);
            this.Controls.Add(this.LblQuote);
            this.Controls.Add(this.LblDepartment);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.LblInterestsHeader);
            this.Controls.Add(this.LblInterests);
            this.Controls.Add(this.PBoxUser);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProfileShow";
            this.Text = "Form_ProfileShow";
            this.Load += new System.EventHandler(this.Form_ProfileShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBoxUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBoxUser;
        private System.Windows.Forms.Label LblInterestsHeader;
        private System.Windows.Forms.Label LblInterests;
        private System.Windows.Forms.Label LblRegion;
        private System.Windows.Forms.Label LblTelephoneNumber;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label LblQuote;
        private System.Windows.Forms.Label LblDepartment;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LbResidence;
        private System.Windows.Forms.Label LbPorfolioHeader;
        private System.Windows.Forms.Label LbPortfolio;
        private System.Windows.Forms.Button BT_EditProfile;
    }
}