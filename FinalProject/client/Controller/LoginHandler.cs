using core.Models;
using System.Collections.Generic;

namespace client.Controller
{
    public class LoginHandler
    {
        //private Assignment_2Entities _model = new Assignment_2Entities();
        //private RLogin rLogin;
       // private RMovie rMovie;
        public static string User { get; set; }
        public static string UserCnp { get; set; }

        public void CreateLogin(Login newLogin)
        {
            // rLogin.Insert(newLogin);
            Request.SendRequest("InsertLogin", newLogin);
        }

        public void DeleteLogin(string cnp)
        {
            // rLogin.DeleteByClientCnp(cnp);
            Request.SendRequest("DeleteLogin", cnp);
        }

        public Login ReadLastLogin()
        {
            // return rLogin.GetLastLogin();
            return (Login)Request.SendRequest("LastLogin", null);
        }

        public bool GetDataFromDb(string username, string password)
        {
            Login log = (Login)Request.SendRequest("GetUser", username);
            if (log.username == username)
            {
                if (log.password == password)
                {
                    User = username;
                    UserCnp = log.clientCNP;
                    return true;
                }
            }
            return false;
        }

        public string GetCurrentUser()
        {
            return User;
        }
        public string GetCurrentCnp()
        {
            return UserCnp;
        }

        public string GetMovies()
        {
            string text = "Movie List:\n";

            //List<Movie> movies = rMovie.GetByClientCnp(RLogin.cnp);
            List<Movie> movies = (List<Movie>)Request.SendRequest("GetMoviesByCnp", UserCnp);
            foreach (Movie m in movies)
            {
                text += m.title;
                text += "\n";
            }

            return text;
        }

        public string GetFavoriteMovies()
        {
            string text = "Favorite Movies:\n";

            //List<Movie> movies = rMovie.GetByClientCnp(RLogin.cnp);
            List<Favorite> favorites = (List<Favorite>)Request.SendRequest("GetFavoriteByCnp", UserCnp);
            foreach (Favorite f in favorites)
            {
                text += f.movieName;
                text += "\n";
            }

            return text;
        }
    }
}
