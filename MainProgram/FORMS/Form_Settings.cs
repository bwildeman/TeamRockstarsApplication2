using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram
{
    public partial class Form_Settings : Form
    {
        private USER.Data User;
        public Form_Settings(USER.Data input)
        {
            User = input;
            InitializeComponent();
        }

        private void Form_Settings_Load(object sender, EventArgs e)
        {

        }

        private void BT_Light_Click(object sender, EventArgs e)
        {
            //this.StyleManager = msmSettings;
            msmSettings.Theme = MetroFramework.MetroThemeStyle.Light;
        }

        private void BT_Dark_Click(object sender, EventArgs e)
        {
            //this.StyleManager = msmSettings;
            msmSettings.Theme = MetroFramework.MetroThemeStyle.Dark;
        }

        private void BT_ColorChange_Click(object sender, EventArgs e)
        {
            msmSettings.Style = (MetroFramework.MetroColorStyle)Convert.ToInt32(CB_Colour.Text);
        }
    }
}
