using Entities.DataTransferObjects;

namespace Contracts.HeadHunterAnalyzer {
	
	/// <summary>
	/// Сервис взаимодействия с API.
	/// </summary>
	public interface IHeadHunterAnalyzerService {

		public Task<IEnumerable<WordStatisticsDto>> GetAllWords();
	}
}
