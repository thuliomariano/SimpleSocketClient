using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocketClient.Controller
{
    class Conexao
    {
        public String Name { get; set; }
        public String Ip { get; set; }
        public int Port { get; set; }

        public Conexao()
        {
        }
        public Conexao(string name)
        {
            Name = name;
        }

        public Conexao(string ip, int port) : this(ip)
        {
            Port = port;
        }

        public Conexao(string name, string ip, int port)
        {
            Name = name;
            Ip = ip;
            Port = port;
        }
    }
}
