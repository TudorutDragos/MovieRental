using core.Models;
using server.Repository.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace server.Repository
{
    public class RLogin : IRLogin
    {
        private Assignment_3Entities _model { get; set; }
        public DbSet<Login> _db { get; set; }
        public static string username { get; set; }
        public static string cnp { get; set; }

        public RLogin(Assignment_3Entities model)
        {
            this._model = model;
            this._db = _model.Set<Login>();
        }

        public IQueryable<Login> GetAll()
        {
            return _db;
        }

        public DbSet<Login> GetDb()
        {
            return _db;
        }

        public Login GetByUsername(string username)
        {
            foreach (Login l in GetAll().ToList())
            {
                if (l.username == username)
                {
                    return l;
                }
            }
            return null;
        }

        public void DeleteByClientCnp(string cnp)
        {
            foreach (Login l in GetAll().ToList())
            {
                if (l.clientCNP == cnp)
                {
                    _db.Remove(_db.Find(l.ID));
                    _model.SaveChanges();
                }
            }
        }

        public Login Update(Login login)
        {
            _model.Entry(login).State = EntityState.Modified;
            _model.SaveChanges();
            return login;
        }

        public Login Insert(Login newLogin)
        {
            _db.Add(newLogin);
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
            return newLogin;
        }


        public Login GetLastLogin()
        {
            Login final = new Login();
            final.ID = 0;
            foreach (Login l in GetAll().ToList())
            {
                if (l.ID > final.ID)
                {
                    final = l;
                }
            }
            return final;
        }
    }
}
