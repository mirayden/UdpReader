using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
			var serverIp = IPAddress.Parse("127.0.0.1"); 
			int serverPort = 5555;

			var endpoint = new IPEndPoint(serverIp, serverPort);
			using (var listener = new UdpClient(serverPort))
			{
				Console.WriteLine("Server started. Waiting for calls.");

				try
				{
					while (true)
					{
						byte[] requestBytes = listener.Receive(ref endpoint);

						string requestMessage = Encoding.ASCII.GetString(requestBytes, 0, requestBytes.Length);
						Console.WriteLine($"Incoming request from {endpoint}. Message: {requestMessage}");
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
		}
	}
}
