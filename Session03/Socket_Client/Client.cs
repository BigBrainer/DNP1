using System;
using System.Net.Sockets;
using System.Text;

namespace Socket_Client
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting client");

            TcpClient client = new TcpClient("127.0.0.222", 5000);

            NetworkStream stream = client.GetStream();

            while (true)
            {
                string message = Console.ReadLine();
                byte[] dataToServer = Encoding.ASCII.GetBytes(message);
                stream.Write(dataToServer, 0, dataToServer.Length);

                byte[] dataFromServer = new byte[1024];
                int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
                string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
                Console.WriteLine(response);
                if (message.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    stream.Write(Encoding.ASCII.GetBytes(message));
                    break;
                }

            }
        }
    }
}
