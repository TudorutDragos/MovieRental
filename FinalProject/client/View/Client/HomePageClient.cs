using client.Controller;
using client.Controller.ClientActionsHandler;
using client.Controller.Validators;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using core.Models;

namespace client.View.Client
{
    public partial class HomePageClient : Form
    {
        ClientHandler clientHandler;
        MovieValidator movieValidator;
        public HomePageClient()
        {
            InitializeComponent();
            clientHandler = new ClientHandler();
            movieValidator = new MovieValidator();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (movieValidator.ValidateMovieTitleGenreOrActors(txtSearch.Text.Trim()))
            {
                clientHandler.SearchMovieByTitle(txtSearch.Text.Trim());
            }
            else
            {
                MessageBox.Show("Invalid movie");
            }
        }

        private void btnBorrow_Click_1(object sender, EventArgs e)
        {
            if (movieValidator.ValidateMovieTitleGenreOrActors(txtBorrow.Text.Trim()))
            {
                clientHandler.BorrowMovie(txtBorrow.Text.Trim(), LoginHandler.UserCnp);
            }
            else
            {
                MessageBox.Show("Invalid name");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (movieValidator.ValidateMovieTitleGenreOrActors(txtSearch.Text.Trim()))
            {
                clientHandler.SearchMovieByGenre(txtSearch.Text.Trim());
            }
            else
            {
                MessageBox.Show("Invalid movie");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (movieValidator.ValidateMovieTitleGenreOrActors(txtSearch.Text.Trim()))
            {
                clientHandler.SearchMovieByActors(txtSearch.Text.Trim());
            }
            else
            {
                MessageBox.Show("Invalid movie");
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            SelectPage selectPage = new SelectPage();
            selectPage.Show();
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            clientHandler.AddMovieToFavorite(textBox1.Text.Trim());
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            clientHandler.RemoveMovieFromFavorite(textBox1.Text.Trim());
        }

        private void HomePageClient_Load_1(object sender, EventArgs e)
        {
            label4.Text = clientHandler.GetAllMovies();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clientHandler.InsertReview(textBox2.Text.Trim(),textBox4.Text.Trim(),textBox3.Text.Trim());
        }
    }
}