using FormAPI.Models.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Extensions
{
	public static class OptionalPropertyExtension
	{
		public static OptionalProperty IncaseOfEmptyFields(this OptionalProperty property,OptionalProperty subsitute)
		{
			if (string.IsNullOrEmpty(property.Type))
			{
				property.Type = subsitute.Type;
			}
			if (string.IsNullOrEmpty(property.Label))
			{
				property.Label = subsitute.Label;
			}
			return property;
		}
	}

}
