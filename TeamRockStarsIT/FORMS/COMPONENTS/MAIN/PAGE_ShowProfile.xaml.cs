using System;
using System.Collections.Generic;
using System.IO;
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
using TRS_Domain;
using TRS_Domain.USER;
using TRS_Logic;

namespace TeamRockStarsIT.FORMS.COMPONENTS.MAIN
{
    /// <summary>
    /// Interaction logic for PAGE_ShowProfile.xaml
    /// </summary>
    public partial class PageShowProfile : Page
    {
        //  References:
        TRS_Logic.UserLogic _userLogic = new TRS_Logic.UserLogic();
        TRS_Logic.InterestLogic _interestLogic = new InterestLogic();


        // Memory
        private TRS_Domain.USER.Data _client;
        private TRS_Domain.USER.Data _selectedUser;
        private List<TRS_Domain.USER.Data> AllUsers;
        private Frame _contentFrame;
        private Frame _clientInfoFrame;

        //  Private methodes:
        private void FillLB_Users(List<Data> input)
        {
            LB_Users.Items.Clear();

            if (input.Count !=0)
            {
                foreach (var item in input)
                {
                    LB_Users.Items.Add(item);
                }
            }
        }

        //  Program
        public PageShowProfile(TRS_Domain.USER.Data client, TRS_Domain.USER.Data selectedUser, Frame userInfo, Frame contentFrame)
        {
            _client = client;
            _selectedUser = selectedUser;
            _clientInfoFrame = userInfo;
            _contentFrame = contentFrame;
            _contentFrame.NavigationService.RemoveBackEntry();
            InitializeComponent();
            Loaded += PAGE_ShowProfile_Loaded;
        }

        private void PAGE_ShowProfile_Loaded(object sender, RoutedEventArgs e)
        {
            //  Get new user update:
            _selectedUser = _userLogic.UpdateUserInformation(_selectedUser);

            //  Check if selecteduser = client:
            if (_selectedUser.UserId == _client.UserId)
            {
                _client = _selectedUser;
                _clientInfoFrame.Content = new OTHERS.PageUserInformation(_client, _clientInfoFrame, _contentFrame);
            }

            // Show selectedUser information:
            LblName.Content = $"{_selectedUser.Name} {_selectedUser.Surname}";
            LblEmail.Content = _selectedUser.Email;
            LblRegion.Content = $"{_selectedUser.Region}, {_selectedUser.Adres}";
            LblPhoneNumber.Content = _selectedUser.Phonenumber;
            LblFunction.Content = _selectedUser.Department;
            LblQoute.Content = _selectedUser.Quote;
            TxtPortfolio.Text = _selectedUser.Portfolio;
            LoadUserInterestsListBox(_selectedUser.UserId);

            if (_selectedUser.Img != null)
            {
                var image = new BitmapImage();
                using (var mem = new MemoryStream(_selectedUser.Img))
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                image.Freeze();
                Rectangle_Picture.Fill = new ImageBrush(image);
            }

            // Get all users:
            AllUsers = _userLogic.AllUsers();
            FillLB_Users(AllUsers);

            //  Check if Client has admin rights
            if (_client.Type == 1 || _client.UserId == _selectedUser.UserId)
            {
                Btn_Edit.Visibility = Visibility.Visible;
            }
        }

        private void LoadUserInterestsListBox(int userId)
        {
            LB_Interest_.ItemsSource = _interestLogic.GetAllUsertInterests(userId);
            LB_Interest_.DisplayMemberPath = "Name";
            LB_Interest_.SelectedValuePath = "InterestId";
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            _contentFrame.Content = new PageEditProfile(_client, _selectedUser, _contentFrame, _clientInfoFrame);
        }

        private void LB_Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LB_Users.SelectedItem != null)
            {
                _contentFrame.Content = new PageShowProfile(_client, (TRS_Domain.USER.Data)LB_Users.SelectedItem, _clientInfoFrame, _contentFrame);
            }
        }

        private void Btn_AddUser_Click(object sender, RoutedEventArgs e)
        {
            _contentFrame.Content = new PAGE_CreateUser(_client, _selectedUser, _clientInfoFrame, _contentFrame);
        }

        private void TxtUserSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUserSearch.Text))
            {
                List<TRS_Domain.USER.Data> SearchResults = new List<Data>();
                string SearchInput = TxtUserSearch.Text;
                foreach (var item in AllUsers)
                {
                    if (item.Name.Contains(SearchInput) || item.Surname.Contains(SearchInput))
                    {
                        SearchResults.Add(item);
                    }
                }
                FillLB_Users(SearchResults);
            }
            else
            {
                FillLB_Users(AllUsers);
            }
        }
    }
}
