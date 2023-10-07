using System.Collections.Generic;
using System.Linq;

namespace HeadHunterAnalyzer.Desktop.Services.Parser {

	public class KeyWordsParser : IKeyWordsParser {

		public List<string> DecodeKeyWords(string keyWords) => keyWords.Split(',')
			.Where(str => !string.IsNullOrWhiteSpace(str))
			.Select(str => str.Trim())
			.Distinct()
			.ToList();


		public string EncodeKeyWords(IEnumerable<string> words) => string.Join(", ", words.Distinct());
	}
}