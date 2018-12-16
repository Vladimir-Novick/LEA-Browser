using System;
using System.Windows.Forms;
using LEA.Lib.DB;

namespace LEA.Browser
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            isLogin = false;
        }

        public static Boolean isLogin { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_UserName.Text=="" || txt_Password.Text=="")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                DBReader dBReader = new DBReader();
                dBReader.GetUserName(out string UserName, out String Password);
                if (UserName.Equals(txt_UserName.Text) && Password.Equals(txt_Password.Text))
                {
                    isLogin = true;
                    Close();
                } else
                {
                    isLogin = false;
                   labelError.Text = "The user name or password is incorrect";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            labelError.Text = "";
        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {
            labelError.Text = "";
        }
    }
}
