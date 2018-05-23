using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram.FORMS.COMPONENTS.POPUPS
{
    public partial class GroupJoinOrNew : Form
    {
        public GroupJoinOrNew()
        {
            InitializeComponent();
        }

        private void btn_JoinGroup_Click(object sender, EventArgs e)
        {
            CONTROLLERS.ControllerMain.ChangePanels(FormMain.Page.GroupSelector);
            this.Close();
        }

        private void btn_CreateGroup_Click(object sender, EventArgs e)
        {
            GROUP.Logic.CreateGroup();
            this.Close();
        }

        private void LB_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
