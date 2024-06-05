using FormAPI.Models.Helpers;

namespace FormAPI.Models.Entities
{
	public class CustomQuestion : BaseEntity
	{
		public string Question { get; set; } = "What is my name";

		private string type = Constants.TypeOptionsDynamic.ElementAt(0);

		public string Type
		{
			get => type; 
			set
			{
				if (Constants.TypeOptionsDynamic.All(u => u != value))
				{
					type = Constants.TypeOptionsDynamic.ElementAt(0);
				}
				else
				{
					type = value;
				}

			}
		}
		public List<string> MultiChoiceOption { get; set; } = new();
		public List<string> DropDownItems { get; set; } = new();
		public int MaxChoiceAllowed { get; set; } = 4;
		public bool EnableCustomAnswer { get; set; } = false;
		public string FormConfigId { get; set; }
	}
}
