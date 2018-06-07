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
using TRS_Domain.FORUM;

namespace TeamRockStarsIT.FORMS.COMPONENTS.CHANNEL
{
    /// <summary>
    /// Interaction logic for PAGE_FORUM.xaml
    /// </summary>
    public partial class PAGE_FORUM : Page
    {
        public PAGE_FORUM()
        {
            InitializeComponent();
        }
        #region Events

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Post[] temp = { new Post(0, 120, DateTime.Now.ToString(), "titel", "beschrijving van een post") };
            foreach (Post item in temp)
            {
                this.MainBox.Items.Add(new OTHERS.CONTENT.FORUM.UC_Post(item.date, item._titel, item._votes));
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion
        #region Sorting
        
        #region RadioButton Events
        private void RBUpVotes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RBDownVotes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RBNewest_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RBOldest_Checked(object sender, RoutedEventArgs e)
        {

        }

        #endregion
        
        #endregion
    }
}
