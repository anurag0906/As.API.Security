using System.Diagnostics;
using System.Net;

namespace As.API.RateLimit
{
	public class WhiteListIPMiddleware : IMiddleware
	{
		private readonly string _ipAllowed;
		public WhiteListIPMiddleware(string allowedIpList)
		{
			_ipAllowed = allowedIpList;
		}
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
		


			var remoteIP = context.Connection.RemoteIpAddress.ToString();
			if (remoteIP == null)
			{
				Debug.WriteLine("unsafe IP");
				context.Response.StatusCode = StatusCodes.Status403Forbidden;

				return;
			}

			if (remoteIP == "::1")
			{
				remoteIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[6].ToString();
			}

			var allowedIpList = _ipAllowed.Split(";");

			//if(remoteIP.IsIPv4MappedToIPv6)
			//{
			//	remoteIP = remoteIP.MapToIPv4(); //convert IPv6 to IPv4
			//}

			if(!allowedIpList.Contains(remoteIP))
			{
				Debug.WriteLine("unsafe IP");
				context.Response.StatusCode = StatusCodes.Status403Forbidden;

				return;
			}

			await next.Invoke(context);

		
		}
	}
}
