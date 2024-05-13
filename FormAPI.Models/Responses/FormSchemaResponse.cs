using FormAPI.Models.Helpers;
using FormAPI.Models.SharedModels;


namespace FormAPI.Models.Responses
{
	public class FormSchemaResponse
	{
		public MandatoryProperty FirstName { get; set; } = new MandatoryProperty() { Mandatory = true };

		public MandatoryProperty LastName { get; set; } = new MandatoryProperty() { Mandatory = true };

		public MandatoryProperty Email { get; set; } = new MandatoryProperty() { Mandatory = true };

		public OptionalProperty? Phone { get; set; } = new OptionalProperty() {};

		public OptionalProperty? Nationality { get; set; } = new OptionalProperty() {};

		public OptionalProperty? CurrentResidence { get; set; } = new OptionalProperty() { };

		public OptionalProperty? IdNumber { get; set; } = new OptionalProperty() {};

		public OptionalProperty? DateOfBirth { get; set; } = new OptionalProperty() { };

		public OptionalProperty? Gender { get; set; } = new OptionalProperty() { };

		public List<DynamicFormProperties> CustomQuestions { get; set; } = new();

		public List<string> TypeOptionsDynamic { get; set; } = Constants.TypeOptionsDynamic;
	
	}
}
