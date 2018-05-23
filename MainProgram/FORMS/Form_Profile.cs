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
    public partial class Form_Profile : Form
    {
        private USER.Data User;
        public Form_Profile(USER.Data input)
        {
            User = input;
            InitializeComponent();

        }

        private void Form_Profile_Load(object sender, EventArgs e)
        {

        }

        private void BT_Menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Menu menuForm = new Form_Menu(User.UserId);
            //menuForm.StyleManager = this.StyleManager;
            menuForm.ShowDialog();
            this.Close();
        }
    }
}
