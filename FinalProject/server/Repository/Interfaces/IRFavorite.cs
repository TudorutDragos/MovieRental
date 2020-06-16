using core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace server.Repository.Interfaces
{
    public interface IRFavorite
    {
        IQueryable<Favorite> GetAll();

        DbSet<Favorite> GetDb();

        List<Favorite> GetByClientCnp(string clientCnp);

        void DeleteByNameAndCnp(string name, string cnp);

        Favorite Update(Favorite favorite);

        Favorite Insert(Favorite newFavorite);

        Favorite GetLastFavorite();
    }
}
