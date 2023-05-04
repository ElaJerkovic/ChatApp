using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net
{
    class Server
    {
        TcpClient _client;
        public Server() 
        {
            _client = new TcpClient(); //new instance of TcpClient
        }

        //function to connect to the server
        //public because it will be exposed to the ViewModel

        public void connectToServer(string username) /* calling this from the MainViewModel */
        {
            if (!_client.Connected)
                _client.Connect("127.0.0.1", 7891); //(hostname, port) connects the client to the specified port on the specified host
                //127.0.0.1- the IP address of the local computer
        }
    }
}
