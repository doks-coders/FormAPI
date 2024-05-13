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
		public static MandatoryEntityProperty IncaseOfEmptyFields (this MandatoryEntityProperty property, MandatoryEntityProperty substitute)
		{
			property.Type = substitute.Type;
			property.Label = substitute.Label;
			return property;
		}
		
	}
}
