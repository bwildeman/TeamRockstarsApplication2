using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram.FORMS
{
    public partial class FormMain : Form
    {
        public USER.Data User = new USER.Data();

        public FormMain(int userId)
        {
            User = User.LoadUser(userId, User);

            foreach (GROUP.Data item in User.Groups)
            {
                item.FillChats();
            }

            InitializeComponent();

            //  starts the controlller
            CONTROLLERS.ControllerMain.StartController(
                this.P_MainPanel,
                this.LB_Groups,
                this.P_SidePanel,
                this.P_UserInformation,
                this.P_Title,
                User
            );
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            //  Fills the panels in a standard start layout
            CONTROLLERS.ControllerMain.StartProgram();

            //  Sets the main panel so it isnt empty
            CONTROLLERS.ControllerMain.ChangePanels(Page.Profile);
        }

        private void LB_Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Groups.SelectedIndex != -1)
            {
                CONTROLLERS.ControllerMain.ChangePanels(Page.Chat, (GROUP.Data)LB_Groups.SelectedItem);
            }
        }

        private void btn_AddGroup_Click(object sender, EventArgs e)
        {
            using (FORMS.COMPONENTS.POPUPS.GroupJoinOrNew form = new COMPONENTS.POPUPS.GroupJoinOrNew())
            {
                form.ShowDialog();
            }
        }

        //  ENUMS
        /// <summary>
        /// Enumarator Filled with all the completed pages
        /// </summary>
        public enum Page
        {
            Chat,
            Profile,
            ProfileEdit,
            ProfileCreate,
            GroupSelector
        }

        private void LB_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
