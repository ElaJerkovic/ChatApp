using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    class Program
    {
        static List<Client> _users;
        static TcpListener _listener;
        static void Main(string[] args)
        {
            _users = new List<Client>();
            /* creating a TCP listener that will listen for incoming client connections
             on the specified IP address and port number */
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7891);

            //calling the method to start the listener and begin accepting incoming client connections
            _listener.Start();

            /* method to accept a single client connection
            blocks the current thread until a client connection is established
            var client = _listener.AcceptTcpClient();
            Console.WriteLine("Client has connected!"); */

            while(true)
            {
                /* _listener.AcceptTcpClient() is a blocking method call that waits for
                a client to connect to the server and returns a TcpClient object that
                represents the client's connection */
                var client = new Client(_listener.AcceptTcpClient());
                _users.Add(client);

                /* Broadcast the connection to everyone on the server */
            }
            
        }
    }
}
