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
    /// Interaction logic for Members.xaml
    /// </summary>
    public partial class Members : UserControl
    {
        int groupId;
        public Members(int groupId)
        {
            this.groupId = groupId;
            InitializeComponent();
        }
    }
}
