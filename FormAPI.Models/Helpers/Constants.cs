using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Helpers
{
	public static class Constants
	{
		public static List<string> TypeOptionsDynamic = new() { "Paragraph", "Yes/No", "Dropdown", "Date", "Number","MultipleChoice" };
		public static List<string> TypeOptions = new() { "text", "date", "number"};

		
	}
}
