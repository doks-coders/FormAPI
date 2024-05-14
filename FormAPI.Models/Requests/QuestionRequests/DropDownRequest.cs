using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Requests.QuestionRequests
{
	public class DropDownRequest
	{
		public string Question { get; set; } = "What is my name";
		public string Type { get; set; } = "Dropdown";
		public List<string> DropDownItems { get; set; } = new();
	}
}
