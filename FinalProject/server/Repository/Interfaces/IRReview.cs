using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using core.Models;

namespace server.Repository.Interfaces
{
    public interface IRReview
    {
        IQueryable<Review> GetAll();

        DbSet<Review> GetDb();

        Review GetById(int id);

        void DeleteById(int id);

        List<Review> GetAllReports();

        Review Update(Review review);

        Review Insert(Review newReview);

        Review GetLastReport();
    }
}
