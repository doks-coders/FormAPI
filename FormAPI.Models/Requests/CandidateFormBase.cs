using FormAPI.Models.SharedModels;

namespace FormAPI.Models.Requests
{
	public class CandidateFormBase
	{
		public string FormConfigurationId { get; set; }
		public CandidateStaticProperties FirstName { get; set; }
		public CandidateStaticProperties LastName { get; set; }
		public CandidateStaticProperties Email { get; set; }
		public CandidateStaticProperties? Phone { get; set; }
		public CandidateStaticProperties? Nationality { get; set; }
		public CandidateStaticProperties? CurrentResidence { get; set; }
		public CandidateStaticProperties? IdNumber { get; set; }
		public CandidateStaticProperties? DateOfBirth { get; set; }
		public CandidateStaticProperties? Gender { get; set; }

		public List<DynamicFormAnswers> CustomQuestions { get; set; } = new();
	}
}
