using FormAPI.Models.Entities;
using FormAPI.Models.Requests;
using FormAPI.Models.Responses;
using Riok.Mapperly.Abstractions;

namespace FormAPI.Models.Helpers
{
	[Mapper]
	public partial class MapperProfiles
	{
		public partial FormConfiguration CreateFormConfigurationRequestToFormConfiguration(CreateFormConfigurationRequest form);
		public partial FormConfiguration UpdateFormConfigurationRequestToFormConfiguration(UpdateFormConfigurationRequest form);
		public partial FormConfigurationsResponse FormConfigurationToFormConfigurationResponse(FormConfiguration form);
		public partial CandidateForm CandidateFormRequestToCandidateForm(CreateCandidateFormRequest form);
		public partial CustomQuestion CustomQuestionRequestToCustomQuestion(CustomQuestionRequest form);
		public partial CustomQuestionResponse CustomQuestionToCustomQuestionResponse(CustomQuestion entity);


		
	}
}
