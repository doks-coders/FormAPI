using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Helpers
{
	public enum ErrorStatusEnums
	{
		FormNotFound,
		FormCreationFailed,
		FormUpdateFailed,
		FormDeleteFailed,

		QuestionNotFound,
		QuestionCreationFailed,
		QuestionUpdateFailed,
		QuestionDeleteFailed,

		ClientFormCreationFailed
		

	}

	public enum ErrorIdentifiers
	{
		ValidationErrors,
		CustomError,
		UnclassifiedError,
	}
}
