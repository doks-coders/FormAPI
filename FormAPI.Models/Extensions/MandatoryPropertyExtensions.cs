using FormAPI.Models.SharedModels;

namespace FormAPI.Models.Extensions
{
	public static class MandatoryPropertyExtensions
	{
		/// <summary>
		/// This method properties are overidden by the substitute
		/// </summary>
		/// <param name="property"></param>
		/// <param name="substitute"></param>
		/// <returns></returns>
		public static MandatoryEntityProperty OverrideEmptyFields(this MandatoryEntityProperty property, MandatoryEntityProperty substitute)
		{
			property.Type = substitute.Type;
			property.Label = substitute.Label;
			return property;
		}

	}
}
