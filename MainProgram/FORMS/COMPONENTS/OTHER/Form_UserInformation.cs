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

namespace MainProgram.FORMS.COMPONENTS.OTHER
{
    public partial class FormUserInformation : Form
    {
        private USER.Data _user;

        public FormUserInformation(USER.Data user)
        {
            this._user = user;
            InitializeComponent();
        }

        private void Form_UserInformation_Load(object sender, EventArgs e)
        {
            CONTROLLERS.ControllerMain.RoundPictureBox(PB_ProfilePicture);
            _user.UpdateUserInformation();
            this.L_UserName.Text = _user.Name + " " + _user.Surname;
            //this.PB_ProfilePicture.ImageLocation = user.PhotoLink;
            this.PB_ProfilePicture.Image = null;
            if (_user.Img != null)
            {
                MemoryStream ms = new MemoryStream(_user.Img);
                this.PB_ProfilePicture.Image = Image.FromStream(ms);
            }
        }

        public void Updateuser()
        {
            _user.UpdateUserInformation();
        }
        private void Form_UserInformation_DoubleClick(object sender, EventArgs e)
        { CONTROLLERS.ControllerMain.ChangePanels(FORMS.FormMain.Page.Profile, _user); }

        private void PB_ProfilePicture_DoubleClick(object sender, EventArgs e)
        { CONTROLLERS.ControllerMain.ChangePanels(FORMS.FormMain.Page.Profile, _user); }

        private void L_UserName_DoubleClick(object sender, EventArgs e)
        { CONTROLLERS.ControllerMain.ChangePanels(FORMS.FormMain.Page.Profile, _user); }
    }

}
