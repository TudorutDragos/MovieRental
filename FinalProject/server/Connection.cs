using core;
using core.Models;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace server
{
    public class Connection
    {
        private Socket _socket;

        public Connection(Socket socket)
        {
            _socket = socket;

            Console.WriteLine($"Connected to client: {_socket.RemoteEndPoint}");
            Task.Factory.StartNew(() => Execute(_socket));
        }

        private void Execute(Socket socket)
        {
            while (true)
            {
                var buffer = new byte[16384];
                var bytesCount = socket.Receive(buffer);

                if (bytesCount != 0)
                {
                    var msgReceived = (Message)Serializer.FromStream(new MemoryStream(buffer));
                    Console.WriteLine($"Received msg: {msgReceived.Content}");
                    object obj = null;
                    Handler hdlr = new Handler();

                    if (msgReceived.Content.Equals("GetUser"))
                    {
                        obj = hdlr.GetUser((string)msgReceived.Data);
                    }
                    else
                    {
                        if (msgReceived.Content.Equals("InsertLogin"))
                        {
                            hdlr.InsertLogin((Login)msgReceived.Data);
                            obj = "true";
                        }
                        else
                        {
                            if (msgReceived.Content.Equals("DeleteLogin"))
                            {
                                hdlr.DeleteLogin((string)msgReceived.Data);
                                obj = "true";
                            }
                            else
                            {
                                if (msgReceived.Content.Equals("LastLogin"))
                                {
                                    obj = hdlr.LastLogin();
                                }
                            }
                        }
                    }

                    if (msgReceived.Content.Equals("InsertReview"))
                    {
                        obj=hdlr.InsertReview((Review) msgReceived.Data);
                    }
                    if (msgReceived.Content.Equals("AddFavoriteMovie"))
                    {
                        hdlr.AddFavorite((Favorite)msgReceived.Data);
                        obj = "true";
                    }
                    else
                    {
                        if (msgReceived.Content.Equals("LastFavorite"))
                        {
                            obj = hdlr.LastFavorite();
                        }
                        else
                        {
                            if (msgReceived.Content.Equals("RemoveFavorite"))
                            {
                                hdlr.RemoveFavorite(((Favorite)msgReceived.Data).movieName, ((Favorite)msgReceived.Data).cnpClient);
                                obj = "true";
                            }
                        }
                    }

                    if (msgReceived.Content.Equals("GetReviews"))
                    {
                        obj = hdlr.GetReviews();
                    }
                    if (msgReceived.Content.Equals("GetAllMovies"))
                    {
                        obj = hdlr.GetAllMovies();
                    }
                    if (msgReceived.Content.Equals("GetFavoriteByCnp"))
                    {
                        obj = hdlr.GetFavoriteMovies((string)msgReceived.Data);
                    }
                    if (msgReceived.Content.Equals("GetMoviesByCnp"))
                    {
                        obj = hdlr.GetMoviesByCnp((string)msgReceived.Data);
                    }
                    if (msgReceived.Content.Equals("CreateMovie"))
                    {
                        obj = hdlr.InsertMovie((Movie)msgReceived.Data);
                    }
                    else
                    {
                        if (msgReceived.Content.Equals("GetMovieByName"))
                        {
                            obj = hdlr.GetMovieByName((string)msgReceived.Data);
                        }
                        else
                        {
                            if (msgReceived.Content.Equals("GetMovieByGenre"))
                            {
                                obj = hdlr.GetMovieByGenre((string)msgReceived.Data);
                            }
                            else
                            {
                                if (msgReceived.Content.Equals("GetMovieByActors"))
                                {
                                    obj = hdlr.GetMovieByActors((string)msgReceived.Data);
                                }
                                else
                                {
                                    if (msgReceived.Content.Equals("UpdateMovie"))
                                    {
                                        obj = hdlr.UpdateMovie((Movie)msgReceived.Data);
                                    }
                                    else
                                    {
                                        if (msgReceived.Content.Equals("LastMovie"))
                                        {
                                            obj = hdlr.LastMovie();
                                        }
                                        else
                                        {
                                            if (msgReceived.Content.Equals("DeleteMovieByTitle"))
                                            {
                                                hdlr.DeleteMovie((string)msgReceived.Data);
                                                obj = "true";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (msgReceived.Content.Equals("LastReview"))
                    {
                        obj = hdlr.LastReview();
                    }
                    if (msgReceived.Content.Equals("InsertReport"))
                    {
                        obj = hdlr.InsertReport((Report)msgReceived.Data);
                    }
                    else
                    {
                        if (msgReceived.Content.Equals("LastReport"))
                        {
                            obj=hdlr.LastReport();
                        }
                        else
                        {
                            if (msgReceived.Content.Equals("GetReports"))
                            {
                                obj = hdlr.GetReports();
                            }
                        }
                    }
                    if (msgReceived.Content.Equals("InsertClient"))
                    {
                        obj = hdlr.InsertClient((Client)msgReceived.Data);
                    }
                    else
                    {
                        if (msgReceived.Content.Equals("ReadClientByCnp"))
                        {
                            obj = hdlr.ReadClientByCnp((string)msgReceived.Data);
                        }
                        else
                        {
                            if (msgReceived.Content.Equals("UpdateClient"))
                            {
                                obj = hdlr.UpdateClient((Client)msgReceived.Data);
                            }
                            else
                            {
                                if (msgReceived.Content.Equals("DeleteClient"))
                                {
                                    hdlr.DeleteClient((string)msgReceived.Data);
                                    obj = "true";
                                }
                            }
                        }
                    }
                    if (obj != null)
                    {
                        var message = new Message { Data = obj };
                        Console.WriteLine("Response sent");
                        var stream = Serializer.ToStream(message);
                        var byteSent = socket.Send(stream.GetBuffer());
                    }
                }

                Thread.Sleep(500);
            }
        }
    }
}
