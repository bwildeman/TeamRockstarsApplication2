using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TeamRockStarsIT.FORMS.COMPONENTS.MAIN;
using TeamRockStarsIT.FORMS.COMPONENTS.OTHERS;
using TRS_Domain;
using TRS_Logic;

namespace TeamRockStarsIT.FORMS
{
    /// <summary>
    /// Interaction logic for FORM_Main.xaml
    /// </summary>
    public partial class FormMain : Window
    {
        //  Add logic reference:
        ClientLogic _clientLogic = new ClientLogic();
        ChatLogic _chatLogic = new ChatLogic();
        //  Memory:
        private TRS_Domain.USER.Data _client;

        public FormMain(int clientId)
        {
            //  Get user information
            _client = _clientLogic.LoadClient(clientId);
            //  Fill groupslist:
            foreach (var item in _client.Groups)
            {
                item.FillChats(_chatLogic.GetAllChats(item.GroupId));
            }

            Loaded += FORM_Main_Loaded;
            InitializeComponent();
        }

        private void FORM_Main_Loaded(object sender, RoutedEventArgs e)
        {
            if (_client != null)
            {
                //  Fill UserInformation
                Fr_UserInformation.Content = new COMPONENTS.OTHERS.PageUserInformation(_client, Fr_UserInformation, Fr_Main);

                //  Show profile:
                Fr_Main.Content = new COMPONENTS.MAIN.PageShowProfile(_client, _client, Fr_UserInformation, Fr_Main);

                //  Fill Grouplist:
                LB_Groups.Items.Clear();
                foreach (var item in _client.Groups)
                {
                    LB_Groups.Items.Add(item);
                }
            }
        }



        private void Fr_UserInformation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //  Show profile:
            Fr_Main.Content = new COMPONENTS.MAIN.PageShowProfile(_client, _client, Fr_UserInformation, Fr_Main);
            LB_Groups.SelectedIndex = -1;
        }

        private void LB_Groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LB_Groups.SelectedItem != null)
            {
                Fr_Main.Content = new COMPONENTS.MAIN.PageGroup(Fr_Main, (TRS_Domain.GROUP.Data)LB_Groups.SelectedItem);
            }
        }

        private void Btn_CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            FromJoinOrCreateNewGroup joinOrCreateNewGroup = new FromJoinOrCreateNewGroup();
            joinOrCreateNewGroup.ShowDialog();
            if (joinOrCreateNewGroup.DialogResult == true)
            {
                FORM_CreateGroup PopUp = new FORM_CreateGroup(_client);
                PopUp.ShowDialog();
                if (PopUp.DialogResult == true)
                {
                    _client = _clientLogic.LoadClient((_client.UserId));

                    LB_Groups.Items.Clear();
                    foreach (var item in _client.Groups)
                    {
                        LB_Groups.Items.Add((item));
                    }
                }
            }
            else
            {
                Fr_Main.Content = new FORMS.COMPONENTS.MAIN.PageJoinGroup(Fr_Main, _client, this);
            }
        }

        public static void TestMethod()
        {

        }
    }
}
