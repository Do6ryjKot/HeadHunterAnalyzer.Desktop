using AutoMapper;
using Contracts.HeadHunterAnalyzer;
using Contracts.Logger;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Net.Http.Json;

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
			
			var result = await _client.GetAsync<IEnumerable<WordStatisticsDto>>("api/words");

			if (result == null) {

				_logger.LogWarning($"{typeof(HeadHunterAnalyzerApiService)}.{nameof(GetAllWords)} got null word collection.");
			}

			return result ?? new List<WordStatisticsDto>();
		}

		public async Task<AnalyzedVacancy> AnalyzeVacancy(int headHunterId) {

			var dto = await _client.GetAsync<AnalyzedVacancyDto>($"api/vacancies/{headHunterId}");

			if (dto == null) {

				_logger.LogWarning($"{typeof(HeadHunterAnalyzerApiService)}.{nameof(AnalyzeVacancy)} got null {nameof(AnalyzedVacancyDto)}.");
				return new AnalyzedVacancy();
			}

			var result = _mapper.Map<AnalyzedVacancy>(dto);

			return result;
		}
	
		public async Task<string> SaveAnalyzedVacancy(int headHunterId, IEnumerable<Word> words) {

			VacancyForCreationDto vacancy = new VacancyForCreationDto {

				HeadHunterId = headHunterId,
				Words = _mapper.Map<IEnumerable<WordForCreationDto>>(words)
			};

			var result = await _client.PostAsync<ResultDetails>("api/vacancies", JsonContent.Create(vacancy));

			if (result == null) {

				_logger.LogWarning($"Got null result on posting new vacancy {headHunterId}, [ {words} ]");
				return "Получен пустой результат.";
			}

			return result.Message;
		}
	
		public async Task<IEnumerable<VacancyDto>> GetAnalyzedVacancies(int pageNumber, int pageSize) {

			var result = await _client.GetAsync($"api/vacancies?pageNumber={pageNumber}&pageSize={pageSize}");

			if (result == null) {

				_logger.LogWarning($"{typeof(HeadHunterAnalyzerApiService)}" +
					$".{nameof(GetAnalyzedVacancies)} got null vacancies collection. PageNumber: {pageNumber}, PageSize: {pageSize}.");
			}

			return result ?? new List<VacancyDto>();
		}
	}
}
