using core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace server.Repository.Interfaces
{
    public interface IRMovie
    {

        IQueryable<Movie> GetAll();

        DbSet<Movie> GetDb();

        Movie GetByName(string name);

        Movie GetByGenre(string genre);

        Movie GetByActors(string actors);

        List<Movie> GetAllMovies();

        List<Movie> GetByClientCnp(string clientCnp);

        void DeleteByName(string name);

        Movie Update(Movie movie);

        Movie Insert(Movie newMovie);

        Movie GetLastMovie();
    }
}
