using FormAPI.Models.Entities;
using FormAPI.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


		public static CustomQuestion CheckType(this CustomQuestion item)
		{

			if (Constants.TypeOptionsDynamic.All(u => u != item.Type))
			{
				item.Type = Constants.TypeOptionsDynamic.ElementAt(0);
			}
			return item;

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
