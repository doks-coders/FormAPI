using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Requests.QuestionRequests
{
	public class DateRequest
	{
		public string Question { get; set; } = "What is my name";
		public string Type { get; set; } = "Date";
		public List<string> MultiChoiceOption { get; set; } = new();
		public List<string> DropDownItems { get; set; } = new();
	}
}
