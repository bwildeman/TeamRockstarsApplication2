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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TRS_Domain.EVENT;
using TRS_Logic;

namespace TeamRockStarsIT.FORMS.COMPONENTS.CHANNEL
{
    /// <summary>
    /// Interaction logic for PAGE_AddEvent.xaml
    /// </summary>
    public partial class PAGE_AddEvent : Page
    {
        //  Memory:
        private readonly int _currentGroupId;
        private readonly int _userId;
        private readonly TRS_Domain.GROUP.Data _selectedGroup;
        private TRS_Domain.USER.Data _user;
        private ClientClass _client;
        private readonly Event_Logic _eventLogic = new Event_Logic();

        private Frame _mainFrame;
        private TRS_Domain.GROUP.Data _selectedItem;

        //  Private methodes:
        private void ShowWarning(string message)
        {
            Lbl_Warning.Visibility = Visibility.Visible;
            Lbl_Warning.Content = message;
        }

        public PAGE_AddEvent(TRS_Domain.GROUP.Data group, TRS_Domain.USER.Data user, Frame mainFrame, TRS_Domain.GROUP.Data selectedLbItem, ClientClass client)
        {
            InitializeComponent();
            _selectedGroup = group;
            _mainFrame = mainFrame;
            _currentGroupId = group.GroupId;
            _userId = user.UserId;
            _selectedItem = selectedLbItem;
            _user = user;
            _client = client;

            PAGE_AddEvent_Loaded();
        }

        private void PAGE_AddEvent_Loaded()
        {
            RBtn_Online.IsChecked = true;
        }

        private void RBtn_Online_Checked(object sender, RoutedEventArgs e)
        {
            TB_Adres.IsHitTestVisible = false;
            TB_Adres.Opacity = 0.5;
            Lbl_Adres.Opacity = 0.5;

            TB_Url.IsHitTestVisible = true;
            TB_Url.Opacity = 1;
            Lbl_Url.Opacity = 1;

            TB_Adres.Clear();
        }

        private void RBtn_IRL_Checked(object sender, RoutedEventArgs e)
        {
            TB_Adres.IsHitTestVisible = true;
            TB_Adres.Opacity = 1;
            Lbl_Adres.Opacity = 1;

            TB_Url.IsHitTestVisible = false;
            TB_Url.Opacity = 0.5;
            Lbl_Url.Opacity = 0.5;

            TB_Url.Clear();
        }

        private void Btn_CreateEvent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_eventLogic.CreateNewGroupEvent(new Data(_currentGroupId, _userId, TB_Name.Text, Convert.ToDateTime(DateP_Start.Value), Convert.ToDateTime(DateP_End.Value), CheckRadioButtons(), CheckLocation(), TB_Description.Text)))
                {
                    _mainFrame.Content = new MAIN.PageGroup(_mainFrame, _selectedGroup, _user, _client, MAIN.PageGroup.Channel.Event);
                }
            }
            catch(Exception ex)
            {
                ShowWarning(ex.Message);
            }
        }

         
        private string CheckLocation()
        {
            var location = "";

            if (RBtn_Online.IsChecked == true)
            {
                location = TB_Url.Text;
            }
            else if (RBtn_IRL.IsChecked == true)
            {
                location = TB_Adres.Text;
            }

            return location;
        }

        private bool CheckRadioButtons()
        {
            var isOnline = false;

            if (RBtn_Online.IsChecked == true)
            {
                isOnline = true;
            }
            else if (RBtn_IRL.IsChecked == true)
            {
                isOnline = false;
            }

            return isOnline;
        }

        private void DateP_Start_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("entered");
                _eventLogic.ValidateStartDate(DateP_Start.Value);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
