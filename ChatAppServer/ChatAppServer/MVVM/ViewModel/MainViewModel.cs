using ChatClient.MVVM.Core;//RelayCommand
using ChatClient.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MVVM.ViewModel
{
    class MainViewModel
    {
        public RelayCommand ConnectToServerCommand { get; set; }

        public string Username { get; set; } /* bind it in MainViewModel.xaml */

        private Server _server; //server object that the application will connect to
        public MainViewModel()
        {
            _server = new Server();
            
            ConnectToServerCommand = new RelayCommand(o => _server.connectToServer(Username), o => !string.IsNullOrEmpty(Username));
        }
    }
}
