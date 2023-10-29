using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SERVER
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CON_BD baza_date = new CON_BD();
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipAddress = IPAddress.Parse("10.10.24.1");
            int port = 12345;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            listener.Bind(localEndPoint);

            listener.Listen(10);

            Console.WriteLine("Server is listening for connections...");

            while (true)
            {
                Socket clientSocket = listener.Accept();

                byte[] buffer = new byte[1024];
                int bytesRead = clientSocket.Receive(buffer);
                string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received: " + receivedMessage);

                string responseMessage = "Server: Acknowledged - " + receivedMessage;

                byte[] responseBuffer = Encoding.ASCII.GetBytes(responseMessage);
                clientSocket.Send(responseBuffer);

                clientSocket.Close();
            }

            //baza_date.closeConnection();
        }
    }
}
