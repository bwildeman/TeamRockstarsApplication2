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

namespace TeamRockStarsIT.FORMS.COMPONENTS.MAIN
{
    /// <summary>
    /// Interaction logic for PAGE_CreateUser.xaml
    /// </summary>
    public partial class PAGE_CreateUser : Page
    {
        //  Add reference:
        TRS_Logic.UserLogic userLogic = new TRS_Logic.UserLogic();
        // Memory
        private TRS_Domain.USER.Data _client;
        private TRS_Domain.USER.Data _selectedUser;
        private Frame _contentFrame;
        private Frame _clientInfoFrame;

        //  Private methodes:
        private void RequiredFieldCheck(System.Windows.Controls.TextBox Field)
        {
            if (!string.IsNullOrEmpty(Field.Text))
            {
                Field.BorderBrush = new SolidColorBrush(Color.FromRgb(179, 171, 171));
                Field.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else
            {
                Field.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                Field.Background = new SolidColorBrush(Color.FromRgb(255, 167, 167));
            }
        }

        public PAGE_CreateUser(TRS_Domain.USER.Data client, TRS_Domain.USER.Data selectedUser, Frame userInfo, Frame contentFrame)
        {
            _client = client;
            _selectedUser = selectedUser;
            _clientInfoFrame = userInfo;
            _contentFrame = contentFrame;
            _contentFrame.NavigationService.RemoveBackEntry();
            InitializeComponent();
            Loaded += PAGE_CreateUser_Loaded;
        }

        private void PAGE_CreateUser_Loaded(object sender, RoutedEventArgs e)
        {
            DateP_DOB.SelectedDate = DateTime.Now;
        }

        private void TB_Name_LostFocus(object sender, RoutedEventArgs e)
        {
            RequiredFieldCheck(TB_Name);
        }

        private void TB_Surname_LostFocus(object sender, RoutedEventArgs e)
        {
            RequiredFieldCheck(TB_Surname);
        }

        private void TB_Email_LostFocus(object sender, RoutedEventArgs e)
        {
            RequiredFieldCheck(TB_Email);
        }

        private void TB_PhoneNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            RequiredFieldCheck(TB_PhoneNumber);
        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (userLogic.AddUser(TB_Name.Text, TB_Surname.Text, TB_Email.Text, CBox_Region.Text, TB_PhoneNumber.Text, TB_Adres.Text, CBox_Gender.Text, RBtn_AdminNo.IsChecked, RBtn_AdminYes.IsChecked, DateP_DOB.SelectedDate.Value))
                {
                    _contentFrame.Content = new PageShowProfile(_client, _client, _clientInfoFrame, _contentFrame);
                }
                else
                {
                    Console.WriteLine("Something went wrong in saving the user, check PAGE_EditProfile.xaml.cs");
                }
            }
            catch (Exception ex)
            {
                Lbl_Warning.Visibility = Visibility.Visible;
                Lbl_Warning.Content = ex.Message;
            }
        }
    }
}
