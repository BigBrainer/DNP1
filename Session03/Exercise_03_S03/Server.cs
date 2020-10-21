﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace Exercise_03_S03
{
    class Server
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server...");

            IPAddress ip = IPAddress.Parse("127.0.0.222");
            TcpListener listener = new TcpListener(ip, 5000);
            listener.Start();

            Console.WriteLine("Server started...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                Console.WriteLine("Client connected");
                NetworkStream stream = client.GetStream();
                while (true)
                {
                    //read
                    byte[] dataFromClient = new byte[1024];
                    int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);

                    string s = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
                    Console.WriteLine(s);

                    //write
                    byte[] dataToClient = Encoding.ASCII.GetBytes($"Returning {s}");
                    stream.Write(dataToClient, 0, dataToClient.Length);

                    if (s.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        stream.Close();
                        client.Close();
                        break;
                    }
                }
            }
        }
    }
}
