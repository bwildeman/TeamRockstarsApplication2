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

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS
{
    /// <summary>
    /// Interaction logic for FROM_JoinOrCreateNewGroup.xaml
    /// </summary>
    public partial class FromJoinOrCreateNewGroup : Window
    {
        public FromJoinOrCreateNewGroup()
        {
            InitializeComponent();
        }

        private void ExistingGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void NewGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
