using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram.GROUP.COMPONENTS.POPUPS
{
    public partial class GroupBuilder : Form
    {
        public string GroupName { get; private set; }
        public string GroupDescription { get; private set; }
        
        public GroupBuilder()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.tb_Name.Text))
            {
                if (!String.IsNullOrWhiteSpace(this.rtb_Description.Text))
                {
                    GroupName = tb_Name.Text;
                    GroupDescription = rtb_Description.Text;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tb_Name_TextChanged(object sender, EventArgs e)
        {
            if (GROUP.Logic.AvailableName(tb_Name.Text))
            {
                //  say its available
            }
            else
            {
                //  say it isn`t available
            }
        }

        private void LB_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
