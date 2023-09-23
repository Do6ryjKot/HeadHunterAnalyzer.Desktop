using Entities.DataTransferObjects;
using Newtonsoft.Json;

namespace HeadHunterAnalyzer.API {
	
	public class HeadHunterAnalyzerApiHttpClient {

		private readonly HttpClient _client;

		public HeadHunterAnalyzerApiHttpClient(HttpClient client) {
			_client = client;
		}

		private async Task<T?> GetAsync<T>(string uri) {

			var response = await _client.GetAsync(uri);

			string json = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<T>(json);
		}

		public async Task<IEnumerable<WordStatisticsDto>?> GetAllWords() {

			return await GetAsync<IEnumerable<WordStatisticsDto>>("api/words");
		}
	}
}
