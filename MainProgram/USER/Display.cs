using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram.USER
{
    public static class Display
    {
        public static void ShowAllGroups(ListBox list, Data user)
        {
            list.Items.Clear();
            foreach (var item in user.Groups)
            {
                list.Items.Add(item);
            }
        }
    }
}
