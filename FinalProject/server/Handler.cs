using core.Models;
using server.Repository;
using server.Repository.Interfaces;

namespace server
{
    public class Handler
    {
        private Assignment_3Entities _model = new Assignment_3Entities();
        public IRClient rClient;
        public IRLogin rLogin;
        public IRMovie IrMovie;
        public IRReport rReport;
        public IRFavorite rFavorite;
        public IRReview rReview;

        public Handler()
        {
            rClient = new RClient(_model);
            rLogin = new RLogin(_model);
            IrMovie = new RMovie(_model);
            rReport = new RReport(_model);
            rFavorite = new RFavorite(_model);
            rReview = new RReview(_model);
        }

        public object GetUser(string username)
        {
            return rLogin.GetByUsername(username);
        }

        public bool InsertLogin(Login login)
        {
            Login l = rLogin.Insert(login);
            if (l != null)
            {
                return true;
            }
            return false;
        }

        public object GetReports()
        {
            return rReport.GetAllReports();
        }

        public object GetReviews()
        {
            return rReview.GetAllReports();
        }

        public void DeleteLogin(string cnp)
        {
            rLogin.DeleteByClientCnp(cnp);
        }

        public object LastLogin()
        {
            return rLogin.GetLastLogin();
        }

        public object InsertMovie(Movie movie)
        {
            Movie m = IrMovie.Insert(movie);
            if (m != null)
            {
                return true;
            }
            return false;
        }

        public object GetMovieByName(string title)
        {
            return IrMovie.GetByName(title);
        }

        public object GetMovieByGenre(string genre)
        {
            return IrMovie.GetByGenre(genre);
        }

        public object GetMovieByActors(string actors)
        {
            return IrMovie.GetByActors(actors);
        }

        public object GetMoviesByCnp(string cnp)
        {
            return IrMovie.GetByClientCnp(cnp);
        }

        public object UpdateMovie(Movie movie)
        {
            return IrMovie.Update(movie);
        }

        public object GetAllMovies()
        {
            return IrMovie.GetAllMovies();
        }

        public object LastMovie()
        {
            return IrMovie.GetLastMovie();
        }
        
        public object GetFavoriteMovies(string cnp)
        {
            return rFavorite.GetByClientCnp(cnp);
        }
        public bool AddFavorite(Favorite favorite)
        {
            Favorite f = rFavorite.Insert(favorite);
            if (f != null)
            {
                return true;
            }
            return false;
        }

        public void RemoveFavorite(string title, string cnp)
        {
            rFavorite.DeleteByNameAndCnp(title, cnp);
        }

        public object LastFavorite()
        {
            return rFavorite.GetLastFavorite();
        }

        public void DeleteMovie(string title)
        {
            IrMovie.DeleteByName(title);
        }

        public object InsertReport(Report report)
        {
            return rReport.Insert(report);
        }

        public object InsertReview(Review review)
        {
            return rReview.Insert(review);
        }

        public object LastReview()
        {
            return rReview.GetLastReport();
        }

        public object LastReport()
        {
            return rReport.GetLastReport();
        }

        public object InsertClient(Client client)
        {
            return rClient.Insert(client);
        }

        public object ReadClientByCnp(string cnp)
        {
            return rClient.GetByCnp(cnp);
        }

        public object UpdateClient(Client client)
        {
            return rClient.Update(client);
        }

        public void DeleteClient(string cnp)
        {
            rClient.DeleteByCnp(cnp);
        }
    }
}
