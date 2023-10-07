using Entities.DataTransferObjects;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace HeadHunterAnalyzer.API {
	
	public class HeadHunterAnalyzerApiHttpClient {

		private readonly HttpClient _client;

		public HeadHunterAnalyzerApiHttpClient(HttpClient client) {
			_client = client;
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

			if (!response.IsSuccessStatusCode)
				throw new Exception("Произошла ошибка при обращении к API HeadHunterAnalyzer");

			string json = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<T>(json);
		}
	}
}
