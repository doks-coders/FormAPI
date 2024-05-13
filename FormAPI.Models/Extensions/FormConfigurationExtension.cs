using FormAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Extensions
{
	public static class FormConfigurationExtension
	{
		public static FormConfiguration GetIdandPartitionKey(this FormConfiguration formProperties, FormConfiguration older)
		{
			formProperties.id = older.id;
			formProperties.partitionKeyPath = older.partitionKeyPath;
			return formProperties;
		}

		public static FormConfiguration SetMandatoryProperties(this FormConfiguration formProperties)
		{

			formProperties.FirstName.Mandatory = true;
			formProperties.LastName.Mandatory = true;
			formProperties.Email.Mandatory = true;

			formProperties.partitionKeyPath = "Forms";
			return formProperties;
		}

	}
}
