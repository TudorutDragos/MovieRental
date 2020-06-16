using client.Controller.AdminActionsHandlers;
using client.Controller.Validators;
using System;
using System.Windows.Forms;

namespace client.View.Admin
{
    public partial class MoviePage : Form
    {
        AdminMovieHandler adminMovieHandler;
        MovieValidator movieValidator;
        public MoviePage()
        {
            adminMovieHandler = new AdminMovieHandler();
            movieValidator = new MovieValidator();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (movieValidator.ValidateMovie(txtTitle.Text.Trim(), txtGenre.Text.Trim(), txtActors.Text.Trim()))
            { 
                adminMovieHandler.CreateMovie(txtTitle.Text.Trim(), txtGenre.Text.Trim(), txtActors.Text.Trim());
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
            if (movieValidator.ValidateMovieTitleGenreOrActors(txtTitle.Text.Trim()))
            {
                var movie = adminMovieHandler.ReadMovieByTitle(txtTitle.Text.Trim());
                MessageBox.Show("Movie:\nTitle: " + movie.title + "\nGenre: " + movie.genre + "\nActors: " + movie.actors + "\nBorrowed: " + movie.clientCNP);
            }
            else
            {
                MessageBox.Show("Invalid data");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (movieValidator.ValidateMovie(txtTitle.Text.Trim(), txtGenre.Text.Trim(), txtActors.Text.Trim()))
            {
                adminMovieHandler.UpdateMovie(txtTitle.Text.Trim(), txtGenre.Text.Trim(), txtActors.Text.Trim(),textBox1.Text.Trim());
            }
            else
            {
                MessageBox.Show("Invalid data");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (movieValidator.ValidateMovieTitleGenreOrActors(txtTitle.Text.Trim()))
            {
                adminMovieHandler.DeleteMovieByTitle(txtTitle.Text.Trim());
                MessageBox.Show("Movie deleted");
            }
            else
            {
                MessageBox.Show("Invalid data");
            }
        }
    }
}
