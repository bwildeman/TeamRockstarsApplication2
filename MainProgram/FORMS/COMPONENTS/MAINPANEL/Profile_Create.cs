using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram.FORMS.COMPONENTS.MAINPANEL
{
    public partial class ProfileCreate : Form
    {
        public ProfileCreate()
        {
            InitializeComponent();
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            CONTROLLERS.ControllerMain.ChangePanels(FormMain.Page.Profile);
        }

        private void BT_Confirm_Click(object sender, EventArgs e)
        {
            if (TB_Password.Text == TB_PasswordConfirm.Text)
            {
                int naamsplits = TB_Name.Text.IndexOf(" ");
                string firstname = TB_Name.Text.Substring(0, naamsplits);
                string surname = TB_Name.Text.Substring(naamsplits);
                string region = comboB_Region.Text;
                int usertype = CheckBAdmin.Checked ? 1 : 0;

                DATABASE.DbConnect.CreateUser(firstname, surname, region, TB_Department.Text, TB_Email.Text, TB_PhoneNR.Text, CMB_gender.SelectedIndex, DTP_DOB.Value, TB_Password.Text, usertype);
            }
            else
            {
                MessageBox.Show("Please enter the same password");
            }
            CONTROLLERS.ControllerMain.ChangePanels(FormMain.Page.Profile);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
