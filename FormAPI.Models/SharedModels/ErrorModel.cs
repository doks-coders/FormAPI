namespace FormAPI.Models.SharedModels
{
	public class ErrorModel
	{
		public string StackTrace { get; set; } = string.Empty;
		public string Message { get; set; } = string.Empty;
		public string StatusCode { get; set; } = string.Empty;

		public ErrorModel(string statusCode, string message, string stackTrace)
		{
			StatusCode = statusCode;
			Message = message;
			StackTrace = stackTrace;
		}
	}
}
