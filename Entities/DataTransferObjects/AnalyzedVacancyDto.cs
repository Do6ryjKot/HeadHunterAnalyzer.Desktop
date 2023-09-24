namespace Entities.DataTransferObjects {
	
	public class AnalyzedVacancyDto {

		public VacancyData VacancyData { get; set; }
		public AnalyzedCompanyDto Company { get; set; }
		public bool AlreadyAnalyzed { get; set; }
		public IEnumerable<WordDto> Words { get; set; }
	}
}
