using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.SharedModels
{
	public class OptionalEntityProperty:BaseProperty
	{
		public bool Hidden { get; set; } = false;
		public bool Internal { get; set; } = false;
	}
}
