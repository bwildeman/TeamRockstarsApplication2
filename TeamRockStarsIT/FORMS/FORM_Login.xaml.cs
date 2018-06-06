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

namespace TeamRockStarsIT.FORMS
{
    /// <summary>
    /// Interaction logic for FORM_Login.xaml
    /// </summary>
    public partial class FormLogin : Window
    {
        //  Logic reference:
        ControllerLogin _loginLogic = new ControllerLogin();
        ClientClass Client = new ClientClass();
        //  Private methodes:
        private void LoginValid(bool input)
        {
            if (input)
            {
                Btn_Login.Visibility = Visibility.Visible;
            }
            else
            {
                Btn_Login.Visibility = Visibility.Hidden;
            }
        }
        private void SetEmailTxtColor(bool correct)
        {
            if (correct)
            {
                Txt_Email.BorderBrush = new SolidColorBrush(Color.FromRgb(179,171,171));
                Txt_Email.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                Lbl_Warning.Visibility = Visibility.Hidden;
            }
            else
            {
                Txt_Email.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                Txt_Email.Background = new SolidColorBrush(Color.FromRgb(255, 167, 167));
            }
        }

        //  Program:
        public FormLogin()
        {
            InitializeComponent();
            Client.LoadIn();
        }

        //  Others:
        private void Txt_Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoginValid(_loginLogic.InputFilled(Txt_Email.Text, Txt_Password.Password.ToString()));
        }

        //  Buttons:
        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client.Login(Txt_Email.Text, Txt_Password.Password.ToString());
                while (Client.loginstate == false)
                {

                }
                
                int userId = Client.GetLoginId();
                if (userId != -1)
                {
                    // hide current form
                    this.Hide();
                    // open new form
                    FormMain form = new FormMain(userId,Client);
                    form.ShowDialog();
                    // close current form
                    this.Close();
                }
            }
            catch (InvalidLoginCombination ex)
            {
                Lbl_Warning.Content = ex.Message;
                Lbl_Warning.Visibility = Visibility.Visible;
            }
            catch(EmptyField ex)
            {
                Lbl_Warning.Content = ex.Message;
                Lbl_Warning.Visibility = Visibility.Visible;
            }
            catch(InvalidEmail ex)
            {
                Lbl_Warning.Content = ex.Message;
                Lbl_Warning.Visibility = Visibility.Visible;
            }
        }

        private void Txt_Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            LoginValid(_loginLogic.InputFilled(Txt_Email.Text, Txt_Password.Password.ToString()));
        }

        private void Txt_Password_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Btn_Login.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Txt_Email_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SetEmailTxtColor(_loginLogic.ValidEmail(Txt_Email.Text));
            }
            catch(InvalidEmail ex)
            {
                SetEmailTxtColor(false);
                Lbl_Warning.Content = ex.Message;
                Lbl_Warning.Visibility = Visibility.Visible;
            }
        }
    }
}
