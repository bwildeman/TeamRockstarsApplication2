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
using TRS_Domain.EXCEPTIONS;
using TRS_Logic;

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS
{
    /// <summary>
    /// Interaction logic for FORM_ChangePassword.xaml
    /// </summary>
    public partial class FORM_ChangePassword : Window
    {
        //  Add references:
        UserLogic userLogic = new UserLogic();
        Random rnd = new Random();

        //  Memory:
        TRS_Domain.USER.Data _selectedUser;
        private string PresetPassword = "RockStars123";


        //  Private methodes:
        private void CheckboxChanged(object sender, RoutedEventArgs e)
        {
            if (ChBox_Reset.IsChecked ?? false)
            {
                TB_OldPassword.IsEnabled = false;
                TB_OldPassword.Password = "";
                Lbl_OldPassword.Opacity = 0.5;
                SetNewPassword( PresetPassword, true);
                Lbl_Warning.Content = $"The password will be reset to {PresetPassword}";
                Lbl_Warning.Visibility = Visibility.Visible;
            }
            else
            {
                TB_OldPassword.IsEnabled = true;
                Lbl_OldPassword.Opacity = 1;
                SetNewPassword("", false);
                Lbl_Warning.Visibility = Visibility.Hidden;
            }
        }
        private void SetNewPassword(string input, bool locked)
        {
            TB_NewPOne.Password = input;
            TB_NewPTwo.Password = input;
            TB_NewPOne.IsEnabled = !locked;
            TB_NewPTwo.IsEnabled = !locked;
        }

        public FORM_ChangePassword(TRS_Domain.USER.Data selectedUser)
        {
            _selectedUser = selectedUser;
            InitializeComponent();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (userLogic.ChangePassword(TB_OldPassword.Password.ToString(), TB_NewPOne.Password.ToString(), TB_NewPTwo.Password.ToString(), ChBox_Reset.IsChecked, _selectedUser))
                {
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    Lbl_Warning.Content = "Something went wrong.";
                    Lbl_Warning.Visibility = Visibility.Visible;
                }
            }
            catch(PasswordNotFound ex)
            {
                Lbl_Warning.Content = ex.Message;
                TB_OldPassword.BorderBrush = new SolidColorBrush(Color.FromRgb(179, 171, 171));
                TB_OldPassword.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            catch(Exception ex)
            {
                Lbl_Warning.Content = ex.Message;
            }
            finally
            {
                Lbl_Warning.Visibility = Visibility.Visible;
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
