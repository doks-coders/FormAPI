using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.SharedModels
{
	public class MandatoryProperty:BaseProperty
	{
		public bool Mandatory { get; set; } = false;
	}
}
