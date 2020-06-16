using System;
using core.Models;
using System.Windows.Forms;

namespace client.Controller.AdminActionsHandlers
{
    public class AdminMovieHandler
    {
        //private Assignment_3Entities _model = new Assignment_3Entities();
        //private RMovie rMovie;


        public void CreateMovie(string title, string genre, string actors)
        {
            //  rMovie.Insert(newMovie);
            Movie temp = ReadLastMovie();
            Movie movie = new Movie();
            movie.ID = temp.ID + 1;
            movie.title = title;
            movie.genre = genre;
            movie.actors = actors;
            movie.clientCNP = "0000000000000";
            movie.returnDate = null;
            Request.SendRequest("CreateMovie", movie);
            string text = "Movie: " + movie.title + " add successfully";
            MessageBox.Show(text);
        }

        public Movie ReadMovieByTitle(string title)
        {
            //  return rMovie.GetByName(title);
            Movie movie = (Movie)Request.SendRequest("GetMovieByName", title);
            return movie;
        }

        public void UpdateMovie(string title, string genre, string actors,string rating)
        {
            //  rMovie.Update(movie);
            Movie movie = new Movie();
            movie.ID = ReadMovieByTitle(title).ID;
            movie.title = title;
            movie.genre = genre;
            movie.actors = actors;
            movie.rating = Int32.Parse(rating);
            //movie.clientCNP = "";
            Request.SendRequest("UpdateMovie", movie);
            string text = "Movie: " + movie.title + " updated successfully";
            MessageBox.Show(text);
        }

        public void DeleteMovieByTitle(string title)
        {
            //  rMovie.DeleteByName(title);
            Request.SendRequest("DeleteMovieByTitle", title);
        }

        public virtual Movie ReadLastMovie()
        {
            //  return rMovie.GetLastMovie();
            return (Movie)Request.SendRequest("LastMovie", null);
        }
    }
}
