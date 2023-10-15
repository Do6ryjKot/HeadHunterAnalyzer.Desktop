using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace HeadHunterAnalyzer.Desktop.Mapping {
	
	public class MappingProfile : Profile {

        public MappingProfile() {

			CreateMap<AnalyzedVacancyDto, AnalyzedVacancy>()
				.ForMember(vacancy => vacancy.Name, opt => opt.MapFrom(dto => dto.VacancyData.Name))
				.ForMember(vacancy => vacancy.Experience, opt => opt.MapFrom(dto => dto.VacancyData.Experience))
				.ForMember(vacancy => vacancy.Body, opt => opt.MapFrom(dto => dto.VacancyData.Body));

			CreateMap<AnalyzedCompanyDto, AnalyzedCompany>();

			CreateMap<WordDto, Word>();
			CreateMap<Word, WordForCreationDto>();

			CreateMap<VacancyDto, Vacancy>();
		}
    }
}
