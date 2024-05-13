using FormAPI.Models.Entities;
using FormAPI.Models.Helpers;
using FormAPI.Models.SharedModels;


namespace FormAPI.Models.Responses
{
    public class FormSchemaResponse
	{
		public string ProgramTitle { get; set; } = "Work Application";

		public string ProgramDescription { get; set; } = "This is a work application research study";

		public MandatoryEntityProperty FirstName { get; set; } = new MandatoryEntityProperty() { Mandatory = true,Label="First Name",Type="text" };

		public MandatoryEntityProperty LastName { get; set; } = new MandatoryEntityProperty() { Mandatory = true,Label="Last Name",Type="text" };

		public MandatoryEntityProperty Email { get; set; } = new MandatoryEntityProperty() { Mandatory = true, Label = "Last Name", Type = "text" };

		public OptionalEntityProperty? Phone { get; set; } = new OptionalEntityProperty() {  Label = "Phone", Type = "number" };

		public OptionalEntityProperty? Nationality { get; set; } = new OptionalEntityProperty() { Label = "Nationality", Type = "text" };

		public OptionalEntityProperty? CurrentResidence { get; set; } = new OptionalEntityProperty() { Label = "Current Residence", Type = "text" };

		public OptionalEntityProperty? IdNumber { get; set; } = new OptionalEntityProperty() { Label = "Id Number", Type = "text" };

		public OptionalEntityProperty? DateOfBirth { get; set; } = new OptionalEntityProperty() { Label = "Date of Birth", Type = "text" };

		public OptionalEntityProperty? Gender { get; set; } = new OptionalEntityProperty() { Label = "Gender", Type = "text" };

		public List<CustomQuestion> CustomQuestions { get; set; } = new List<CustomQuestion>() { new() };

		public List<string> TypeOptionsDynamic { get; set; } = Constants.TypeOptionsDynamic;

		public List<string> TypeOptions { get; set; } = Constants.TypeOptions;
	}
}
