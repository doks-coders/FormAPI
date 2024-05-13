﻿using FormAPI.Models.Entities;
using FormAPI.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Requests
{
    public class FormConfigurationBase
	{
		public string ProgramTitle { get; set; }

		public string ProgramDescription { get; set; }

		public MandatoryProperty FirstName { get; set; }
		public MandatoryProperty LastName { get; set; }
		public MandatoryProperty Email { get; set; }
		public OptionalProperty Phone { get; set; }
		public OptionalProperty Nationality { get; set; }
		public OptionalProperty CurrentResidence { get; set; }
		public OptionalProperty IdNumber { get; set; }
		public OptionalProperty DateOfBirth { get; set; }
		public OptionalProperty Gender { get; set; }

		public List<CustomQuestion> CustomQuestions { get; set; } = new();



	}
}
