namespace MainProgram
{
    partial class Form_Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Settings));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BT_Light = new MetroFramework.Controls.MetroButton();
            this.BT_Dark = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BT_ColorChange = new MetroFramework.Controls.MetroButton();
            this.CB_Colour = new MetroFramework.Controls.MetroComboBox();
            this.msmSettings = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msmSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.ImageLocation = "Left";
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(549, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 73);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // BT_Light
            // 
            this.BT_Light.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.BT_Light.Location = new System.Drawing.Point(33, 98);
            this.BT_Light.Name = "BT_Light";
            this.BT_Light.Size = new System.Drawing.Size(118, 73);
            this.BT_Light.TabIndex = 10;
            this.BT_Light.Text = "Light";
            this.BT_Light.UseSelectable = true;
            this.BT_Light.Click += new System.EventHandler(this.BT_Light_Click);
            // 
            // BT_Dark
            // 
            this.BT_Dark.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.BT_Dark.Location = new System.Drawing.Point(33, 188);
            this.BT_Dark.Name = "BT_Dark";
            this.BT_Dark.Size = new System.Drawing.Size(118, 73);
            this.BT_Dark.TabIndex = 12;
            this.BT_Dark.Tag = "";
            this.BT_Dark.Text = "Dark";
            this.BT_Dark.UseSelectable = true;
            this.BT_Dark.Click += new System.EventHandler(this.BT_Dark_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Thema";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "Colour";
            // 
            // BT_ColorChange
            // 
            this.BT_ColorChange.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.BT_ColorChange.Location = new System.Drawing.Point(217, 188);
            this.BT_ColorChange.Name = "BT_ColorChange";
            this.BT_ColorChange.Size = new System.Drawing.Size(118, 73);
            this.BT_ColorChange.TabIndex = 16;
            this.BT_ColorChange.Text = "Change Colour";
            this.BT_ColorChange.UseSelectable = true;
            this.BT_ColorChange.Click += new System.EventHandler(this.BT_ColorChange_Click);
            // 
            // CB_Colour
            // 
            this.CB_Colour.FormattingEnabled = true;
            this.CB_Colour.ItemHeight = 23;
            this.CB_Colour.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14"});
            this.CB_Colour.Location = new System.Drawing.Point(217, 98);
            this.CB_Colour.Name = "CB_Colour";
            this.CB_Colour.Size = new System.Drawing.Size(118, 29);
            this.CB_Colour.TabIndex = 17;
            this.CB_Colour.UseSelectable = true;
            // 
            // msmSettings
            // 
            this.msmSettings.Owner = this;
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 290);
            this.Controls.Add(this.CB_Colour);
            this.Controls.Add(this.BT_ColorChange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_Dark);
            this.Controls.Add(this.BT_Light);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_Settings";
            this.Padding = new System.Windows.Forms.Padding(30, 97, 30, 32);
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form_Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msmSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton BT_Light;
        private MetroFramework.Controls.MetroButton BT_Dark;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroComboBox CB_Colour;
        private MetroFramework.Controls.MetroButton BT_ColorChange;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Components.MetroStyleManager msmSettings;
    }
}