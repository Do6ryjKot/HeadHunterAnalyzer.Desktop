using Contracts.HeadHunterAnalyzer;
using Contracts.Logger;
using Entities.DataTransferObjects;

namespace HeadHunterAnalyzer.API {

	public class HeadHunterAnalyzerApiService : IHeadHunterAnalyzerService {

		private readonly HeadHunterAnalyzerApiHttpClient _client;
		private readonly ILoggerManager _logger;

		public HeadHunterAnalyzerApiService(HeadHunterAnalyzerApiHttpClient client, ILoggerManager logger) {
			_client = client;
			_logger = logger;
		}

		public async Task<IEnumerable<WordStatisticsDto>> GetAllWords() {
			
			var result = await _client.GetAllWords();

			if (result == null) {

				_logger.LogWarning($"{typeof(HeadHunterAnalyzerApiService)}.{nameof(GetAllWords)} got null word collection.");
			}

			return result ?? new List<WordStatisticsDto>();
		}
	}
}
