using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProgram.FORMS;
using MainProgram.FORMS.COMPONENTS.SIDEPANEL;
using MainProgram.USER;
using System.Drawing;

namespace MainProgram.CONTROLLERS
{
    public static class ControllerMain
    {
        private static Panel _mainPanel;
        private static Panel _sidePanel;
        private static Panel _userInformationPanel;
        private static Panel _titlePanel;
        private static ListBox _listBoxGroups;
        private static Data _client;
        private static Data _selectedUser;
        private static bool _allItemsLoaded = false;
        private static GROUP.Data _openGroup = new GROUP.Data();

        private static FORMS.FormMain.Page _currentPage;

        public static void StartController(Panel pMainPanel, ListBox lBGroups, Panel pSidePanel, Panel pUserInformation, Panel pTitle, Data user)
        {
            _mainPanel = pMainPanel;
            _sidePanel = pSidePanel;
            _userInformationPanel = pUserInformation;
            _titlePanel = pTitle;
            _listBoxGroups = lBGroups;
            _client = user;
            _selectedUser = user;
            _allItemsLoaded = true;
        }

        public static void LoadProfile(Data selectedUser, int selectedIndex)
        {
            if (selectedIndex != -1)
            {
                //  checks if the panels are filled, if so they are emtied
                if (!MainPanelAvailable())
                    _mainPanel.Controls.Clear();

                Form mainForm = new FORMS.COMPONENTS.MAINPANEL.ProfileShow(selectedUser, _client);

                //  Set the properties of form that is inserted into the main panel
                mainForm.TopLevel = false;
                mainForm.AutoScroll = false;
                _mainPanel.Controls.Add(mainForm);
                mainForm.Show();

                //  Save selected user to main form:
                _selectedUser = selectedUser;
            }
        }

        public static void ChangeChat(CHAT.Data selectedItem, int selectedIndex)
        {
            if (selectedIndex != -1)
            {
                //  checks if the panels are filled, if so they are emtied
                if (!MainPanelAvailable())
                    _mainPanel.Controls.Clear();

                //  Start up new form:
                Form mainForm = new FORMS.COMPONENTS.MAINPANEL.Chat(selectedItem, _client);

                //  Set the properties of form that is inserted into the main panel
                mainForm.TopLevel = false;
                mainForm.AutoScroll = false;
                _mainPanel.Controls.Add(mainForm);
                mainForm.Show();
            }
        }

        /// <summary>
        /// Fills the panels with some pages
        /// </summary>
        /// <remark>
        /// This could be changed
        /// </remark>
        public static void StartProgram()
        {
            if (_allItemsLoaded)
            {
                LoadUserInformation();
                LoadUserGroups();
            }
        }

        public static void Update()
        {
            _client.ReloadGroups();
            LoadUserGroups();

            foreach (GROUP.Data item in _client.Groups)
            {
                item.FillChats();
            }

        }

        /// <summary>
        /// Changes the current pages that should be put in de Panels
        /// </summary>
        /// <param name="page"></param>
        /// <seealso cref="Page"/>
        public static void ChangePanels(FORMS.FormMain.Page page)
        {
            //  Checks if all items are loaded proparly
            if (_allItemsLoaded)
            {
                //  checks if the panels are filled, if so they are emtied
                if (!MainPanelAvailable())
                    _mainPanel.Controls.Clear();
                if (!SidePanelAvailable())
                    _sidePanel.Controls.Clear();
                
                /// <seealso cref="GetForm"/>
                Form mainForm = GetForm(page);
                /// <seealso cref="GetSideForm"/>
                Form sideForm = GetSideForm(page);

                //  Set the properties of form that is inserted into the main panel
                mainForm.TopLevel = false;
                mainForm.AutoScroll = false;
                _mainPanel.Controls.Add(mainForm);
                mainForm.Show();

                //  Set the properties of form that is inserted into the side panel
                sideForm.TopLevel = false;
                sideForm.AutoScroll = true;
                _sidePanel.Controls.Add(sideForm);
                sideForm.Show();

                _currentPage = page;
                LoadUserInformation();
            }
            else
            {
                Console.WriteLine("Controller hasn`t been started yet");
            }
        }

        /// <summary>
        /// Changes the current pages that should be put in de Panels
        /// </summary>
        /// <param name="page"></param>
        /// <seealso cref="Page"/>
        public static void ChangePanels(FORMS.FormMain.Page page, GROUP.Data selectedGroup)
        {
            if (selectedGroup.GroupId != _openGroup.GroupId)
            {
                ChangePanels(page);
                _openGroup = selectedGroup;
            }
        }
        /// <summary>
        /// Changes the current pages that should be put in de Panels
        /// </summary>
        /// <param name="page"></param>
        /// <seealso cref="Page"/>
        public static void ChangePanels(FORMS.FormMain.Page page, USER.Data selectedUser)
        {
            _selectedUser = selectedUser;
            ChangePanels(page);
            
        }

        /// <summary>
        /// A switch based on the Page Enum returns the selected Form
        /// </summary>
        /// <param name="page"></param>
        /// <seealso cref="Page"/>
        /// <returns>The chosen Form</returns>
        private static Form GetForm(FORMS.FormMain.Page page)
        {
            switch (page)
            {
                case FormMain.Page.Chat:
                    ChatAvailable();
                    return new FORMS.COMPONENTS.MAINPANEL.Chat(_client.Groups[_listBoxGroups.SelectedIndex].Chats[0], _client);
                case FORMS.FormMain.Page.Profile:
                    _listBoxGroups.SelectedIndex = -1;
                    _openGroup = new GROUP.Data();
                    return new FORMS.COMPONENTS.MAINPANEL.ProfileShow(_selectedUser, _client);
                case FORMS.FormMain.Page.ProfileEdit:
                    return new FORMS.COMPONENTS.MAINPANEL.ProfileEdit(_selectedUser);
                case FORMS.FormMain.Page.ProfileCreate:
                    return new FORMS.COMPONENTS.MAINPANEL.ProfileCreate();
                case FORMS.FormMain.Page.GroupSelector:
                    return new FORMS.COMPONENTS.MAINPANEL.GroupSelector(_client);
                default:
                    return new FORMS.COMPONENTS.MAINPANEL.ProfileShow(_selectedUser, _client);
            }
        }

        private static void ChatAvailable()
        {
            int selectedGroupIndex = _listBoxGroups.SelectedIndex;

            GROUP.Data group = (GROUP.Data)_listBoxGroups.SelectedItem;

            if (_client.Groups[selectedGroupIndex].Chats.Count == 0)
            {
                DATABASE.DbConnect.AddChat(group.GroupId, "General", "The general chat");
            }

            foreach (GROUP.Data item in _client.Groups)
            {
                item.FillChats();
            }
        }

        /// <summary>
        /// A switch based on the Page Enum returns the selected Form if the choice uses the SidePanel
        /// if not it returns a blank Form
        /// </summary>
        /// <param name="page"></param>
        /// <seealso cref="Page"/>
        /// <returns></returns>
        private static Form GetSideForm(FORMS.FormMain.Page page)
        {
            switch (page)
            {
                case FORMS.FormMain.Page.Chat:
                    return new FORMS.COMPONENTS.SIDEPANEL.ListChannelsSidePanel((GROUP.Data)_listBoxGroups.SelectedItem);
                case FORMS.FormMain.Page.Profile:
                    return new ListUsersSidePanel(DATABASE.DbConnect.GetAllUsers(_client.UserId), _client);
                default:
                    return new FORMS.COMPONENTS.SIDEPANEL.Blank();
            }
        }

        /// <summary>
        /// uses User.Display to show All groups that the user is in
        /// and places them in a ListBox
        /// </summary>
        /// <seealso cref="USER.Display"/>
        private static void LoadUserGroups()
        {
            USER.Display.ShowAllGroups(_listBoxGroups, _client);
        }

        /// <summary>
        /// Loads the userInformation in a Panel
        /// </summary>
        public static void LoadUserInformation()
        {
            _userInformationPanel.Controls.Clear();

            FORMS.COMPONENTS.OTHER.FormUserInformation form = new FORMS.COMPONENTS.OTHER.FormUserInformation(_client);
            form.TopLevel = false;
            form.AutoScroll = true;
            _userInformationPanel.Controls.Add(form);
            form.Show();
        }

        /// <summary>
        /// Checks if the MainPanel is empty
        /// if true, it is available to be filled
        /// </summary>
        /// <returns>The availability of the Panel</returns>
        private static bool MainPanelAvailable()
        {
            return !(_mainPanel.Controls.Count > 0);
        }

        /// <summary>
        /// Checks if the SidePanel is empty
        /// if true, it is available to be filled
        /// </summary>
        /// <returns>The availability of the Panel</returns>
        private static bool SidePanelAvailable()
        {
            return !(_sidePanel.Controls.Count > 0);
        }

        /// <summary>
        /// Make picture box edges round
        /// </summary>
        /// <param name="picBox"></param>
        public static void RoundPictureBox(PictureBox picBox)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, picBox.Width - 3, picBox.Height - 3);
            Region rg = new Region(gp);
            picBox.Region = rg;
        }
    }
}
