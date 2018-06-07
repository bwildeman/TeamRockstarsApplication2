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

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS.CONTENT.FORUM
{
    /// <summary>
    /// Interaction logic for UC_Post.xaml
    /// </summary>
    public partial class UC_Post : UserControl
    {
        public UC_Post(DateTime date, string Name, int likes)
        {
            InitializeComponent();
            this.TB_Date.Text = date.ToString("H:m op d MMMM, yyyy");
            this.TB_Title.Text = Name;
            this.TB_Likes.Text = likes.ToString();
        }

        private void BTN_Like_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Dislike_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
