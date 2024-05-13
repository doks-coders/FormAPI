using FormAPI.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Extensions
{
	public static class MandatoryPropertyExtensions
	{
		/// <summary>
		/// This method properties are overidden by the substitute
		/// </summary>
		/// <param name="property"></param>
		/// <param name="substitute"></param>
		/// <returns></returns>
		public static MandatoryEntityProperty OverrideEmptyFields (this MandatoryEntityProperty property, MandatoryEntityProperty substitute)
		{
			property.Type = substitute.Type;
			property.Label = substitute.Label;
			return property;
		}
		
	}
}
