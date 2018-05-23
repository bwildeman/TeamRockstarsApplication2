using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainProgram;

namespace MainProgram.CONTROLLERS
{
    public static class ControllerLogin
    {
        /// <summary>
        /// setup database connection on form load
        /// </summary>
        /// <param name="bT_Login"></param>
        /// <param name="tB_UserName"></param>
        /// <param name="tB_PassWord"></param>
        public static void Load()
        {
            DATABASE.DbConnect.SetupConnection();
        }

        /// <summary>
        /// Check username and password with database
        /// </summary>
        /// <param name="bT_Login"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public static void Login(string userName, string password, FormLogin form)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                int userId = DATABASE.DbConnect.Login(userName, password);
                if (userId == 0)
                {
                    MessageBox.Show("Check your connection, something went wrong connecting to the database.", "Caution:");
                }
                else if (userId == -1)
                {
                    MessageBox.Show("This combination isn't in our database.", "Caution:");
                }
                else
                {
                    // hide current form
                    form.Hide();
                    // open new form
                    FORMS.FormMain form = new FORMS.FormMain(userId);
                    form.ShowDialog();
                    // close current form
                    form.Close();
                }
            }
        }

        public static bool InputFilled(string email, string password)
        {
            bool output = false;
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                output = true;
            }
            return output;
        }
    }
}
