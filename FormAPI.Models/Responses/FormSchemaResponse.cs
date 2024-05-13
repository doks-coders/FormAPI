using FormAPI.Models.SharedModels;


namespace FormAPI.Models.Responses
{
	public class FormSchemaResponse
	{
		public MandatoryProperty FirstName { get; set; } = new MandatoryProperty() { Label = "First Name", Type = "text", Mandatory = true };

		public MandatoryProperty LastName { get; set; } = new MandatoryProperty() { Label = "Last Name", Type = "text", Mandatory = true };

		public MandatoryProperty Email { get; set; } = new MandatoryProperty() { Label = "Email", Type = "text", Mandatory = true };

		public OptionalProperty? Phone { get; set; } = new OptionalProperty() { Label = "Phone", Type = "number" };

		public OptionalProperty? Nationality { get; set; } = new OptionalProperty() { Label = "Nationality", Type = "text" };

		public OptionalProperty? CurrentResidence { get; set; } = new OptionalProperty() { Label = "Current Residence", Type = "text" };

		public OptionalProperty? IdNumber { get; set; } = new OptionalProperty() { Label = "Id Number", Type = "number" };

		public OptionalProperty? DateOfBirth { get; set; } = new OptionalProperty() { Label = "Date Of Birth", Type = "date" };

		public OptionalProperty? Gender { get; set; } = new OptionalProperty() { Label = "Gender", Type = "text" };

		public List<DynamicFormProperties> CustomQuestions { get; set; } = new();
	}
}
