using FormAPI.Models.Entities;
using FormAPI.Models.Helpers;
using FormAPI.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Extensions
{
	public static class CustomQuestionAnswersExtensions
	{
		public static List<CustomQuestionAnswers> CheckType(this List<CustomQuestionAnswers> items)
		{
			items = items.ConvertAll(item =>
			{
				return item.CheckType();
			});

			return items;
		}

		/// <summary>
		/// Verifies to see if the Type exists and sets a default one, if it doesnt
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public static CustomQuestionAnswers CheckType(this CustomQuestionAnswers item)
		{

			if (Constants.TypeOptionsDynamic.All(u => u != item.Type))
			{
				item.Type = Constants.TypeOptionsDynamic.ElementAt(0);
			}
			return item;

		}
	}
}
