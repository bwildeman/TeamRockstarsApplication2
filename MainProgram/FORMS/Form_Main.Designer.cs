namespace MainProgram.FORMS
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.P_UserInformation = new System.Windows.Forms.Panel();
            this.P_SidePanel = new System.Windows.Forms.Panel();
            this.P_MainPanel = new System.Windows.Forms.Panel();
            this.LB_Groups = new System.Windows.Forms.ListBox();
            this.P_Title = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_AddGroup = new System.Windows.Forms.Button();
            this.LB_Exit = new System.Windows.Forms.Label();
            this.P_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // P_UserInformation
            // 
            this.P_UserInformation.Location = new System.Drawing.Point(19, 25);
            this.P_UserInformation.Margin = new System.Windows.Forms.Padding(4);
            this.P_UserInformation.Name = "P_UserInformation";
            this.P_UserInformation.Size = new System.Drawing.Size(177, 179);
            this.P_UserInformation.TabIndex = 0;
            // 
            // P_SidePanel
            // 
            this.P_SidePanel.Location = new System.Drawing.Point(205, 225);
            this.P_SidePanel.Margin = new System.Windows.Forms.Padding(4);
            this.P_SidePanel.Name = "P_SidePanel";
            this.P_SidePanel.Size = new System.Drawing.Size(177, 511);
            this.P_SidePanel.TabIndex = 2;
            // 
            // P_MainPanel
            // 
            this.P_MainPanel.Location = new System.Drawing.Point(397, 225);
            this.P_MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.P_MainPanel.Name = "P_MainPanel";
            this.P_MainPanel.Size = new System.Drawing.Size(608, 511);
            this.P_MainPanel.TabIndex = 3;
            // 
            // LB_Groups
            // 
            this.LB_Groups.ForeColor = System.Drawing.Color.Black;
            this.LB_Groups.FormattingEnabled = true;
            this.LB_Groups.ItemHeight = 16;
            this.LB_Groups.Location = new System.Drawing.Point(19, 225);
            this.LB_Groups.Margin = new System.Windows.Forms.Padding(4);
            this.LB_Groups.Name = "LB_Groups";
            this.LB_Groups.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LB_Groups.Size = new System.Drawing.Size(177, 516);
            this.LB_Groups.TabIndex = 4;
            this.LB_Groups.SelectedIndexChanged += new System.EventHandler(this.LB_Groups_SelectedIndexChanged);
            // 
            // P_Title
            // 
            this.P_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.P_Title.Controls.Add(this.pictureBox2);
            this.P_Title.Location = new System.Drawing.Point(205, 25);
            this.P_Title.Margin = new System.Windows.Forms.Padding(4);
            this.P_Title.Name = "P_Title";
            this.P_Title.Size = new System.Drawing.Size(800, 179);
            this.P_Title.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.ImageLocation = "Left";
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(635, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(165, 107);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // btn_AddGroup
            // 
            this.btn_AddGroup.BackColor = System.Drawing.Color.White;
            this.btn_AddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddGroup.Location = new System.Drawing.Point(163, 225);
            this.btn_AddGroup.Name = "btn_AddGroup";
            this.btn_AddGroup.Size = new System.Drawing.Size(33, 31);
            this.btn_AddGroup.TabIndex = 6;
            this.btn_AddGroup.Text = "+";
            this.btn_AddGroup.UseVisualStyleBackColor = false;
            this.btn_AddGroup.Click += new System.EventHandler(this.btn_AddGroup_Click);
            // 
            // LB_Exit
            // 
            this.LB_Exit.BackColor = System.Drawing.Color.Transparent;
            this.LB_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.LB_Exit.ForeColor = System.Drawing.Color.White;
            this.LB_Exit.Location = new System.Drawing.Point(1006, 0);
            this.LB_Exit.Name = "LB_Exit";
            this.LB_Exit.Size = new System.Drawing.Size(17, 17);
            this.LB_Exit.TabIndex = 99;
            this.LB_Exit.Text = "X";
            this.LB_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_Exit.Click += new System.EventHandler(this.LB_Exit_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.LB_Exit);
            this.Controls.Add(this.btn_AddGroup);
            this.Controls.Add(this.P_Title);
            this.Controls.Add(this.LB_Groups);
            this.Controls.Add(this.P_MainPanel);
            this.Controls.Add(this.P_SidePanel);
            this.Controls.Add(this.P_UserInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.P_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel P_UserInformation;
        private System.Windows.Forms.Panel P_SidePanel;
        private System.Windows.Forms.Panel P_MainPanel;
        private System.Windows.Forms.ListBox LB_Groups;
        private System.Windows.Forms.Panel P_Title;
        private System.Windows.Forms.Button btn_AddGroup;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LB_Exit;
    }
}