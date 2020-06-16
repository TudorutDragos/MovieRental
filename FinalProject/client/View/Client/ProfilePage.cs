using client.Controller;
using client.Controller.ClientActionsHandler;
using client.Controller.Validators;
using System;
using System.Windows.Forms;

namespace client.View.Client
{
    public partial class ProfilePage : Form
    {
        MovieValidator movieValidator;
        ClientHandler clientHandler;
        LoginHandler loginHandler;
        public ProfilePage()
        {
            loginHandler = new LoginHandler();
            movieValidator = new MovieValidator();
            clientHandler = new ClientHandler();
            InitializeComponent();
        }

        private void ProfilePage_Load(object sender, EventArgs e)
        {
            label2.Text = loginHandler.GetCurrentUser();
            label3.Text = loginHandler.GetCurrentCnp();
            label1.Text = loginHandler.GetMovies();
            label4.Text = loginHandler.GetFavoriteMovies();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            SelectPage selectPage = new SelectPage();
            selectPage.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (movieValidator.ValidateMovieTitleGenreOrActors(textBox1.Text.Trim()))
            {
                clientHandler.ReturnMovie(textBox1.Text.Trim(), LoginHandler.UserCnp);
            }
            else
            {
                MessageBox.Show("Invalid name");
            }
        }
    }
}
