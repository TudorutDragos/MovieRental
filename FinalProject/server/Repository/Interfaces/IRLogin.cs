using core.Models;
using System.Data.Entity;
using System.Linq;

namespace server.Repository.Interfaces
{
    public interface IRLogin
    {
        IQueryable<Login> GetAll();

        DbSet<Login> GetDb();

        Login GetByUsername(string username);

        void DeleteByClientCnp(string cnp);

        Login Update(Login login);

        Login Insert(Login newLogin);

        Login GetLastLogin();
    }
}
