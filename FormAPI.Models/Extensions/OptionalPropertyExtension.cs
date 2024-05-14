using FormAPI.Models.SharedModels;

namespace FormAPI.Models.Extensions
{
	public static class OptionalPropertyExtension
	{
		/// <summary>
		/// This method properties are overidden by the substitute
		/// </summary>
		/// <param name="property"></param>
		/// <param name="substitute"></param>
		/// <returns></returns>
		public static OptionalEntityProperty OverrideEmptyFields(this OptionalEntityProperty property, OptionalEntityProperty subsitute)
		{
			property.Type = subsitute.Type;
			property.Label = subsitute.Label;
			return property;
		}
	}

}
