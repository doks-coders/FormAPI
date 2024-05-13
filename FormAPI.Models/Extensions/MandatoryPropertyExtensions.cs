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
		public static MandatoryProperty IncaseOfEmptyFields (this MandatoryProperty property, MandatoryProperty substitute)
		{
			if (string.IsNullOrEmpty(property.Label))
			{
				property.Label = substitute.Label;
			}
			return property;
		}
		
	}
}
