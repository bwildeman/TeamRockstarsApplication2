using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeamRockStarsIT.FORMS.COMPONENTS.OTHERS;
using TRS_Domain.INTEREST;
using TRS_Logic;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace TeamRockStarsIT.FORMS.COMPONENTS.MAIN
{
    /// <summary>
    /// Interaction logic for PAGE_EditProfile.xaml
    /// </summary>
    public partial class PageEditProfile : Page
    {
        //References:
        UserLogic _userLogic = new UserLogic();
        InterestLogic _interestLogic = new InterestLogic();

        //Memory:
        private TRS_Domain.USER.Data _client;
        private TRS_Domain.USER.Data _selectedUser;
        private Frame _contentFrame;
        private Frame _clientFrame;
        private List<TRS_Domain.INTEREST.Data> _interestList;

        //  Private methodes:
        private void FillComboboxes()
        {
            CBox_Region.ItemsSource = new List<string> { "Groningen", "Friesland", "Drenthe", "Overijssel", "Flevoland", "Gelderland", "Utrecht", "Noord-Holland", "Zuid-Holland", "Zeeland", "Noord-Brabant", "Limburg" };
            CBox_Gender.ItemsSource = new List<string> { "Female", "Male", "Unassigned" };

            CB_InterestCategory.ItemsSource = _interestLogic.GetAllInterestCategories();
            CB_InterestCategory.DisplayMemberPath = "Name";
            CB_InterestCategory.SelectedValuePath = "CategoryId";
        }

        private void SaveUserInterests(int userId)
        {
            _interestList = new List<Data>((LB_UserInterests.Items.Cast<TRS_Domain.INTEREST.Data>().ToList()));

            _interestLogic.SaveInterests(_interestList, _selectedUser.UserId);
        }

        private void FillUserInterestListbox(int userId)
        {
            LB_UserInterests.Items.Clear();
            List<TRS_Domain.INTEREST.Data> usetInterests = _interestLogic.GetAllUsertInterests(userId);
            foreach (var item in usetInterests)
            {
                LB_UserInterests.Items.Add(item);
            }
        }

        private void FillCategoryInterestsListbox()
        {
            LB_Interests.Items.Clear();
            List<TRS_Domain.INTEREST.Data> categoryInterest =
                _interestLogic.GetUserCategoryInterests((int)CB_InterestCategory.SelectedValue, _selectedUser.UserId);
            foreach (var item in categoryInterest)
            {
                LB_Interests.Items.Add(item);
            }
        }

        private void RemoveUserInterestFromList()
        {
            if (LB_UserInterests.SelectedItem != null)
            {         
                // remove selected interest
                LB_UserInterests.Items.Remove(LB_UserInterests.SelectedItem);
            }
        }

        private void RemoveInterestFromCategoryList()
        {
            if (LB_Interests.SelectedItem != null)
            {              
                // remove selected interest
                LB_Interests.Items.Remove(LB_Interests.SelectedItem);
            }
        }

        private void FillUserInformation()
        {
            TB_Name.Text = _selectedUser.Name;
            TB_Surname.Text = _selectedUser.Surname;
            CBox_Region.Text = _selectedUser.Region;
            TB_Residence.Text = _selectedUser.Adres;
            TB_Email.Text = _selectedUser.Email;
            TB_PhoneNumber.Text = _selectedUser.Phonenumber;
            TB_Function.Text = _selectedUser.Department;
            TB_Qoute.Text = _selectedUser.Quote;
            TB_Portfolio.Text = _selectedUser.Portfolio;
            switch (_selectedUser.Gender)
            {
                case 0:
                    CBox_Gender.Text = "Female";

                    break;
                case 1:
                    CBox_Gender.Text = "Male";
                    break;
                case 2:
                    CBox_Gender.Text = "Unassigned";
                    break;
            }

        }
        public PageEditProfile(TRS_Domain.USER.Data client, TRS_Domain.USER.Data selectedUser, Frame contentFrame, Frame clientInfo)
        {
            _client = client;
            _selectedUser = selectedUser;
            _contentFrame = contentFrame;
            _clientFrame = clientInfo;
            _contentFrame.NavigationService.RemoveBackEntry();
            InitializeComponent();

            Loaded += PAGE_EditProfile_Loaded;
        }

        private void PAGE_EditProfile_Loaded(object sender, RoutedEventArgs e)
        {
            //  Fill comboboxes:
            FillComboboxes();

            // Fill listbox
            FillUserInterestListbox(_selectedUser.UserId);

            //Fill in selected user information
            FillUserInformation();

        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            _contentFrame.Content = new PageShowProfile(_client, _selectedUser, _clientFrame, _contentFrame);
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_userLogic.SaveUser(_selectedUser.UserId, TB_Name.Text, TB_Surname.Text, CBox_Region.Text, TB_Residence.Text, TB_Email.Text, TB_PhoneNumber.Text, TB_ProfilePic.Text, CBox_Gender.Text, TB_Function.Text, TB_Qoute.Text, TB_Portfolio.Text))
                {
                    SaveUserInterests(_selectedUser.UserId);
                    _contentFrame.Content = new PageShowProfile(_client, _selectedUser, _clientFrame, _contentFrame);
                }
                else
                {
                    Console.WriteLine("Something went wrong in saving the user, check PAGE_EditProfile.xaml.cs");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Btn_GetImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filedialog.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp";
            filedialog.FilterIndex = 2;
            if (filedialog.ShowDialog() == true)
            {
                TB_ProfilePic.Text = filedialog.FileName;
            }
        }

        private void CB_InterestCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillCategoryInterestsListbox();
        }


        private void LB_UserInterests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RemoveUserInterestFromList();
            SaveUserInterests(_selectedUser.UserId);
            FillUserInterestListbox(_selectedUser.UserId);
            FillCategoryInterestsListbox();
        }

        private void LB_Interests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _interestLogic.AddUsertInterest(_selectedUser.UserId, (TRS_Domain.INTEREST.Data)LB_Interests.SelectedItem);
            RemoveInterestFromCategoryList();
            FillUserInterestListbox(_selectedUser.UserId);
        }

        private void Btn_AddInterest_Click(object sender, RoutedEventArgs e)
        {
            FORM_CreateInterest createNewInterest = new FORM_CreateInterest(_selectedUser);
            createNewInterest.Show();
            if (createNewInterest.DialogResult.HasValue && createNewInterest.DialogResult.Value)
            {

            }

        }
    }
}
