using FormAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Infrastructure.Data
{
	public class ApplicationDataContext
	{

		public ApplicationDataContext(DataContext db)
		{
			CandidateForms = new(db);
			FormConfigurations = new(db);
		}

		public DbSet<CandidateForm> CandidateForms { get; set; }
		public DbSet<FormConfiguration> FormConfigurations { get; set; }


	}
}
