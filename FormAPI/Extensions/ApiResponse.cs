using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace FormAPI.Extensions
{
	public class ApiResponse : ActionResult
	{
		public object Data { get; set; }
		public HttpStatusCode StatusCode { get; set; }

		public override async Task ExecuteResultAsync(ActionContext context)
		{
			context.HttpContext.Response.StatusCode = (int)StatusCode;
			context.HttpContext.Response.ContentType = "application/json";
			await context.HttpContext.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(Data))) ;
		}

		public static ApiResponse Send(object? Data=null, HttpStatusCode? StatusCode = HttpStatusCode.OK)
		{
			var response = new ApiResponse();
			response.Data = Data??string.Empty;
			response.StatusCode =(HttpStatusCode) StatusCode;
			return response;
		}
	}
}
