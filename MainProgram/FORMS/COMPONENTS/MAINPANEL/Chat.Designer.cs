namespace MainProgram.FORMS.COMPONENTS.MAINPANEL
{
    partial class Chat
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
            this.components = new System.ComponentModel.Container();
            this.LBoxMessages = new System.Windows.Forms.ListBox();
            this.MessageChecker = new System.Windows.Forms.Timer(this.components);
            this.BT_Message = new System.Windows.Forms.Button();
            this.TB_MessageInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LBoxMessages
            // 
            this.LBoxMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.LBoxMessages.ForeColor = System.Drawing.Color.Black;
            this.LBoxMessages.FormattingEnabled = true;
            this.LBoxMessages.ItemHeight = 20;
            this.LBoxMessages.Location = new System.Drawing.Point(5, 6);
            this.LBoxMessages.Name = "LBoxMessages";
            this.LBoxMessages.Size = new System.Drawing.Size(592, 324);
            this.LBoxMessages.TabIndex = 20;
            // 
            // MessageChecker
            // 
            this.MessageChecker.Tick += new System.EventHandler(this.MessageChecker_Tick);
            // 
            // BT_Message
            // 
            this.BT_Message.BackColor = System.Drawing.SystemColors.Window;
            this.BT_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.BT_Message.ForeColor = System.Drawing.Color.Black;
            this.BT_Message.Location = new System.Drawing.Point(5, 441);
            this.BT_Message.Margin = new System.Windows.Forms.Padding(4);
            this.BT_Message.Name = "BT_Message";
            this.BT_Message.Size = new System.Drawing.Size(123, 65);
            this.BT_Message.TabIndex = 96;
            this.BT_Message.Text = "Send";
            this.BT_Message.UseVisualStyleBackColor = false;
            this.BT_Message.Click += new System.EventHandler(this.BT_Message_Click);
            // 
            // TB_MessageInput
            // 
            this.TB_MessageInput.Location = new System.Drawing.Point(5, 337);
            this.TB_MessageInput.Multiline = true;
            this.TB_MessageInput.Name = "TB_MessageInput";
            this.TB_MessageInput.Size = new System.Drawing.Size(592, 97);
            this.TB_MessageInput.TabIndex = 97;
            // 
            // Chat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(608, 511);
            this.ControlBox = false;
            this.Controls.Add(this.TB_MessageInput);
            this.Controls.Add(this.BT_Message);
            this.Controls.Add(this.LBoxMessages);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Chat";
            this.Padding = new System.Windows.Forms.Padding(30, 97, 30, 32);
            this.Load += new System.EventHandler(this.Form_Chat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox LBoxMessages;
        private System.Windows.Forms.Timer MessageChecker;
        private System.Windows.Forms.Button BT_Message;
        private System.Windows.Forms.TextBox TB_MessageInput;
    }
}