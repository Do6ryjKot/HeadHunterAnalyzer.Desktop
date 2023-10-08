using Contracts.Logger;
using Entities.DataTransferObjects;
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

		public async Task<T?> PostAsync<T>(string uri, JsonContent content) {

			var response = await _client.PostAsync(uri, content);

			return await DeserializeResponse<T>(response);
		}

		public async Task<T?> GetAsync<T>(string uri) {

			var response = await _client.GetAsync(uri);

			return await DeserializeResponse<T>(response);
		}

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
