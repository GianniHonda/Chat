using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

            socket.Bind(iPEnd);

            socket.Listen(5);

            Console.Write("Escutando...");

            Socket escutar = socket.Accept();

            byte[] bytes = new byte[255];

            int tamanho = escutar.Receive(bytes,0,bytes.Length, SocketFlags.None);

            Array.Resize(ref bytes, tamanho);

            Console.Write("Cliente falou: " + Encoding.Default.GetString(bytes));

            escutar.Close();

            Console.WriteLine("Servidor fechado");
        }
    }
}