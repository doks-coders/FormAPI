using FormAPI.Models.Entities;
using FormAPI.Models.Helpers;
using FormAPI.Models.Requests;
using FormAPI.Models.Responses.QuestionResponse;
using System.Text.Json;

namespace FormAPI.Models.Extensions
{
    public static class CustomQuestionExtensions
	{
		/// <summary>
		/// Checks the types to verify the type entered into the system
		/// </summary>
		/// <param name="items"></param>
		/// <returns></returns>
		public static List<CustomQuestion> CheckType(this List<CustomQuestion> items)
		{
			items = items.ConvertAll(item =>
			{
				if (Constants.TypeOptionsDynamic.All(u => u != item.Type))
				{
					item.Type = Constants.TypeOptionsDynamic.ElementAt(0);
				}
				return item;
			});

			return items;
		}

		/// <summary>
		/// Verifies to see if the Type exists and sets a default one, if it doesnt
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public static CustomQuestion CheckType(this CustomQuestion item)
		{

			if (Constants.TypeOptionsDynamic.All(u => u != item.Type))
			{
				item.Type = Constants.TypeOptionsDynamic.ElementAt(0);
			}
			return item;

		}

		/// <summary>
		/// Gets all the appropriate question types for the custom questions
		/// </summary>
		/// <param name="items"></param>
		/// <returns></returns>
		public static List<object> GetChildren(this List<CustomQuestion> items)
		{
			List<object> children = items.ConvertAll(item =>
			{
				return item.GetChild();
			});

			return children;
		}
		/// <summary>
		/// Gets the appropriate question type for the custom question
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public static object GetChild(this CustomQuestion item)
		{
			var itemObject = JsonSerializer.Serialize(item);
			switch (item.Type)
			{
				case "Paragraph":
					return JsonSerializer.Deserialize<ParagraphResponse>(itemObject);
				case "Yes/No":
					return JsonSerializer.Deserialize<YesNoResponse>(itemObject);
				case "Number":
					return JsonSerializer.Deserialize<NumberResponse>(itemObject);
				case "Dropdown":
					return JsonSerializer.Deserialize<DropDownResponse>(itemObject);
				case "MultipleChoice":
					return JsonSerializer.Deserialize<MultiChoiceResponse>(itemObject);
				default:
					return JsonSerializer.Deserialize<CustomQuestionRequest>(itemObject); ;

			}

		}

		public static CustomQuestion GetIdandPartitionKey(this CustomQuestion question, CustomQuestion older)
		{
			question.id = older.id;
			question.partitionKeyPath = older.partitionKeyPath;
			question.FormConfigId = older.FormConfigId;
			return question;
		}
	}
}
