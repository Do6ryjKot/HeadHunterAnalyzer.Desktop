using AutoMapper;
using Contracts.HeadHunterAnalyzer;
using Contracts.Logger;
using Entities.DataTransferObjects;
using Entities.Models;

namespace HeadHunterAnalyzer.API {

	public class HeadHunterAnalyzerApiService : IHeadHunterAnalyzerService {

		private readonly HeadHunterAnalyzerApiHttpClient _client;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

		public HeadHunterAnalyzerApiService(HeadHunterAnalyzerApiHttpClient client, ILoggerManager logger, IMapper mapper) {
			_client = client;
			_logger = logger;
			_mapper = mapper;
		}

		public async Task<IEnumerable<WordStatisticsDto>> GetAllWords() {
			
			var result = await _client.GetAllWords();

			if (result == null) {

				_logger.LogWarning($"{typeof(HeadHunterAnalyzerApiService)}.{nameof(GetAllWords)} got null word collection.");
			}

			return result ?? new List<WordStatisticsDto>();
		}

		public async Task<AnalyzedVacancy> AnalyzeVacancy(int headHunterId) {

			var dto = await _client.AnalyzeVacancy(headHunterId);

			if (dto == null) {

				_logger.LogWarning($"{typeof(HeadHunterAnalyzerApiService)}.{nameof(AnalyzeVacancy)} got null {nameof(AnalyzedVacancyDto)}.");
				return new AnalyzedVacancy();
			}

			var result = _mapper.Map<AnalyzedVacancy>(dto);

			return result;
		}
	}
}
