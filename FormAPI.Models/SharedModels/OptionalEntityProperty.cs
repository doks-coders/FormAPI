namespace FormAPI.Models.SharedModels
{
	public class OptionalEntityProperty : BaseProperty
	{
		public bool Hidden { get; set; } = false;
		public bool Internal { get; set; } = false;
	}
}
