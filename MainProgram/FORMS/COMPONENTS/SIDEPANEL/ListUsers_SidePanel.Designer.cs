namespace MainProgram.FORMS.COMPONENTS.SIDEPANEL
{
    partial class ListUsersSidePanel
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
            this.LB_Users = new System.Windows.Forms.ListBox();
            this.BT_CreatUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LB_Users
            // 
            this.LB_Users.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LB_Users.ForeColor = System.Drawing.Color.Black;
            this.LB_Users.FormattingEnabled = true;
            this.LB_Users.ItemHeight = 20;
            this.LB_Users.Location = new System.Drawing.Point(0, -1);
            this.LB_Users.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LB_Users.Name = "LB_Users";
            this.LB_Users.Size = new System.Drawing.Size(176, 524);
            this.LB_Users.TabIndex = 0;
            this.LB_Users.SelectedIndexChanged += new System.EventHandler(this.LB_Users_SelectedIndexChanged);
            // 
            // BT_CreatUser
            // 
            this.BT_CreatUser.BackColor = System.Drawing.Color.White;
            this.BT_CreatUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.BT_CreatUser.Location = new System.Drawing.Point(143, -1);
            this.BT_CreatUser.Margin = new System.Windows.Forms.Padding(4);
            this.BT_CreatUser.Name = "BT_CreatUser";
            this.BT_CreatUser.Size = new System.Drawing.Size(33, 31);
            this.BT_CreatUser.TabIndex = 1;
            this.BT_CreatUser.Text = "+";
            this.BT_CreatUser.UseVisualStyleBackColor = false;
            this.BT_CreatUser.Click += new System.EventHandler(this.BT_CreatUser_Click);
            // 
            // ListUsers_SidePanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(173, 502);
            this.ControlBox = false;
            this.Controls.Add(this.BT_CreatUser);
            this.Controls.Add(this.LB_Users);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ListUsersSidePanel";
            this.Text = "ListUsers_SidePanel";
            this.Load += new System.EventHandler(this.ListUsers_SidePanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Users;
        private System.Windows.Forms.Button BT_CreatUser;
    }
}