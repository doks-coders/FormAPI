using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Requests
{
	public class UpdateFormConfigurationRequest:FormConfigurationBase
	{
		public string id { get; set; }
	}
}
