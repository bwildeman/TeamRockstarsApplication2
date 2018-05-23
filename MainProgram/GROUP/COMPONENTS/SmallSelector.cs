using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram.GROUP.COMPONENTS
{
    public partial class SmallSelector : Form
    {
        //  FEELDS
        GROUP.Data _myGroup;
        USER.Data _client;
        bool _usable = true;

        /// <summary>
        /// Initializes the form with the given values
        /// </summary>
        /// <param name="name">Name of the group</param>
        /// <param name="description">Description of the group</param>
        public SmallSelector(GROUP.Data group, USER.Data client)
        {
            InitializeComponent();

            _myGroup = group;
            _client = client;

            this.lbl_Name.Text = _myGroup.Name;
            this.lbl_Description.Text = _myGroup.Description;

            foreach (var item in client.Groups)
            {
                if (item.GroupId == group.GroupId)
                {
                    _usable = false;
                }
            }
        }

        /// <summary>
        /// Used to send an event that it has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SmallSelector_Click(object sender, EventArgs e)
        {
            if (_usable)
            {
                GROUP.Logic.JoinGroup(_client, _myGroup);
                _usable = false;
            }

            ChangeColor();
            CONTROLLERS.ControllerMain.Update();
        }

        private void ChangeColor()
        {
            if (!_usable)
            {
                BackColor = Color.Gray;
            }
        }
    }
}
