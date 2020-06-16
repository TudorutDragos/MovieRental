using core;
using System.IO;
using System.Net.Sockets;

namespace client
{
    public class Request
    {
        public static Socket ServerSocket { get; set; }

        public static object SendRequest(string content, object data)
        {
            var message = new Message
            {
                Content = content,
                Data = data
            };
            var stream = Serializer.ToStream(message);
            ServerSocket.Send(stream.GetBuffer());

            var buffer = new byte[16384];
            var bytesReceived = ServerSocket.Receive(buffer);
            if (bytesReceived != 0)
            {
                var receivedMessage = (Message)Serializer.FromStream(new MemoryStream(buffer));
                return receivedMessage.Data;
            }

            return null;
        }
    }
}
