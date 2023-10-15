using Entities.DataTransferObjects;
using Entities.Models;
using Entities.ResponseFeatures;

namespace Contracts.HeadHunterAnalyzer {
	
	/// <summary>
	/// Сервис взаимодействия с API.
	/// </summary>
	public interface IHeadHunterAnalyzerService {

		public Task<IEnumerable<WordStatisticsDto>> GetAllWords();

		public Task<AnalyzedVacancy> AnalyzeVacancy(int headHunterId);

		public Task<string> SaveAnalyzedVacancy(int headHunterId, IEnumerable<Word> words);

		public Task<PagedList<Vacancy>> GetAnalyzedVacancies(int pageNumber, int pageSize);
	}
}
