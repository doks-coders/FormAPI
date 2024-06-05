namespace FormAPI.Models.Responses.QuestionResponse
{
    internal class MultiChoiceResponse:BaseQuestionResponse
    {
        public string Type { get; set; } = "MultiChoice";
        public List<string> MultiChoiceOption { get; set; } = new();
    }
}
