using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AS.API.RateLimit.Filter
{
	public class WhiteListIPActionFilter : ActionFilterAttribute
	{
		private readonly string _ipAllowed;

		public WhiteListIPActionFilter(string allowedIpList)
		{
			_ipAllowed = allowedIpList;
		}
		public override void OnActionExecuting(ActionExecutingContext context)
		{

			var remoteIP = context.HttpContext.Connection.RemoteIpAddress.ToString();
			if (remoteIP == null)
			{
				Debug.WriteLine("unsafe IP");
				context.Result = new ContentResult() { StatusCode = StatusCodes.Status401Unauthorized };

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

			if (!allowedIpList.Contains(remoteIP))
			{
				Debug.WriteLine("unsafe IP");
				context.Result = new ContentResult() { StatusCode = StatusCodes.Status401Unauthorized };

				return;
			}


			base.OnActionExecuting(context);
		}
	}
}
