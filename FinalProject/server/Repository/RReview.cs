using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using core.Models;
using server.Repository.Interfaces;

namespace server.Repository
{
    public class RReview : IRReview
    {

        private Assignment_3Entities _model { get; set; }
        public DbSet<Review> _db { get; set; }

        public RReview(Assignment_3Entities model)
        {
            this._model = model;
            this._db = _model.Set<Review>();
        }

        public IQueryable<Review> GetAll()
        {
            return _db;
        }

        public DbSet<Review> GetDb()
        {
            return _db;
        }

        public Review GetById(int id)
        {
            return _db.Find(id);
        }

        public void DeleteById(int id)
        {
            _db.Remove(_db.Find(id));
            _model.SaveChanges();
        }

        public List<Review> GetAllReports()
        {
            List<Review> reviews = GetAll().ToList();
            return reviews;
        }

        public Review Update(Review review)
        {
            _model.Entry(review).State = EntityState.Modified;
            _model.SaveChanges();
            return review;
        }

        public Review Insert(Review newReview)
        {
            _db.Add(newReview);
            _model.SaveChanges();
            return newReview;
        }

        public Review GetLastReport()
        {
            Review final = new Review();
            final.id = 0;
            foreach (Review r in GetAll().ToList())
            {
                if (r.id > final.id)
                {
                    final = r;
                }
            }
            return final;
        }
    }
}
