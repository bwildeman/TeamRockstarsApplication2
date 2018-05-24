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

namespace TeamRockStarsIT.FORMS.COMPONENTS.OTHERS.MENU
{
    /// <summary>
    /// Interaction logic for Channels.xaml
    /// </summary>
    public partial class Channels : UserControl
    {
        int groupId;
        public Channels(int groupId)
        {
            this.groupId = groupId;
            InitializeComponent();
        }

        private void BTN_AddChannel_Click(object sender, RoutedEventArgs e)
        {
            Window w = new WINDOW_AddChannel();
            w.ShowDialog();
            if (w.DialogResult == true)
            {
                Console.WriteLine("it worked");
            }
        }
    }
}
