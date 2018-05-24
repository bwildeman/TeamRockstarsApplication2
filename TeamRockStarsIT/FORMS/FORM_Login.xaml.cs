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

        //  Program:
        public FormLogin()
        {
            InitializeComponent();
        }

        //  Others:
        private void Txt_Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoginValid(_loginLogic.InputFilled(Txt_Email.Text, Txt_Password.Password.ToString()));
        }

        //  Buttons:
        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            int userId = _loginLogic.Login(Txt_Email.Text, Txt_Password.Password.ToString());
            if (userId != -1)
            {
                // hide current form
                this.Hide();
                // open new form
                FormMain form = new FormMain(userId);
                 form.ShowDialog();
                // close current form
                this.Close();
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
    }
}
