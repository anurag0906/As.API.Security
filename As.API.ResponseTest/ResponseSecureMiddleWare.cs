namespace As.API.ResponseTest
{
	public class ResponseSecureMiddleWare : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			context.Response.Headers.Add("X-Frame-Options", "DENY"); //avoid Click jacking attack
			context.Response.Headers.Add("X-Content-Type-Options", "nosniff"); // avoid MIME-type sniffing attack
			context.Response.Headers.Add("X-Xss-Protection", "1; mode=block"); //Cross site scripting attack
			context.Response.Headers.Add("Referrer-Policy", "no-referrer"); //Unwanted side opening
			context.Response.Headers.Add("Content-Security-Policy", "default-src 'self';"); //Code Injection

			await next(context);
		}
	}
}
