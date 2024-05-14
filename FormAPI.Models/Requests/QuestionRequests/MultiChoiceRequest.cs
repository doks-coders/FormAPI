namespace FormAPI.Models.Requests.QuestionRequests
{
	internal class MultiChoiceRequest
	{
		public string Question { get; set; } = "What is my name";
		public string Type { get; set; } = "MultiChoice";
		public List<string> MultiChoiceOption { get; set; } = new();
	}
}
