using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WOLServer
{
	public class WOLService
	{

		public static void IndividualWake(string client)
		{
			IPAddress ip = ResolveName(client);
			if (ip != null)
			{
				if (PingHost(ip))
				{
					// client is awake
				}
				else
				{
					// client is not awake
					WakeClient();
				}
			}
			else throw new ApplicationException("CRITICAL: Host could not be resolved.");
		}
		private static IPAddress ResolveName(string client)
		{
			foreach (var item in Dns.GetHostAddresses(client))
			{
				return item.MapToIPv4();
			}
			return null; // change to true if found, false if not found
		}

		private static bool PingHost(IPAddress ipAddress)
		{
			try
			{
				PingReply reply = (new Ping()).Send(ipAddress);
				return reply.Status == IPStatus.Success;
			}
			catch (PingException)
			{
				// Discard PingExceptions and return false;
				throw new ApplicationException("CRITICAL: Host could not be resolved.");
			}
		}

		private static void WakeClient()
		{
			// send magic packet to client
		}

		public static void ClientSetup()
		{
			throw new NotImplementedException();
		}


		public static void Settings()
		{
			throw new NotImplementedException();
		}
	}
	
}
