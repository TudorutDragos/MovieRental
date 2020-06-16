using core.Models;
using server.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace server.Repository
{
    public class RFavorite : IRFavorite
    {
        private Assignment_3Entities _model { get; set; }
        public DbSet<Favorite> _db { get; set; }

        public RFavorite(Assignment_3Entities model)
        {
            this._model = model;
            this._db = _model.Set<Favorite>();
        }

        public IQueryable<Favorite> GetAll()
        {
            return _db;
        }

        public DbSet<Favorite> GetDb()
        {
            return _db;
        }

        public List<Favorite> GetByClientCnp(string clientCnp)
        {
            List<Favorite> favorites = new List<Favorite>();
            foreach (Favorite f in GetAll().ToList())
            {
                if (f.cnpClient == clientCnp)
                {
                    favorites.Add(f);
                }
            }
            return favorites;
        }

        public void DeleteByNameAndCnp(string name, string cnp)
        {
            foreach (Favorite f in GetAll().ToList())
            {
                if (f.movieName == name && f.cnpClient == cnp)
                {
                    _db.Remove(_db.Find(f.id));
                    try
                    {
                        // Your code...
                        // Could also be before try if you know the exception occurs in SaveChanges

                        _model.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                }
            }
        }

        public Favorite Update(Favorite favorite)
        {
            _model.Entry(favorite).State = EntityState.Modified;
            _model.SaveChanges();
            return favorite;
        }

        public Favorite Insert(Favorite newFavorite)
        {
            _db.Add(newFavorite);
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                _model.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            return newFavorite;
        }

        public Favorite GetLastFavorite()
        {
            Favorite final = new Favorite();
            final.id = 0;
            foreach (Favorite f in GetAll().ToList())
            {
                if (f.id > final.id)
                {
                    final = f;
                }
            }
            return final;
        }
    }
}
