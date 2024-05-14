using FormAPI.Models.SharedModels;

namespace FormAPI.Models.Entities
{
	/// <summary>
	/// This are the properties of the FormConfiguration entity
	/// </summary>
	public class FormConfiguration : BaseEntity
	{

		public string ProgramTitle { get; set; }

		public string ProgramDescription { get; set; }

		public MandatoryEntityProperty FirstName { get; set; }
		public MandatoryEntityProperty LastName { get; set; }
		public MandatoryEntityProperty Email { get; set; }
		public OptionalEntityProperty Phone { get; set; }
		public OptionalEntityProperty Nationality { get; set; }
		public OptionalEntityProperty CurrentResidence { get; set; }
		public OptionalEntityProperty IdNumber { get; set; }
		public OptionalEntityProperty DateOfBirth { get; set; }
		public OptionalEntityProperty Gender { get; set; }


	}
}
