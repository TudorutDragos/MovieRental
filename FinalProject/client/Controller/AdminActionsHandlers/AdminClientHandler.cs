using core.Models;
using System;
using System.Windows.Forms;

namespace client.Controller.AdminActionsHandlers
{
    public class AdminClientHandler
    {
        //private Assignment_3Entities _model = new Assignment_3Entities();
        //private RClient rClient;
        public LoginHandler LoginHdl;
        public AdminClientHandler()
        {
            //  rClient = new RClient(_model);
            LoginHdl = new LoginHandler();
        }

        public void CreateClient(string cnp, string firstName, string lastName, string address)
        {
            //   rClient.Insert(newClient);
            Client client = new Client();
            client.cnp = cnp;
            client.firstName = firstName;
            client.lastName = lastName;
            client.address = address;
            Login log = new Login();
            log.ID = LoginHdl.ReadLastLogin().ID + 1;
            log.username = firstName + lastName;
            log.password = "parola";
            log.clientCNP = cnp;
            LoginHdl.CreateLogin(log);
            string text = "Client: " + client.firstName + " " + client.lastName + " add successfully";
            MessageBox.Show(text);
            Request.SendRequest("InsertClient", client);
        }

        public virtual Client ReadClientByCnp(string cnp)
        {
            //  return rClient.GetByCnp(cnp);
            return (Client)Request.SendRequest("ReadClientByCnp", cnp);
        }

        public void UpdateClient(string cnp, string firstName, string lastName, string address,string nrOfMovies)
        {
            //  rClient.Update(client);
            Client client = new Client();
            client.cnp = cnp;
            client.firstName = firstName;
            client.lastName = lastName;
            client.address = address;
            client.nrOfMovies=Int32.Parse(nrOfMovies);
            Request.SendRequest("UpdateClient", client);
            string text = "Client: " + client.firstName + " " + client.lastName + " updated successfully";
            MessageBox.Show(text);
        }

        public void DeleteClientByCnp(string cnp)
        {
            //  rClient.DeleteByCnp(cnp);
            Request.SendRequest("DeleteClient", cnp);
        }
    }
}
