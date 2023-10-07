using System.Collections.Generic;

namespace HeadHunterAnalyzer.Desktop.Services.Parser {
	
	/// <summary>
	/// Сервис для парсинга введенных пользователем слов
	/// </summary>
	public interface IKeyWordsParser {

		public List<string> DecodeKeyWords(string keyWords);
		public string EncodeKeyWords(IEnumerable<string> words);
	}
}
