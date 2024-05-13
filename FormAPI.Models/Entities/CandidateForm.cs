using FormAPI.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Entities
{

	public class CandidateForm : BaseEntity
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
