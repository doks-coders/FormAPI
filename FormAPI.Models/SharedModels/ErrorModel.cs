using FormAPI.Models.Helpers;
using System.Net;

namespace FormAPI.Models.SharedModels
{
	public class ErrorModel
	{
		public string StackTrace { get; set; } = string.Empty;
		public string Message { get; set; } = string.Empty;
		public string StatusCode { get; set; } = string.Empty;

		private const string ErrorKeyWord = "ERROR";
		private const string MessageKeyWord = "MESSAGE";
		public ErrorModel(string statusCode, string message, string stackTrace)
		{

			StatusCode = statusCode;
			Message = message;
			StackTrace = stackTrace;

			var identifierKeyWord = message.Split(":")[0];
			var errorMessage = message.Split(":")[1];

			ErrorIdentifiers identifier;
			Enum.TryParse(identifierKeyWord, out identifier);

			ErrorStatusEnums errorStatus;
			Enum.TryParse(errorMessage, out errorStatus);

			switch (identifier)
			{
				case ErrorIdentifiers.CustomError:
					StatusCode = ErrorDictionary[errorStatus][ErrorKeyWord];
					Message = ErrorDictionary[errorStatus][MessageKeyWord];
					break;
				case ErrorIdentifiers.ValidationErrors:
					StatusCode = ((int)HttpStatusCode.Unauthorized).ToString();
					Message = errorMessage;
					break;
				case ErrorIdentifiers.UnclassifiedError:
					StatusCode = ((int)HttpStatusCode.InternalServerError).ToString();
					Message = errorMessage;
					break;
				default:
					StatusCode = ((int)HttpStatusCode.InternalServerError).ToString();
					Message = errorMessage;
					break;
			}
		}

		private Dictionary<ErrorStatusEnums,
			Dictionary<string, string>
			> ErrorDictionary => new Dictionary<ErrorStatusEnums, Dictionary<string, string>>()
			{
				{
					ErrorStatusEnums.FormNotFound,
					new()
					{
						{MessageKeyWord,"Form not found"},
						{ErrorKeyWord,((int)HttpStatusCode.NotFound).ToString() }
					}
				},
				{
					ErrorStatusEnums.FormDeleteFailed,
					new()
					{
						{MessageKeyWord,"Form could not be deleted"},
						{ErrorKeyWord,((int)HttpStatusCode.AlreadyReported).ToString() }
					}
				},
				{
					ErrorStatusEnums.FormCreationFailed,
					new()
					{
						{MessageKeyWord,"Form could not be created"},
						{ErrorKeyWord,((int)HttpStatusCode.BadRequest).ToString() }
					}
				},
				{
					ErrorStatusEnums.FormUpdateFailed,
					new()
					{
						{MessageKeyWord,"Form could not be updated"},
						{ErrorKeyWord,((int)HttpStatusCode.BadRequest).ToString() }
					}
				},
				{
					ErrorStatusEnums.QuestionNotFound,
					new()
					{
						{MessageKeyWord,"Question could not be found"},
						{ErrorKeyWord,((int)HttpStatusCode.NotFound).ToString() }
					}
				},
				{
					ErrorStatusEnums.QuestionCreationFailed,
					new()
					{
						{MessageKeyWord,"Question could not be created"},
						{ErrorKeyWord,((int)HttpStatusCode.BadRequest).ToString() }
					}
				},
				{
					ErrorStatusEnums.QuestionUpdateFailed,
					new()
					{
						{MessageKeyWord,"Question update failed"},
						{ErrorKeyWord,((int)HttpStatusCode.BadRequest).ToString() }
					}
				},
				{
					ErrorStatusEnums.QuestionDeleteFailed,
					new()
					{
						{MessageKeyWord,"Question deleted failed"},
						{ErrorKeyWord,((int)HttpStatusCode.BadRequest).ToString() }
					}
				},
				{
					ErrorStatusEnums.ClientFormCreationFailed,
					new()
					{
						{MessageKeyWord,"Client's form did not save"},
						{ErrorKeyWord,((int)HttpStatusCode.BadRequest).ToString() }
					}
				}


				
			};
	}
}
