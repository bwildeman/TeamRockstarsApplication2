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
    /// <summary>
    /// A form in which multiple forms are loaded
    /// </summary>
    public partial class GroupSelector : Form
    {
        //  FEELDS 
        List<GROUP.Data> _listOfGroups;
        USER.Data _client;

        /// <summary>
        /// Constructor
        /// </summary>
        public GroupSelector(USER.Data client)
        {
            InitializeComponent();
            SetSelector();

            _client = client;

            _listOfGroups = DATABASE.DbConnect.GetAllGroupInfo();
        }

        /// <summary>
        /// When the form loads it places the groups in the window displayed in a SmallSelector form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Group_Selector_Load(object sender, EventArgs e)
        {
            foreach (var group in _listOfGroups)
            {
                bool addGroup = true;
                foreach (var usersGroup in _client.Groups)
                {
                    if (group.GroupId == usersGroup.GroupId)
                    {
                        addGroup = false;
                    }
                }
                if (addGroup)
                {
                    this.FLP_GroupSelector.Controls.Add(GROUP.Display.ShowSmallSelector(_client, group));
                }
            }
            if (this.FLP_GroupSelector.Controls.Count == 0)
            {
                MessageBox.Show("Their aren't any groups that you have't joined already", "Caution:");
                CONTROLLERS.ControllerMain.ChangePanels(FormMain.Page.Profile);
            }
        }

        /// <summary>
        /// Sets the properties of the selector
        /// </summary>
        private void SetSelector()
        {
            this.FLP_GroupSelector.WrapContents = true;
            this.FLP_GroupSelector.FlowDirection = FlowDirection.LeftToRight;
            this.FLP_GroupSelector.Dock = DockStyle.Fill;
        }
    }
}
