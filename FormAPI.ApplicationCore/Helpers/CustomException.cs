using FluentValidation.Results;
using FormAPI.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.ApplicationCore.Helpers
{
	public class CustomException : Exception
	{
		public CustomException(List<ValidationFailure> exceptions) : base($"{ErrorIdentifiers.ValidationErrors}:{ string.Join(", ", exceptions.Select(e => e.ErrorMessage).ToArray())}")
		{

		}

		public CustomException(ErrorStatusEnums error) : base($"{ErrorIdentifiers.CustomError}:{error}")
		{

		}

		public CustomException(string error) : base($"{ErrorIdentifiers.UnclassifiedError}:{error}")
		{

		}



	}
}
