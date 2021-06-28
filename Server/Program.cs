using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        static readonly object _lock = new object();
        static readonly Dictionary<int, TcpClient> list_clients = new Dictionary<int, TcpClient>();

        static void Main(string[] args)
        {
            int count = 1;

            TcpListener ServerSocket = new TcpListener(IPAddress.Parse("192.168.188.25"), 5000);
            ServerSocket.Start();

            while (true)
            {
                TcpClient client = ServerSocket.AcceptTcpClient();
                lock (_lock) list_clients.Add(count, client);
                Console.WriteLine("Someone connected!!");

                Thread t = new Thread(handle_clients);
                t.Start(count);
                count++;
            }
        }

        public static void handle_clients(object o)
        {
            try
            {
                int id = (int)o;
                TcpClient client;

                lock (_lock) client = list_clients[id];

                while (true)
                {
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int byte_count = stream.Read(buffer, 0, buffer.Length);

                    if (byte_count == 0)
                    {
                        break;
                    }

                    string data = Encoding.UTF8.GetString(buffer, 0, byte_count);
                    broadcast(data);
                    Console.WriteLine(data);
                }

                lock (_lock) list_clients.Remove(id);
                client.Client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch(Exception e)
            {
                //GetLocalIPAddress()
                Console.WriteLine("Someone disconnected!");
            }
            
        }

        public static void broadcast(string data)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data + Environment.NewLine);

            lock (_lock)
            {
                foreach (TcpClient c in list_clients.Values)
                {
                    NetworkStream stream = c.GetStream();

                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }

        #region HELPER
        /*public static string GetLocalIPAddress()

        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (ip.ToString().StartsWith("192.168.")) //192.168.60
                        return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }*/
        #endregion
    }
}
