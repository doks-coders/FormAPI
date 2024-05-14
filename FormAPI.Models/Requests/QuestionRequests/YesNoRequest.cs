namespace FormAPI.Models.Requests.QuestionRequests
{
	public class YesNoRequest
	{
		public string Question { get; set; } = "What is my name";
		public string Type { get; set; } = "YesNo";
	}
}
