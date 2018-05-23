namespace MainProgram.FORMS.COMPONENTS.MAINPANEL
{
    partial class GroupSelector
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
            this.FLP_GroupSelector = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FLP_GroupSelector
            // 
            this.FLP_GroupSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.FLP_GroupSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLP_GroupSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FLP_GroupSelector.Location = new System.Drawing.Point(0, 0);
            this.FLP_GroupSelector.Name = "FLP_GroupSelector";
            this.FLP_GroupSelector.Size = new System.Drawing.Size(608, 561);
            this.FLP_GroupSelector.TabIndex = 0;
            // 
            // Group_Selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 561);
            this.Controls.Add(this.FLP_GroupSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GroupSelector";
            this.Text = "Group_Selector";
            this.Load += new System.EventHandler(this.Group_Selector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FLP_GroupSelector;
    }
}