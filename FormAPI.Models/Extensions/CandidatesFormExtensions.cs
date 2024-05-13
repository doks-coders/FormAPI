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
		/// <summary>
		/// Gets overrides the Id, FormConfigurationId and partitionKeyPath with previous entity
		/// </summary>
		/// <param name="candidateform"></param>
		/// <param name="older"></param>
		/// <returns></returns>
		public static CandidateForm GetIdandPartitionKey(this CandidateForm candidateform, CandidateForm older)
		{
			candidateform.id = older.id;
			candidateform.FormConfigurationId = older.FormConfigurationId;
			candidateform.partitionKeyPath = older.partitionKeyPath;
			return candidateform;
		}
	}
}
