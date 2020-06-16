using client.Controller;
using client.View.Admin;
using client.View.Client;
using System;
using System.Windows.Forms;

namespace client.View
{
    public partial class Login : Form
    {
        LoginHandler loginHandler;
        public Login()
        {
            loginHandler = new LoginHandler();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "admin" && txtPassword.Text.Trim() == "admin")
            {
                SelectPageAdmin selectPageAdmin = new SelectPageAdmin();
                this.Hide();
                selectPageAdmin.Show();
                MessageBox.Show("Login as admin");
            }
            else
            {
                if (loginHandler.GetDataFromDb(txtUsername.Text.Trim(), txtPassword.Text.Trim()))
                {
                    SelectPage selectPage = new SelectPage();
                    this.Hide();
                    selectPage.Show();
                    MessageBox.Show("Login as client");
                }
                else
                {
                    MessageBox.Show("Incorect username or password");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
