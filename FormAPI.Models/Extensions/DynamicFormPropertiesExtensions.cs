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
	public static class DynamicFormPropertiesExtensions
	{
		/// <summary>
		/// Checks the types to verify the type entered into the system
		/// </summary>
		/// <param name="items"></param>
		/// <returns></returns>
		public static List<DynamicFormProperties> CheckType(this List<DynamicFormProperties> items)
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
	}
}
