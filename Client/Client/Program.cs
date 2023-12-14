using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                IPEndPoint ipend = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

                socket.Connect(ipend);

                Console.WriteLine("Conexão feita com sucesso !");

                Console.Write("Digite sua mensagem: ");

                String info = Console.ReadLine();

                byte[] infoEnviar = Encoding.Default.GetBytes(info);

                socket.Send(infoEnviar, infoEnviar.Length, SocketFlags.None);

            } catch (Exception ex)
            {
                Console.WriteLine("The isn´t found !");
                Console.WriteLine("Erro: " + ex.Message);
            }
            socket.Close();
        }
    }
}