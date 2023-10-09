using Entities.Models;
using HeadHunterAnalyzer.Desktop.Services.Parser;
using HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy;
using HeadHunterAnalyzer.Desktop.ViewModels;
using System.Collections.Generic;

namespace HeadHunterAnalyzer.Desktop.Commands.Sync.AnalyzeVacancy {

	public class AddAllRecommendedKeyWords : CommandBase {

		private readonly IAnalyzedVacancyStore _vacancyStore;
		private readonly AnalyzeVacancyViewModel _viewModel;
		private readonly IKeyWordsParser _keyWordsParser;

		public AddAllRecommendedKeyWords(IAnalyzedVacancyStore vacancyStore, AnalyzeVacancyViewModel viewModel, IKeyWordsParser keyWordsParser) {
			_vacancyStore = vacancyStore;
			_viewModel = viewModel;
			_keyWordsParser = keyWordsParser;
		}

		public override void Execute(object? parameter) {

			List<string> words = _keyWordsParser.DecodeKeyWords(_viewModel.KeyWords);

			foreach (Word word in _vacancyStore.Words) {

				words.Add(word.Value);
			}

			_viewModel.KeyWords = _keyWordsParser.EncodeKeyWords(words);
		}
	}
}
