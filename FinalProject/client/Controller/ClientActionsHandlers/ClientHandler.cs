using core.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace client.Controller.ClientActionsHandler
{
    public class ClientHandler
    {
        public ReportHandler ReportHdlr;
        public ClientHandler()
        {
            ReportHdlr = new ReportHandler();
        }

        public virtual Movie SearchMovieByTitle(string title)
        {
            Movie movie;
            movie = (Movie)Request.SendRequest("GetMovieByName",title);
            string text = "Movie: " + movie.title + "\nGenre: " + movie.genre + "\nActors: " + movie.actors + "\nrating: " + movie.rating + "\nreviews:\n";
            List<Review> reviews = (List<Review>)Request.SendRequest("GetReviews", null);
            foreach (Review r in reviews)
            {
                if (r.movieID == movie.ID)
                {
                    text += r.review1 + "\n";
                }
            }
            MessageBox.Show(text);
            return movie;
        }

        public virtual Movie SearchMovieByGenre(string genre)
        {
            Movie movie;
            movie = (Movie)Request.SendRequest("GetMovieByGenre",genre);
            string text = "Movie: " + movie.title + "\nGenre: " + movie.genre + "\nActors: " + movie.actors +"\nrating: "+movie.rating+"\nreviews:\n";
            List<Review> reviews = (List<Review>) Request.SendRequest("GetReviews",null);
            foreach(Review r in reviews)
            {
                if (r.movieID == movie.ID)
                {
                    text += r.review1 + "\n";
                }
            }
            MessageBox.Show(text);
            return movie;
        }

        public virtual Movie SearchMovieByActors(string actors)
        {
            Movie movie;
            movie = (Movie)Request.SendRequest("GetMovieByActors",actors);
            string text = "Movie: " + movie.title + "\nGenre: " + movie.genre + "\nActors: " + movie.actors + "\nrating: " + movie.rating + "\nreviews:\n";
            List<Review> reviews = (List<Review>)Request.SendRequest("GetReviews", null);
            foreach (Review r in reviews)
            {
                if (r.movieID == movie.ID)
                {
                    text += r.review1 + "\n";
                }
            }
            MessageBox.Show(text);
            return movie;
        }

        public void BorrowMovie(string title, string clientCnp)
        {
            Movie movie = (Movie)Request.SendRequest("GetMovieByName",title);
            if (movie.clientCNP == "0000000000000")
            {
                Client client = (Client) Request.SendRequest(("ReadClientByCnp"), clientCnp);
                if ((client.ableToBorrow == null || client.ableToBorrow == DateTime.Now) && (client.nrOfMovies==null || client.nrOfMovies>0))
                {
                    movie.clientCNP = clientCnp;
                    movie.returnDate = DateTime.Now.AddDays(+7);
                    //     rMovie.Update(movie);
                    Request.SendRequest("UpdateMovie", movie);
                    Report rep = new Report();
                    rep.ID = ReportHdlr.GetLastReport().ID + 1;
                    rep.client = LoginHandler.User;
                    rep.borrowedNow = 1;
                    rep.movie = title;
                    rep.movieID = movie.ID;
                    rep.clientCnp = clientCnp;
                    ReportHdlr.CreateReport(rep);
                    client.ableToBorrow = null;
                    if (client.nrOfMovies != null)
                    {
                        client.nrOfMovies--;
                    }
                    Request.SendRequest("UpdateClient", client);
                    string text = "Movie: " + title + " is borrowed for 7 days";
                    MessageBox.Show(text);
                }
                else
                {
                    MessageBox.Show("This client can't borrow movies anymore!");
                }
            }
            else
            {
                MessageBox.Show("Movie: " + title + " is already borrowed");
            }
        }

        public void ReturnMovie(string title, string clientCnp)
        {
            Movie movie = (Movie)Request.SendRequest("GetMovieByName", title);
            if (movie.clientCNP == LoginHandler.UserCnp)
            {
                Client client = (Client)Request.SendRequest("ReadClientByCnp", clientCnp);
                if (DateTime.Compare((DateTime)movie.returnDate , DateTime.Now)<0)
                {
                    MessageBox.Show("Movie " + movie.title + " is returned with penalty");
                    if (client.penaltyPoints == null)
                    {
                        client.penaltyPoints = 1;
                    }
                    else
                        client.penaltyPoints++;
                    if (client.penaltyPoints == 5)
                    {
                        client.ableToBorrow = DateTime.Now.AddMonths(1);
                    }
                }

                client.nrOfMovies++;
                Request.SendRequest("UpdateClient", client);
                MessageBox.Show("Movie: " + title + " is returned without penalty");
                movie.clientCNP = "0000000000000";
                movie.returnDate = null;
                Request.SendRequest("UpdateMovie", movie);
                Report rep = new Report();
                rep.ID = ReportHdlr.GetLastReport().ID + 1;
                rep.client = LoginHandler.User;
                rep.borrowedNow = 0;
                rep.movie = title;
                rep.movieID = movie.ID;
                rep.clientCnp = LoginHandler.UserCnp;
                ReportHdlr.CreateReport(rep);
            }
            else
            {
                MessageBox.Show("This movie is not in your borrowed list");
            }
        }

        public void InsertReview(string movieName, string rating, string description)
        {
            Movie movie = (Movie) Request.SendRequest("GetMovieByName", movieName);

            if (movie.nrOfRatings == null)
            {
                movie.nrOfRatings = 1;
            }
            else
            {
                movie.nrOfRatings++;
            }

            if (movie.rating == null)
            {
                movie.rating = Int32.Parse(rating);
            }
            movie.rating = (movie.rating + Int32.Parse(rating)) / 2;

            Request.SendRequest("UpdateMovie", movie);

            Review rev = new Review();
            rev.id = ReportHdlr.GetLastReview().id + 1;
            rev.movieID = movie.ID;
            rev.review1 = description;

            Request.SendRequest("InsertReview", rev);
        }

        public virtual string GetAllMovies()
        {
            string text = "Movie List:\n";

            //List<Movie> movies = rMovie.GetByClientCnp(RLogin.cnp);
            List<Movie> movies = (List<Movie>)Request.SendRequest("GetAllMovies", null);
            foreach (Movie m in movies)
            {
                text += m.title;
                text += "\n";
            }

            return text;
        }

        public void AddMovieToFavorite(string title)
        {
            string cnp = LoginHandler.UserCnp;
            Favorite newFavorite = new Favorite();
            newFavorite.id = ((Favorite)Request.SendRequest("LastFavorite", null)).id+1;
            newFavorite.cnpClient = cnp;
            newFavorite.movieName = title;
            Request.SendRequest("AddFavoriteMovie", newFavorite);
            MessageBox.Show("Movie added to favorites");
        }

        public void RemoveMovieFromFavorite(string title)
        {
            Favorite newFavorite = new Favorite();
            newFavorite.id = 0;
            newFavorite.cnpClient = LoginHandler.UserCnp;
            newFavorite.movieName = title;
            Request.SendRequest("RemoveFavorite", newFavorite);
            MessageBox.Show("Movie removed from favorites");
        }
    }
}
