﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using TeamRockStarsIT.FORMS.COMPONENTS.OTHERS;
using TRS_Domain.EXCEPTIONS;
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
        private DispatcherTimer timer;

        //  Private methodes:
        private void ShowWarning(string message)
        {
            Lbl_Warning.Visibility = Visibility.Visible;
            Lbl_Warning.Content = message;
        }

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
            if (CB_InterestCategory.SelectedIndex != -1)
            {
                LB_Interests.Items.Clear();
                List<TRS_Domain.INTEREST.Data> categoryInterest =
                    _interestLogic.GetUserCategoryInterests((int)CB_InterestCategory.SelectedValue, _selectedUser.UserId);
                foreach (var item in categoryInterest)
                {
                    LB_Interests.Items.Add(item);
                }
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
            TB_Quote.Text = _selectedUser.Quote;
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

        private void SetTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Lbl_PasswordMessage.Visibility = Visibility.Hidden;
            timer.Stop();
        }

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

        private void ChangePasswordValidation()
        {
            if (_client.UserId == _selectedUser.UserId || _client.Type == 1)
            {
                Btn_ChangePassword.Visibility = Visibility.Visible;
            }
        }

        //  Program:

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

            //  Check if the password can be changed:
            ChangePasswordValidation();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            _contentFrame.Content = new PageShowProfile(_client, _selectedUser, _clientFrame, _contentFrame);
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_userLogic.SaveUser(_selectedUser.UserId, TB_Name.Text, TB_Surname.Text, CBox_Region.Text, TB_Residence.Text, TB_Email.Text, TB_PhoneNumber.Text, TB_ProfilePic.Text, CBox_Gender.Text, TB_Function.Text, TB_Quote.Text, TB_Portfolio.Text))
                {
                    SaveUserInterests(_selectedUser.UserId);
                    _contentFrame.Content = new PageShowProfile(_client, _selectedUser, _clientFrame, _contentFrame);
                }
                else
                {
                    Console.WriteLine("Something went wrong in saving the user, check PAGE_EditProfile.xaml.cs");
                }
            }
            catch (MaxPhotoSizeReached ex)
            {
                TB_ProfilePic.Text = "";
                ShowWarning(ex.Message);
            }
            catch (Exception ex)
            {
                ShowWarning(ex.Message);
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
            bool? result = createNewInterest.ShowDialog();
            switch (result)
            {
                case true:
                    Console.WriteLine("Result is true");
                    break;

                default:
                    break;
            }
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

        private void TB_PhoneNumber_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = (e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9);
        }

        private void Btn_ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            FORM_ChangePassword Dialog = new FORM_ChangePassword(_selectedUser, _client);
            bool? DialogResult = Dialog.ShowDialog();
            switch (DialogResult)
            {
                case true:
                    Lbl_PasswordMessage.Content = "Password saved";
                    break;
                case false:
                    Lbl_PasswordMessage.Content = "Action cancelled";
                    break;
                default:
                    break;
            }
            Lbl_PasswordMessage.Visibility = Visibility.Visible;
            SetTimer();
        }

        private void TB_Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
