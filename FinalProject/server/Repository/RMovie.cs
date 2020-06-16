using core.Models;
using server.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace server.Repository
{
    public class RMovie : IRMovie
    {

        private Assignment_3Entities _model { get; set; }
        public DbSet<Movie> _db { get; set; }

        public RMovie(Assignment_3Entities model)
        {
            this._model = model;
            this._db = _model.Set<Movie>();
        }

        public IQueryable<Movie> GetAll()
        {
            return _db;
        }

        public DbSet<Movie> GetDb()
        {
            return _db;
        }

        public Movie GetByName(string name)
        {
            foreach (Movie m in GetAll().ToList())
            {
                if (m.title == name)
                {
                    return m;
                }
            }
            return null;
        }

        public Movie GetByGenre(string genre)
        {
            foreach (Movie m in GetAll().ToList())
            {
                if (m.genre == genre)
                {
                    return m;
                }
            }
            return null;
        }

        public Movie GetByActors(string actors)
        {
            foreach (Movie m in GetAll().ToList())
            {
                if (m.actors == actors)
                {
                    return m;
                }
            }
            return null;
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = GetAll().ToList();
            return movies;
        }

        public List<Movie> GetByClientCnp(string clientCnp)
        {
            List<Movie> movies = new List<Movie>();
            foreach (Movie m in GetAll().ToList())
            {
                if (m.clientCNP == clientCnp)
                {
                    movies.Add(m);
                }
            }
            return movies;
        }

        public void DeleteByName(string name)
        {
            foreach (Movie m in GetAll().ToList())
            {
                if (m.title == name)
                {
                    _db.Remove(_db.Find(m.ID));
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

        public Movie Update(Movie movie)
        {
            _model.Entry(movie).State = EntityState.Modified;
            _model.SaveChanges();
            return movie;
        }

        public Movie Insert(Movie newMovie)
        {
            _db.Add(newMovie);
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
            return newMovie;
        }

        public Movie GetLastMovie()
        {
            Movie final = new Movie();
            final.ID = 0;
            foreach (Movie m in GetAll().ToList())
            {
                if (m.ID > final.ID)
                {
                    final = m;
                }
            }
            return final;
        }
    }
}
