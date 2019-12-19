using SimpleSocketClient.Controller;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

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
        Conexao conexao = new Conexao();

        //cria uma stancia para iniciar uma conexão do socket
        Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);



        private void button1_Click(object sender, EventArgs e)
        {
            //conecta com o servidor
            try
            {
                Conexao con = new Conexao();
                con.Name = txtNome.Text;
                con.Ip = txtIp.Text;
                con.Port = Convert.ToInt32(txtPort.Text);


                //conecta ao ip no caso meu mesmo e uma porta
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(con.Ip), con.Port);
                sck.Connect(endPoint);
                txtHistorico.Text = "Mensagem: Cliente conectado com o Servidor!";
                String usuario = "Usuário: " + conexao.Name + " conectado";
                txtHistorico.Text = "Mensagem: Cliente conectado com o Servidor! \n" + usuario;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro de comunicação com o servidor, por favor verifique se o mesmo está acessivel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtIp.Enabled = false;
            txtPort.Enabled = false;
            btnConectar.Enabled = false;
            btnEncerrar.Enabled = true;
            txtMensagem.Enabled = true;
            btnEnviar.Enabled = true;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("Erro inesperado: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sck.Close();
            txtIp.Enabled = true;
            txtPort.Enabled = true;
            btnConectar.Enabled = true;
            btnEncerrar.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtIp.Enabled = false;
            txtPort.Enabled = false;
            btnConectar.Enabled = false;
            btnEncerrar.Enabled = false;
            btnEnviar.Enabled = false;
            txtMensagem.Enabled = false;
        }

        private void txtHistorico_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            txtIp.Enabled = true;
            txtPort.Enabled = true;
            btnConectar.Enabled = true;
            conexao.Name = txtNome.Text;
        }
    }
}
