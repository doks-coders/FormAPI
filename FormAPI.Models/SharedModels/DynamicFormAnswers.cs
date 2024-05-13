using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.SharedModels
{
	public class DynamicFormAnswers
	{
		public string Question { get; set; }
		public string Type { get; set; }

		public string Answer { get; set; }
		public List<string> MultiChoiceAnswers { get; set; } = new();
		public string CustomAnswer { get; set; } = string.Empty;

	}
}
