namespace MainProgram.FORMS.COMPONENTS.POPUPS
{
    partial class GroupJoinOrNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupJoinOrNew));
            this.btn_JoinGroup = new System.Windows.Forms.Button();
            this.btn_CreateGroup = new System.Windows.Forms.Button();
            this.LB_Exit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_JoinGroup
            // 
            this.btn_JoinGroup.BackColor = System.Drawing.SystemColors.Window;
            this.btn_JoinGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JoinGroup.Location = new System.Drawing.Point(239, 41);
            this.btn_JoinGroup.Margin = new System.Windows.Forms.Padding(4);
            this.btn_JoinGroup.Name = "btn_JoinGroup";
            this.btn_JoinGroup.Size = new System.Drawing.Size(196, 242);
            this.btn_JoinGroup.TabIndex = 0;
            this.btn_JoinGroup.Text = "Join an existing group";
            this.btn_JoinGroup.UseVisualStyleBackColor = false;
            this.btn_JoinGroup.Click += new System.EventHandler(this.btn_JoinGroup_Click);
            // 
            // btn_CreateGroup
            // 
            this.btn_CreateGroup.BackColor = System.Drawing.SystemColors.Window;
            this.btn_CreateGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CreateGroup.Location = new System.Drawing.Point(16, 41);
            this.btn_CreateGroup.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CreateGroup.Name = "btn_CreateGroup";
            this.btn_CreateGroup.Size = new System.Drawing.Size(196, 242);
            this.btn_CreateGroup.TabIndex = 1;
            this.btn_CreateGroup.Text = "Create a new group";
            this.btn_CreateGroup.UseVisualStyleBackColor = false;
            this.btn_CreateGroup.Click += new System.EventHandler(this.btn_CreateGroup_Click);
            // 
            // LB_Exit
            // 
            this.LB_Exit.BackColor = System.Drawing.Color.Transparent;
            this.LB_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.LB_Exit.ForeColor = System.Drawing.Color.White;
            this.LB_Exit.Location = new System.Drawing.Point(435, 0);
            this.LB_Exit.Name = "LB_Exit";
            this.LB_Exit.Size = new System.Drawing.Size(17, 17);
            this.LB_Exit.TabIndex = 99;
            this.LB_Exit.Text = "X";
            this.LB_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_Exit.Click += new System.EventHandler(this.LB_Exit_Click);
            // 
            // Group_JoinOrNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(451, 321);
            this.Controls.Add(this.LB_Exit);
            this.Controls.Add(this.btn_CreateGroup);
            this.Controls.Add(this.btn_JoinGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GroupJoinOrNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group_JoinOrNew";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_JoinGroup;
        private System.Windows.Forms.Button btn_CreateGroup;
        private System.Windows.Forms.Label LB_Exit;
    }
}