using core.Models;
using server.Repository.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace server.Repository
{
    public class RClient : IRClient
    {
        private Assignment_3Entities _model { get; set; }
        public DbSet<Client> _db { get; set; }

        public RClient(Assignment_3Entities model)
        {
            this._model = model;
            this._db = _model.Set<Client>();
        }

        public IQueryable<Client> GetAll()
        {
            return _db;
        }

        public DbSet<Client> GetDb()
        {
            return _db;
        }

        public Client GetByCnp(string cnp)
        {
            return _db.Find(cnp);
        }

        public void DeleteByCnp(string cnp)
        {
            _db.Remove(_db.Find(cnp));
            _model.SaveChanges();
        }

        public Client Update(Client client)
        {
            _model.Entry(client).State = EntityState.Modified;
            _model.SaveChanges();
            return client;
        }

        public Client Insert(Client newClient)
        {
            _db.Add(newClient);
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
            return newClient;
        }
    }
}
