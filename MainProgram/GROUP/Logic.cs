using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProgram.DATABASE;
using MainProgram.GROUP.COMPONENTS.POPUPS;

namespace MainProgram.GROUP
{
    public static class Logic
    {
        /// <summary>
        ///     Function that builds a group
        ///     and makes sure its not a duplicate
        /// </summary>
        /// <explanation>
        /// multi-step function
        /// step:   
        ///     1   Choose a interest
        ///         NotImplemented yet
        ///         
        ///     2   Opens a form which returns a new group name and description
        ///         <see cref="GroupBuilder"/>
        ///         <seealso cref="GROUP.Logic.AvailableName(string)"/>
        ///         
        ///     3   Stores the values into the database as a new group
        ///         <see cref="DbConnect.AddGroup(string, string)"/>
        /// </explanation>
        public static void CreateGroup()
        {
            string name = "";
            string description = "";

            //  Open Group builder Form
            using (COMPONENTS.POPUPS.GroupBuilder form = new COMPONENTS.POPUPS.GroupBuilder())
            {
                //  This returns a group that is not a duplicate in name
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    name = form.GroupName;
                    description = form.GroupDescription;
                }
                else
                {
                }
            }

            //  Store group in the database
            DATABASE.DbConnect.AddGroup(name, description);
        }

        public static void JoinGroup(USER.Data client, GROUP.Data myGroup)
        {
            DATABASE.DbConnect.JoinGroup(client, myGroup);
        }
        /// <summary>
        /// checks if the name chosen is already used
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        ///     misses a Database function that returns all groups that are currently in use.
        /// </remarks>
        internal static bool AvailableName(string input)
        {
            GROUP.Data[] allGroups = new Data[0];

            //AllGroups = DATABASE.DBConnect.GetAllGroups();

            //  check if the name is available
            foreach (GROUP.Data group in allGroups)
            {
                if (group.Name == input)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
