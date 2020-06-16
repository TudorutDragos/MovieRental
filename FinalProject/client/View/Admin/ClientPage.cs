using client.Controller;
using client.Controller.AdminActionsHandlers;
using client.Controller.Validators;
using System;
using System.Windows.Forms;

namespace client.View.Admin
{
    public partial class ClientPage : Form
    {
        LoginHandler loginHandler;
        AdminClientHandler adminClientHandler;
        ClientValidator clientValidator;
        public ClientPage()
        {
            loginHandler = new LoginHandler();
            adminClientHandler = new AdminClientHandler();
            clientValidator = new ClientValidator();
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (clientValidator.ValidateClient(txtCnp.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim()))
            {
                adminClientHandler.CreateClient(txtCnp.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim());
            }
            else
            {
                MessageBox.Show("Invalid data");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SelectPageAdmin selectPageAdmin = new SelectPageAdmin();
            selectPageAdmin.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (clientValidator.ValidateClientCnp(txtCnp.Text.Trim()))
            {
                core.Models.Client client = adminClientHandler.ReadClientByCnp(txtCnp.Text.Trim());
                MessageBox.Show("Client:\nName: " + client.firstName + " " + client.lastName + "\nCnp: " + client.cnp + "\nAddress: " + client.address);
            }
            else
            {
                MessageBox.Show("Invalid data");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (clientValidator.ValidateClient(txtCnp.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim()))
            {
                adminClientHandler.UpdateClient(txtCnp.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(),textBox1.Text.Trim());
            }
            else
            {
                MessageBox.Show("Invalid data");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (clientValidator.ValidateClientCnp(txtCnp.Text.Trim()))
            {
                adminClientHandler.DeleteClientByCnp(txtCnp.Text.Trim());
                loginHandler.DeleteLogin(txtCnp.Text.Trim());
                MessageBox.Show("Client deleted");
            }
            else
            {
                MessageBox.Show("Invalid data");
            }
        }

        private void ClientPage_Load(object sender, EventArgs e)
        {

        }
    }
}
