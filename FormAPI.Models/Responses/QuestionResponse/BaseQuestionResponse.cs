using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Responses.QuestionResponse
{
	public class BaseQuestionResponse
	{
		public string Question { get; set; } = "What is my name";
		public bool EnableCustomAnswer { get; set; } = false;

	}
}
