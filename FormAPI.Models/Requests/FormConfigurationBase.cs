using FormAPI.Models.SharedModels;

namespace FormAPI.Models.Requests
{
	public class FormConfigurationBase
	{
		public string ProgramTitle { get; set; }

		public string ProgramDescription { get; set; }

		public OptionalProperty Phone { get; set; }
		public OptionalProperty Nationality { get; set; }
		public OptionalProperty CurrentResidence { get; set; }
		public OptionalProperty IdNumber { get; set; }
		public OptionalProperty DateOfBirth { get; set; }
		public OptionalProperty Gender { get; set; }


	}
}
