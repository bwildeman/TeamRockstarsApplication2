using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProgram.DATABASE;

namespace MainProgram
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            DbConnect.SetupConnection();
        }

        private void BT_Login_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TB_UserName.Text) && !string.IsNullOrEmpty(TB_PassWord.Text))
            {
                int userId = DbConnect.Login(TB_UserName.Text, TB_PassWord.Text);
                if (userId == 0)
                {
                    MessageBox.Show("Check your connection, something went wrong connecting to the database.", "Caution:");
                }
                else if (userId == -1)
                {
                    MessageBox.Show("This combination isn't in our database.", "Caution:");
                }
                else
                {
                    // hide current form
                    this.Hide();
                    // open new form
                    FORMS.FormMain form = new FORMS.FormMain(userId);
                    form.ShowDialog();
                    // close current form
                    this.Close();
                }
            }
        }

        private void LB_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TB_PassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BT_Login.PerformClick();
            }
        }
    }
}
