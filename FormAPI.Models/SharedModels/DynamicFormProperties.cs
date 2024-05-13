using FormAPI.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.SharedModels
{
	public class DynamicFormProperties
	{
		public string Question { get; set; } = "What is my name";
		public string Type { get; set; } = Constants.TypeOptionsDynamic.ElementAt(0);
		public List<string> MultiChoiceOption { get; set; } = new();
		public List<string> MultiSelectOption { get; set; } = new();
		public int MaxChoiceAllowed { get; set; } = 4;
		public bool EnableCustomAnswer { get; set; } = false;

	}
}
