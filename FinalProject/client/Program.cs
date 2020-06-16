using client.View;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace client
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var host = Dns.GetHostEntry("localhost");
            var ipAddress = host.AddressList.First();
            var serverEndpoint = new IPEndPoint(ipAddress, 9000);

            Socket serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Connect(serverEndpoint);

            Request.ServerSocket = serverSocket;        

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());

        }
    }
}
