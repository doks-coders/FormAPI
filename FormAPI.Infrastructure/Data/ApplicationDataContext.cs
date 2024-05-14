using FormAPI.Models.Entities;

namespace FormAPI.Infrastructure.Data
{
	public class ApplicationDataContext
	{

		public ApplicationDataContext(DataContext db)
		{
			CandidateForms = new(db);
			FormConfigurations = new(db);
			CustomQuestions = new(db);
		}

		public DbSet<CandidateForm> CandidateForms { get; set; }
		public DbSet<FormConfiguration> FormConfigurations { get; set; }
		public DbSet<CustomQuestion> CustomQuestions { get; set; }


	}

}
