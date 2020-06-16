using core.Models;
using server.Repository.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace server.Repository
{
    public class RReport : IRReport
    {

        private Assignment_3Entities _model { get; set; }
        public DbSet<Report> _db { get; set; }

        public RReport(Assignment_3Entities model)
        {
            this._model = model;
            this._db = _model.Set<Report>();
        }

        public IQueryable<Report> GetAll()
        {
            return _db;
        }

        public DbSet<Report> GetDb()
        {
            return _db;
        }

        public Report GetById(int id)
        {
            return _db.Find(id);
        }

        public void DeleteById(int id)
        {
            _db.Remove(_db.Find(id));
            _model.SaveChanges();
        }

        public List<Report> GetAllReports()
        {
            List<Report> reports = GetAll().ToList();
            return reports;
        }

        public Report Update(Report report)
        {
            _model.Entry(report).State = EntityState.Modified;
            _model.SaveChanges();
            return report;
        }

        public Report Insert(Report newReport)
        {
            _db.Add(newReport);
            _model.SaveChanges();
            return newReport;
        }

        public Report GetLastReport()
        {
            Report final = new Report();
            final.ID = 0;
            foreach (Report r in GetAll().ToList())
            {
                if (r.ID > final.ID)
                {
                    final = r;
                }
            }
            return final;
        }
    }
}
