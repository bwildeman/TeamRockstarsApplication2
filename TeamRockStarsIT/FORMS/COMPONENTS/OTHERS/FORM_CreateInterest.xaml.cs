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
using TRS_Domain.INTEREST;
using TRS_Logic;

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS
{
    /// <summary>
    /// Interaction logic for FORM_CreateInterest.xaml
    /// </summary>
    public partial class FORM_CreateInterest : Window
    {
        private InterestLogic interestLogic = new InterestLogic();
        private ExceptionHandler exceptionHandler = new ExceptionHandler();
        private TRS_Domain.USER.Data user;

        public FORM_CreateInterest(TRS_Domain.USER.Data inputUser)
        {
            InitializeComponent();
            user = inputUser;
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (exceptionHandler.NewInterest(TB_InterestName.Text))
                {
                    interestLogic.CreateNewInterest(TB_InterestName.Text, (int) CB_InterestCategory.SelectedValue);
                    LB_NonVerifiedInterests.Items.Clear();
                    LB_VerifiedInterests.Items.Clear();
                    FillListBoxes();
                }
            }
            catch (EmptyField ex)
            {
                ShowWarning(ex.Message);
            }
        }

        private void ShowWarning(string message)
        {
            Lbl_Warning.Visibility = Visibility.Visible;
            Lbl_Warning.Content = message;
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            FillListBoxes();
        }

        private void FillComboBox()
        {
            CB_InterestCategory.ItemsSource = interestLogic.GetAllInterestCategories();
            CB_InterestCategory.DisplayMemberPath = "Name";
            CB_InterestCategory.SelectedValuePath = "CategoryId";
            CB_InterestCategory.SelectedIndex = 0;
        }

        private void FillListBoxes()
        {
            List<TRS_Domain.INTEREST.Data> nonVerifiedInterests = new List<Data>(interestLogic.GetAllNotVerifiedInterests());
            foreach (var interest in nonVerifiedInterests)
            {
                LB_NonVerifiedInterests.Items.Add(interest);
            }

            List<TRS_Domain.INTEREST.Data> verifiedInterests = new List<Data>(interestLogic.GetAllVerifiedInterests());
            foreach (var interest in verifiedInterests)
            {
                LB_VerifiedInterests.Items.Add(interest);
            }
        }

        private void LB_VerifiedInterests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LB_VerifiedInterests.SelectedItem != null)
            {
                if (user.Type == 1)
                {
                    var selectedItem = (TRS_Domain.INTEREST.Data)LB_VerifiedInterests.SelectedItem;
                    interestLogic.UnVerifyInterest(selectedItem.InterestId);
                    LB_VerifiedInterests.Items.Remove(selectedItem);
                    LB_NonVerifiedInterests.Items.Add(selectedItem);
                }
            }

        }

        private void LB_NonVerifiedInterests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LB_NonVerifiedInterests.SelectedItem != null)
            {
                if (user.Type == 1)
                {
                    var selectedItem = (TRS_Domain.INTEREST.Data)LB_NonVerifiedInterests.SelectedItem;
                    interestLogic.VerifyInterest(selectedItem.InterestId);
                    LB_NonVerifiedInterests.Items.Remove(selectedItem);
                    LB_VerifiedInterests.Items.Add(selectedItem);
                }
            }

        }
    }
}
