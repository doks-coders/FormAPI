using FormAPI.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Entities
{
    /// <summary>
    /// This are the properties of the FormConfiguration entity
    /// </summary>
    public class FormConfiguration:BaseEntity
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

		public List<CustomQuestion> CustomQuestions { get; set; }
	}
}
