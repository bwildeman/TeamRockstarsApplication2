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
    public partial class ProfileEdit : Form
    {
        private USER.Data _user;
        private byte[] _profilepicture;
        public ProfileEdit(USER.Data selectedUser)
        {
            _user = selectedUser;
            InitializeComponent();

        }

        private void Form_ProfileEdit_Load(object sender, EventArgs e)
        {
            TB_Name.Text = _user.Name + " " + _user.Surname;
            TB_Department.Text = _user.Department;
            TB_Email.Text = _user.Email;
            TB_PhoneNR.Text = _user.Phonenumber;
            TB_Quote.Text = _user.Quote;
            TB_Residence.Text = _user.Adres;
            TB_PhotoLink.Text = _user.PhotoLink;
            comboB_Region.Text = _user.Region;
            TB_Portfolio.Text = _user.Portfolio;
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            CONTROLLERS.ControllerMain.ChangePanels(FORMS.FormMain.Page.Profile);
        }

        private void BT_Confirm_Click(object sender, EventArgs e)
        {
            int naamsplits = TB_Name.Text.IndexOf(" ");
            string firstname = TB_Name.Text.Substring(0, naamsplits);
            string surname = TB_Name.Text.Substring(naamsplits + 1);

            string region = comboB_Region.Text;
            if (TB_ProfilePicture.Text != String.Empty)
            {
                Savepicture(Image.FromFile(TB_ProfilePicture.Text));
                DATABASE.DbConnect.UpdateUserInformation(firstname, surname, TB_Email.Text, region, TB_Department.Text, TB_PhoneNR.Text, TB_Quote.Text, TB_Portfolio.Text, TB_PhotoLink.Text, TB_Residence.Text, _user.UserId, _profilepicture);

            }
            else
                DATABASE.DbConnect.UpdateUserInformation(firstname, surname, TB_Email.Text, region, TB_Department.Text, TB_PhoneNR.Text, TB_Quote.Text, TB_Portfolio.Text, TB_PhotoLink.Text, TB_Residence.Text, _user.UserId);
            CONTROLLERS.ControllerMain.ChangePanels(FORMS.FormMain.Page.Profile);
        }
        private void BT_ProfilePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filedialog.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp";
            filedialog.FilterIndex = 2;
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                TB_ProfilePicture.Text = filedialog.FileName;


            }
        }

        public void Savepicture(Image profilepicture)
        {
            MemoryStream ms = new MemoryStream();
            profilepicture.Save(ms, profilepicture.RawFormat);
            byte[] a = ms.GetBuffer();
            ms.Close();
            _profilepicture = a;
        }

        private void BT_ProfilePicture_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filedialog.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp";
            filedialog.FilterIndex = 2;
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                TB_ProfilePicture.Text = filedialog.FileName;


            }
        }
    }
}
