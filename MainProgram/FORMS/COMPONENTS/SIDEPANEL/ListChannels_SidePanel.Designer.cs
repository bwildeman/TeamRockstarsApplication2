namespace MainProgram.FORMS.COMPONENTS.SIDEPANEL
{
    partial class ListChannelsSidePanel
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
            this.LB_Chats = new System.Windows.Forms.ListBox();
            this.LB_Events = new System.Windows.Forms.ListBox();
            this.LblChats = new System.Windows.Forms.Label();
            this.LblEvents = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LB_Chats
            // 
            this.LB_Chats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LB_Chats.ForeColor = System.Drawing.Color.Black;
            this.LB_Chats.FormattingEnabled = true;
            this.LB_Chats.ItemHeight = 20;
            this.LB_Chats.Location = new System.Drawing.Point(16, 30);
            this.LB_Chats.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LB_Chats.Name = "LB_Chats";
            this.LB_Chats.Size = new System.Drawing.Size(148, 224);
            this.LB_Chats.TabIndex = 0;
            this.LB_Chats.SelectedIndexChanged += new System.EventHandler(this.LB_Chats_SelectedIndexChanged);
            // 
            // LB_Events
            // 
            this.LB_Events.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LB_Events.ForeColor = System.Drawing.Color.Black;
            this.LB_Events.FormattingEnabled = true;
            this.LB_Events.ItemHeight = 20;
            this.LB_Events.Location = new System.Drawing.Point(13, 282);
            this.LB_Events.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LB_Events.Name = "LB_Events";
            this.LB_Events.Size = new System.Drawing.Size(151, 204);
            this.LB_Events.TabIndex = 1;
            // 
            // LblChats
            // 
            this.LblChats.AutoSize = true;
            this.LblChats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LblChats.ForeColor = System.Drawing.Color.White;
            this.LblChats.Location = new System.Drawing.Point(12, 6);
            this.LblChats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblChats.Name = "LblChats";
            this.LblChats.Size = new System.Drawing.Size(58, 20);
            this.LblChats.TabIndex = 2;
            this.LblChats.Text = "Chats:";
            // 
            // LblEvents
            // 
            this.LblEvents.AutoSize = true;
            this.LblEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LblEvents.ForeColor = System.Drawing.Color.White;
            this.LblEvents.Location = new System.Drawing.Point(13, 258);
            this.LblEvents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblEvents.Name = "LblEvents";
            this.LblEvents.Size = new System.Drawing.Size(65, 20);
            this.LblEvents.TabIndex = 3;
            this.LblEvents.Text = "Events:";
            // 
            // ListChannels_SidePanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(177, 516);
            this.ControlBox = false;
            this.Controls.Add(this.LblEvents);
            this.Controls.Add(this.LblChats);
            this.Controls.Add(this.LB_Events);
            this.Controls.Add(this.LB_Chats);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ListChannelsSidePanel";
            this.Text = "ListChannels_SidePanel";
            this.Load += new System.EventHandler(this.ListChannels_SidePanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Chats;
        private System.Windows.Forms.ListBox LB_Events;
        private System.Windows.Forms.Label LblChats;
        private System.Windows.Forms.Label LblEvents;
    }
}