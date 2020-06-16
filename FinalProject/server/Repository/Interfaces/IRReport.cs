using core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace server.Repository.Interfaces
{
    public interface IRReport
    {
        IQueryable<Report> GetAll();

        DbSet<Report> GetDb();

        Report GetById(int id);

        void DeleteById(int id);

        List<Report> GetAllReports();

        Report Update(Report report);

        Report Insert(Report newReport);

        Report GetLastReport();
    }
}
