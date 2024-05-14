namespace FormAPI.Models.Requests.QuestionRequests
{
	public class DateRequest
	{
		public string Question { get; set; } = "What is my name";
		public string Type { get; set; } = "Date";
		public List<string> MultiChoiceOption { get; set; } = new();
		public List<string> DropDownItems { get; set; } = new();
	}
}
