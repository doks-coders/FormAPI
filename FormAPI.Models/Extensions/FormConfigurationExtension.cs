﻿using FormAPI.Models.Entities;

namespace FormAPI.Models.Extensions
{
	public static class FormConfigurationExtension
	{
		/// <summary>
		/// This sets the id and partitionkey. It gets the initial properties from the previous values and updates them here
		/// </summary>
		/// <param name="formProperties"></param>
		/// <param name="older"></param>
		/// <returns></returns>
		public static FormConfiguration GetIdandPartitionKey(this FormConfiguration formProperties, FormConfiguration older)
		{
			formProperties.id = older.id;
			formProperties.partitionKeyPath = older.partitionKeyPath;
			return formProperties;
		}

		/// <summary>
		/// This extension sets the mandatory values for mandatary items
		/// </summary>
		/// <param name="formProperties"></param>
		/// <returns></returns>
		public static FormConfiguration SetMandatoryProperties(this FormConfiguration formProperties)
		{

			formProperties.FirstName = new() { Label = "First Name", Type = "text",Mandatory=true };
			formProperties.LastName = new() { Label = "Last Name", Type = "text",Mandatory=true };
			formProperties.Email = new() { Label = "Last Name", Type = "text",Mandatory = true };

			return formProperties;
		}

		/// <summary>
		/// This static method inputs default values in the FormConfiguration properties
		/// </summary>
		/// <param name="properties"></param>
		/// <returns></returns>
		public static FormConfiguration SetDefaultIfEmpty(this FormConfiguration properties)
		{
			properties.CurrentResidence = properties.CurrentResidence.OverrideEmptyFields(new() { Label = "Current Residence", Type = "text" });
			properties.DateOfBirth = properties.DateOfBirth.OverrideEmptyFields(new() { Label = "Date Of Birth", Type = "text" });
			properties.Phone = properties.Phone.OverrideEmptyFields(new() { Label = "Phone", Type = "number" });
			properties.Gender = properties.Gender.OverrideEmptyFields(new() { Label = "Gender", Type = "text" });
			properties.Nationality = properties.Nationality.OverrideEmptyFields(new() { Label = "Nationality", Type = "text" });
			properties.IdNumber = properties.IdNumber.OverrideEmptyFields(new() { Label = "Id Number", Type = "number" });

			return properties;

		}
	}
}
