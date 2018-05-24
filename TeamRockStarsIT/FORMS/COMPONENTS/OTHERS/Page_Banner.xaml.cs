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

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS
{
    /// <summary>
    /// Interaction logic for Page_Banner.xaml
    /// </summary>
    public partial class Page_Banner : Page
    {
        Frame frame;
        int groupId;
        public Page_Banner(Frame frame, int groupId)
        {
            this.frame = frame;
            this.groupId = groupId;
            InitializeComponent();
        }

        private void BTN_Settings_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new MAIN.PAGE_GroupControl(groupId);
        }
    }
}
