using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Entities
{
	/// <summary>
	/// This is the base entity, it should be inherited by other entities
	/// </summary>
	public class BaseEntity
	{
		public string id { get; set; }
		public string partitionKeyPath { get; set; } = "FORMAPI";
	}
}
