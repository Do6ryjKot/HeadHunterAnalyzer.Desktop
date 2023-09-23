using Entities.DataTransferObjects;

namespace HeadHunterAnalyzer.Desktop.ViewModels.Components.Lists {
	
	/// <summary>
	/// Модель представления элемента списка слов на главной странице.
	/// </summary>
	public class WordStatisticsViewModel : ViewModelBase {

		private readonly WordStatisticsDto _word;

		public WordStatisticsViewModel(WordStatisticsDto word) {
			_word = word;
		}

		public string WordValue => _word.Value;
		public int Occurences => _word.Occurrences;
	}
}
