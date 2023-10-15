using Contracts.Logger;
using Entities.DataTransferObjects;
using Entities.ResponseFeatures;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HeadHunterAnalyzer.API {
	
	public class HeadHunterAnalyzerApiHttpClient {

		private readonly HttpClient _client;
		private readonly ILoggerManager _logger;

		public HeadHunterAnalyzerApiHttpClient(HttpClient client, ILoggerManager logger) {
			_client = client;
			_logger = logger;
		}

		private async Task<string> TryGetResponseContent(HttpResponseMessage response) {

			string json = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode) {

				var error = JsonConvert.DeserializeObject<ResultDetails>(json);
				var errorMessage = $"Произошла ошибка при обращении к API HeadHunterAnalyzer, " +
					$"метод: {response.RequestMessage?.RequestUri}";

				if (error == null) {

					_logger.LogError(errorMessage);

					throw new Exception(errorMessage);
				}

				errorMessage += $", ошибка: {error.Message}";
				_logger.LogError(errorMessage);

				throw new Exception(error.Message);
			}

			return json;
		}

		public async Task<T?> PostAsync<T>(string uri, JsonContent content) {

			var response = await _client.PostAsync(uri, content);

			var json = await TryGetResponseContent(response);

			return JsonConvert.DeserializeObject<T>(json);
		}

		public async Task<T?> GetAsync<T>(string uri) {

			var response = await _client.GetAsync(uri);

			var json = await TryGetResponseContent(response);

			return JsonConvert.DeserializeObject<T>(json);
		}

		public async Task<PagedList<T>?> GetPagedList<T>(string uri) {

			var response = await _client.GetAsync(uri);

			string json = await TryGetResponseContent(response);

			var vacancies = JsonConvert.DeserializeObject<IEnumerable<T>>(json);

			var metadata = TryGetPaginationMetadata(response);

			return PagedList<T>.ToPagedList(vacancies, metadata);
		}

		private PaginationMetadata TryGetPaginationMetadata(HttpResponseMessage response) {

			IEnumerable<string> paginationHeaderValues;

			if (!(response.Headers.TryGetValues("X-Pagination", out paginationHeaderValues) && paginationHeaderValues.Count() > 0)) {

				string error = $"Данные о пагинации не были найдены. метод: {response.RequestMessage?.RequestUri}";

				_logger.LogError(error);
				throw new Exception(error);
			}

			return JsonConvert.DeserializeObject<PaginationMetadata>(paginationHeaderValues.First());
		}

		[Obsolete]
		private async Task<T?> DeserializeResponse<T>(HttpResponseMessage response) {

			string json = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode) {

				var error = JsonConvert.DeserializeObject<ResultDetails>(json);
				var errorMessage = $"Произошла ошибка при обращении к API HeadHunterAnalyzer, " +
					$"метод: {response.RequestMessage?.RequestUri}";

				if (error == null) {

					_logger.LogError(errorMessage);

					throw new Exception(errorMessage);
				}

				errorMessage += $", ошибка: {error.Message}";
				_logger.LogError(errorMessage);

				throw new Exception(error.Message);
			}

			return JsonConvert.DeserializeObject<T>(json);
		}
	}
}
