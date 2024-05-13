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
		public static OptionalEntityProperty IncaseOfEmptyFields(this OptionalEntityProperty property, OptionalEntityProperty subsitute)
		{
			property.Type = subsitute.Type;
			property.Label = subsitute.Label;
			return property;
		}
	}

}
