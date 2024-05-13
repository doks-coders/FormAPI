using FormAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Models.Extensions
{
	public static class CandidatesFormExtensions
	{
		public static CandidateForm GetIdandPartitionKey(this CandidateForm candidateform, CandidateForm older)
		{
			candidateform.id = older.id;
			candidateform.FormConfigurationId = older.FormConfigurationId;
			candidateform.partitionKeyPath = older.partitionKeyPath;
			return candidateform;
		}
	}
}
