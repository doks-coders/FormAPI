using FormAPI.Models.SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos.Core;
using System.Text;
using System.Text.Json;

namespace FormAPI.Middlewares
{
	public class ErrorMiddleware
	{
		private readonly RequestDelegate _delegate;

		public ErrorMiddleware(RequestDelegate @delegate)
		{
			_delegate = @delegate;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _delegate(context);

			}catch(Exception ex)
			{
				var error = new ErrorModel(StatusCodes.Status500InternalServerError.ToString(), ex.Message, JsonSerializer.Serialize(ex.StackTrace));
			
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = int.Parse(error.StatusCode);


				var json = JsonSerializer.Serialize(error);

				await context.Response.WriteAsync(json);
			}
			
		}
	}
}
