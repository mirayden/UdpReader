using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please input the messages you want to send to the server and press enter. Or press Ctrl + C to stop.");

			while (true)
			{
				SendMessage(Console.ReadLine());
				Console.WriteLine("Message was sent.");
			}
		}

		static void SendMessage(string messageString)
		{
			var serverIp = IPAddress.Parse("127.0.0.1");
			int serverPort = 5555;
			var endpoint = new IPEndPoint(serverIp, serverPort);

			byte[] message = Encoding.ASCII.GetBytes(messageString);
			using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
			{
				socket.SendTo(message, message.Length, SocketFlags.None, endpoint);
			}
		}
	}
}
