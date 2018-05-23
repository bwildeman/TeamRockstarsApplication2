using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProgram.FORMS.COMPONENTS.MAINPANEL
{
    public partial class ProfileShow : Form
    {
        private USER.Data _user;
        private USER.Data _client;

        public ProfileShow(USER.Data user, USER.Data client)
        {
            _user = user;
            _client = client;
            InitializeComponent();
        }

        private void Form_ProfileShow_Load(object sender, EventArgs e)
        {
            if (_client.UserId != _user.UserId && _client.Type != 1)
            {
                BT_EditProfile.Visible = false;
            }
            _user.UpdateUserInformation();
            
            LblName.Text = _user.Name + " " + _user.Surname;
            LblEmail.Text = _user.Email;
            LblRegion.Text = _user.Region;
            LblDepartment.Text = _user.Department;
            LblTelephoneNumber.Text = _user.Phonenumber;
            LblQuote.Text = _user.Quote;
            //PBoxUser.ImageLocation = User.PhotoLink;
            if (_user.Img != null)
            {
                MemoryStream ms = new MemoryStream(_user.Img);
                PBoxUser.Image = Image.FromStream(ms);
            }
            LbResidence.Text = _user.Adres;
            LbPortfolio.Text = _user.Portfolio;
        }

        private void BT_EditProfile_Click_1(object sender, EventArgs e)
        {
            CONTROLLERS.ControllerMain.ChangePanels(FORMS.FormMain.Page.ProfileEdit);
        }
    }
}
