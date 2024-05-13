using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.SharedModels
{
	public class OptionalProperty:BaseProperty
	{
		public bool Hidden { get; set; } = false;
	}
}
