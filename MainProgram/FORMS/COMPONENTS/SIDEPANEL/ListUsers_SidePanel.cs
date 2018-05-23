using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram.FORMS.COMPONENTS.SIDEPANEL
{
    public partial class ListUsersSidePanel : Form
    {
        public object OutputValue { get; private set; }

        List<USER.Data> _users;
        private USER.Data _client;

        public ListUsersSidePanel(List<USER.Data> input, USER.Data client)
        {
            _users = input;
            _client = client;
            InitializeComponent();
        }

        private void ListUsers_SidePanel_Load(object sender, EventArgs e)
        {
            //  Clear list:
            LB_Users.Items.Clear();
            //  Fill list:
            foreach (var item in _users)
            {
                LB_Users.Items.Add(item);
            }
            //  Check if Client is admin:
            if (_client.Type != 1)
            {
                BT_CreatUser.Visible = false;
            }
        }

        private void LB_Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            CONTROLLERS.ControllerMain.LoadProfile((USER.Data)LB_Users.SelectedItem, LB_Users.SelectedIndex);
        }

        private void BT_CreatUser_Click(object sender, EventArgs e)
        {
            CONTROLLERS.ControllerMain.ChangePanels(FORMS.FormMain.Page.ProfileCreate);
        }
    }
}
