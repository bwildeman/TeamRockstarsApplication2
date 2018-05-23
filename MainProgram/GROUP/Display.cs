using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram.GROUP
{
    public static class Display
    {
        /// <summary>
        /// Returns a SmallSelector Form for the given group
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public static Form ShowSmallSelector(USER.Data client, GROUP.Data group)
        {
            return new COMPONENTS.SmallSelector(group, client)
            {
                TopLevel = false,
                AutoScroll = false,     //  UI  This could be changed
                Visible = true
            };
        }
    }
}
