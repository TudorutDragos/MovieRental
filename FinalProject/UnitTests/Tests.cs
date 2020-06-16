using client.Controller.ClientActionsHandler;
using client.Controller.Validators;
using client.Controller.AdminActionsHandlers;
using core.Models;
using Moq;
using NUnit.Framework;
using server;
using server.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {

        private static DbSet<T> GetQueryableMockDbSet<T>(params T[] sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            return dbSet.Object;
        }

        [Test]
        public void TestSearchMovieByTitle()
        {
            var expectedMovie = new Movie()
            {
                ID = 1,
                title = "V for Vendeta",
                genre = "Action",
                actors = "Natalie Portman",
                clientCNP = "0000000000000",
                returnDate = null
            };

            var mockingClientHandler = new Mock<ClientHandler>();
            mockingClientHandler.Setup(x => x.SearchMovieByTitle("V for Vendeta")).Returns(expectedMovie);

            var _model = new Assignment_3Entities();
            _model.Movies = GetQueryableMockDbSet(
                new Movie()
                {
                    ID = 1,
                    title = "V for Vendeta",
                    genre = "Action",
                    actors = "Natalie Portman",
                    clientCNP = "0000000000000",
                    returnDate = null
                },

                new Movie()
                {
                    ID = 2,
                    title = "Django Unchained",
                    genre = "Action",
                    actors = "Jamie Fox",
                    clientCNP = "0000000000000",
                    returnDate = null
                },

                new Movie()
                {
                    ID = 3,
                    title = "AAA",
                    genre = "aa",
                    actors = "Mihai",
                    clientCNP = "0000000000000",
                    returnDate = null
                }
            );

            var repository = new TestRMovie(_model.Movies, _model);
            var handler = new Handler();
            handler.IrMovie = repository;

            var result = handler.GetMovieByName("V for Vendeta");
            Assert.AreNotEqual(mockingClientHandler.Object.SearchMovieByTitle("V for Vendeta"), result);
        }

        [Test]
        public void TestSearchMovieByGenre()
        {
            var expectedMovie = new Movie()
            {
                ID = 1,
                title = "V for Vendeta",
                genre = "Action",
                actors = "Natalie Portman",
                clientCNP = "0000000000000",
                returnDate = null
            };

            var mockingClientHandler = new Mock<ClientHandler>();
            mockingClientHandler.Setup(x => x.SearchMovieByGenre("Action")).Returns(expectedMovie);

            var _model = new Assignment_3Entities();
            _model.Movies = GetQueryableMockDbSet(
                new Movie()
                {
                    ID = 1,
                    title = "V for Vendeta",
                    genre = "Action",
                    actors = "Natalie Portman",
                    clientCNP = "0000000000000",
                    returnDate = null
                },

                new Movie()
                {
                    ID = 2,
                    title = "Django Unchained",
                    genre = "West",
                    actors = "Jamie Fox",
                    clientCNP = "0000000000000",
                    returnDate = null
                },

                new Movie()
                {
                    ID = 3,
                    title = "AAA",
                    genre = "aa",
                    actors = "Mihai",
                    clientCNP = "0000000000000",
                    returnDate = null
                }
            );

            var repository = new TestRMovie(_model.Movies, _model);
            var handler = new Handler();
            handler.IrMovie = repository;

            var result = handler.GetMovieByGenre("Action");
            Assert.AreNotEqual(mockingClientHandler.Object.SearchMovieByGenre("Action"), result);
        }

        [Test]
        public void TestSearchMovieByActors()
        {
            var expectedMovie = new Movie()
            {
                ID = 1,
                title = "V for Vendeta",
                genre = "Action",
                actors = "Natalie Portman",
                clientCNP = "0000000000000",
                returnDate = null
            };

            var mockingClientHandler = new Mock<ClientHandler>();
            mockingClientHandler.Setup(x => x.SearchMovieByActors("Natalie Portman")).Returns(expectedMovie);

            var _model = new Assignment_3Entities();
            _model.Movies = GetQueryableMockDbSet(
                new Movie()
                {
                    ID = 1,
                    title = "V for Vendeta",
                    genre = "Action",
                    actors = "Natalie Portman",
                    clientCNP = "0000000000000",
                    returnDate = null
                },

                new Movie()
                {
                    ID = 2,
                    title = "Django Unchained",
                    genre = "West",
                    actors = "Jamie Fox",
                    clientCNP = "0000000000000",
                    returnDate = null
                },

                new Movie()
                {
                    ID = 3,
                    title = "AAA",
                    genre = "aa",
                    actors = "Mihai",
                    clientCNP = "0000000000000",
                    returnDate = null
                }
            );

            var repository = new TestRMovie(_model.Movies, _model);
            var handler = new Handler();
            handler.IrMovie = repository;

            var result = handler.GetMovieByActors("Natalie Portman");
            Assert.AreNotEqual(mockingClientHandler.Object.SearchMovieByActors("Natalie Portman"), result);
        }

        [Test]
        public void TestGetAllMovies()
        {
            var expectedMovies = "Movie List:\nV for Vendeta\nDjango Unchained\nAAA\n";

            var mockingClientHandler = new Mock<ClientHandler>();
            mockingClientHandler.Setup(x => x.GetAllMovies()).Returns(expectedMovies);

            var _model = new Assignment_3Entities();
            _model.Movies = GetQueryableMockDbSet(
                new Movie()
                {
                    ID = 1,
                    title = "V for Vendeta",
                    genre = "Action",
                    actors = "Natalie Portman",
                    clientCNP = "0000000000000",
                    returnDate = null
                },

                new Movie()
                {
                    ID = 2,
                    title = "Django Unchained",
                    genre = "West",
                    actors = "Jamie Fox",
                    clientCNP = "0000000000000",
                    returnDate = null
                },

                new Movie()
                {
                    ID = 3,
                    title = "AAA",
                    genre = "aa",
                    actors = "Mihai",
                    clientCNP = "0000000000000",
                    returnDate = null
                }
            );

            var repository = new TestRMovie(_model.Movies, _model);
            var handler = new Handler();
            handler.IrMovie = repository;

            var result = handler.GetAllMovies();
            string text = "Movie List:\n";

            foreach (Movie m in result as List<Movie>)
            {
                text += m.title;
                text += "\n";
            }
            Assert.AreEqual(mockingClientHandler.Object.GetAllMovies(), text);
        }

        [Test]
        public void TestLastMovie()
        {
            var expectedMovie = new Movie()
            {
                ID = 3,
                title = "AAA",
                genre = "aa",
                actors = "Mihai",
                clientCNP = "0000000000000",
                returnDate = null
            };

            var mockingAdminMovieHandler = new Mock<AdminMovieHandler>();
            mockingAdminMovieHandler.Setup(x => x.ReadLastMovie()).Returns(expectedMovie);

            var _model = new Assignment_3Entities();
            _model.Movies = GetQueryableMockDbSet(
                new Movie()
                {
                    ID = 1,
                    title = "V for Vendeta",
                    genre = "Action",
                    actors = "Natalie Portman",
                    clientCNP = "0000000000000",
                    returnDate = null
                },

                new Movie()
                {
                    ID = 2,
                    title = "Django Unchained",
                    genre = "West",
                    actors = "Jamie Fox",
                    clientCNP = "0000000000000",
                    returnDate = null
                },

                new Movie()
                {
                    ID = 3,
                    title = "AAA",
                    genre = "aa",
                    actors = "Mihai",
                    clientCNP = "0000000000000",
                    returnDate = null
                }
            );

            var repository = new TestRMovie(_model.Movies, _model);
            var handler = new Handler();
            handler.IrMovie = repository;

            var result = handler.LastMovie();
            Assert.AreNotEqual(mockingAdminMovieHandler.Object.ReadLastMovie(), result);
        }

        [Test]
        public void TestSearchClientByCnpFail()
        {
            var expectedClient = new Client()
            {
                cnp = "2222222222222",
                firstName = "Name",
                lastName = "Here",
                address = "Nowhere",
                penaltyPoints = null
            };

            var mockingAdminClientHandler = new Mock<AdminClientHandler>();
            mockingAdminClientHandler.Setup(x => x.ReadClientByCnp("2222222222222")).Returns(expectedClient);

            var _model = new Assignment_3Entities();
            _model.Clients = GetQueryableMockDbSet(
                new Client()
                {
                    cnp = "1234567890123",
                    firstName = "Dragos",
                    lastName = "Tudorut",
                    address = "Sincai",
                    penaltyPoints = null
                },

                new Client()
                {
                    cnp = "2222222222222",
                    firstName = "Name",
                    lastName = "Here",
                    address = "Nowhere",
                    penaltyPoints = null
                },

                new Client()
                {
                    cnp = "3333333333333",
                    firstName = "First",
                    lastName = "Last",
                    address = "Add",
                    penaltyPoints = null
                }
            );

            var repository = new TestRClient(_model.Clients, _model);
            var handler = new Handler();
            handler.rClient = repository;

            var result = handler.ReadClientByCnp("0099990009909");
            Assert.AreNotEqual(mockingAdminClientHandler.Object.ReadClientByCnp("2222222222222"), result);
        }


        [Test]
        public void TestValidateMovieTitle()
        {
            var movieValidator = new MovieValidator();

            Assert.IsFalse(movieValidator.ValidateMovieTitleGenreOrActors("123124;';'"));
        }

        [Test]
        public void TestValidateMovieGenre()
        {
            var movieValidator = new MovieValidator();

            Assert.IsFalse(movieValidator.ValidateMovieTitleGenreOrActors("123124;';'"));
        }

        [Test]
        public void TestValidateMovieActors()
        {
            var movieValidator = new MovieValidator();

            Assert.IsFalse(movieValidator.ValidateMovieTitleGenreOrActors("123124;';'"));
        }

        [Test]
        public void TestValidateMovie()
        {
            var movieValidator = new MovieValidator();

            Assert.IsFalse(movieValidator.ValidateMovie("123124;';'","Action","Portman"));
        }

        [Test]
        public void TestValidateClientCnp()
        {
            var clientValidator = new ClientValidator();

            Assert.IsFalse(clientValidator.ValidateClientCnp("1234"));
        }

        [Test]
        public void TestValidateClient()
        {
            var clientValidator = new ClientValidator();

            Assert.IsFalse(clientValidator.ValidateClient("1234", "1111111", "213214", ",,.,.,"));
        }

        [Test]
        public void TestValidateClientTrue()
        {
            var clientValidator = new ClientValidator();

            Assert.IsTrue(clientValidator.ValidateClient("1234567890123", "FirstName", "LastName", "Address"));
        }
    }

    public class TestRMovie : IRMovie
    {

        private Assignment_3Entities _model { get; set; }
        public DbSet<Movie> _db { get; set; }

        public TestRMovie(DbSet<Movie> movies, Assignment_3Entities model)
        {
            this._model = model;
            this._db = movies;
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

    public class TestRClient : IRClient
    {
        private Assignment_3Entities _model { get; set; }
        public DbSet<Client> _db { get; set; }

        public TestRClient(DbSet<Client> clients, Assignment_3Entities model)
        {
            this._model = model;
            this._db = clients;
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
