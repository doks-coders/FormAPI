using Azure.Core;
using FormAPI.ApplicationCore.Helpers;
using FormAPI.Infrastructure.Validators.Admin;
using FormAPI.Models.Entities;
using FormAPI.Models.Extensions;
using FormAPI.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.ApplicationCore.Utils
{
	public static class AdminServiceUtils
	{
		public static async Task ValidateQuestion(CustomQuestionRequest request)
		{
			CustomQuestionRequestValidator validator = new CustomQuestionRequestValidator();
			var validation = await validator.ValidateAsync(request);
			if (!validation.IsValid) throw new CustomException(validation.Errors);
		}

		public static FormConfiguration ConfigureFormConfiguration(FormConfiguration item)
		{
			item = item.SetDefaultIfEmpty();
			item = item.SetMandatoryProperties();
			return item;
		}
		public static CustomQuestion ConfigureQuestion(CustomQuestion question,string formConfigId)
		{
			question.id = Guid.NewGuid().ToString();
			question.FormConfigId = formConfigId;
			question = question.CheckType();
			return question;
		}
		public static CustomQuestion ConfigureUpdatedQuestion(CustomQuestion updatedQuestion, CustomQuestion question)
		{
			updatedQuestion = updatedQuestion.GetIdandPartitionKey(question);
			updatedQuestion = updatedQuestion.CheckType();
			return updatedQuestion;
		}

		
	
	}
}
