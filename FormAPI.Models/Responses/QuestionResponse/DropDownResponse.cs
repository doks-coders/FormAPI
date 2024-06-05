namespace FormAPI.Models.Responses.QuestionResponse
{
    public class DropDownResponse:BaseQuestionResponse
    {
        public string Type { get; set; } = "Dropdown";
        public List<string> DropDownItems { get; set; } = new();
    }
}
