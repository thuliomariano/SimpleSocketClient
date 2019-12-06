using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace SimpleSocketClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string mensagem;
        public string historico;

        //cria uma stancia para iniciar uma conexão do socket
        Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //conecta ao ip no caso meu mesmo e uma porta
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7070);

        private void button1_Click(object sender, EventArgs e)
        {
         

            //conecta com o servidor
            sck.Connect(endPoint);

            txtHistorico.Text = "Mensagem: Cliente conectado com o Servidor!";
            


        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //envia informações para o servidor
            mensagem = txtMensagem.Text;

            //enviando minha menssagem
            byte[] msgBuffer = Encoding.Default.GetBytes(mensagem);
            sck.Send(msgBuffer, 0, msgBuffer.Length, 0);
            txtHistorico.Text = "Mensagem cliente: enviado mensagem com sucesso...";

            //recebendo minha menssagem
            byte[] buffer = new byte[255];
            int rec = sck.Receive(buffer, 0, buffer.Length, 0);

            Array.Resize(ref buffer, rec);

            txtHistorico.Text = Encoding.Default.GetString(buffer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sck.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
