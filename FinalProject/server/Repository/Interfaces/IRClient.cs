using core.Models;
using System.Data.Entity;
using System.Linq;

namespace server.Repository.Interfaces
{
    public interface IRClient
    {
        IQueryable<Client> GetAll();

        DbSet<Client> GetDb();

        Client GetByCnp(string cnp);

        void DeleteByCnp(string cnp);

        Client Update(Client client);

        Client Insert(Client newClient);
    }
}
