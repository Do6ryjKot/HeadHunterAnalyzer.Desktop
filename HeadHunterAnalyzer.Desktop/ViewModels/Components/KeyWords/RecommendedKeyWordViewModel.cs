using Entities.Models;
using HeadHunterAnalyzer.Desktop.Commands.Sync.RecommendedKeyWord;
using HeadHunterAnalyzer.Desktop.Services.Parser;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels.Components.KeyWords {
	
	public class RecommendedKeyWordViewModel {

		private readonly Word _word;

		public string WordValue => _word.Value;

		public ICommand AddKeyWordCommand { get; }

		public RecommendedKeyWordViewModel(Word word, AnalyzeVacancyViewModel analyzeVacancyViewModel, IKeyWordsParser keyWordsParser) {

			_word = word;
			AddKeyWordCommand = new AddKeyWordCommand(word, analyzeVacancyViewModel, keyWordsParser);
		}
	}
}
