using Entities.Models;
using HeadHunterAnalyzer.Desktop.Services.Parser;
using HeadHunterAnalyzer.Desktop.ViewModels;
using System.Collections.Generic;

namespace HeadHunterAnalyzer.Desktop.Commands.Sync.RecommendedKeyWord {

	public class AddKeyWordCommand : CommandBase {

		private readonly Word _word;
		private readonly AnalyzeVacancyViewModel _viewModel;
		private readonly IKeyWordsParser _keyWordsParser;

		public AddKeyWordCommand(Word word, AnalyzeVacancyViewModel viewModel, IKeyWordsParser keyWordsParser) {
			_word = word;
			_viewModel = viewModel;
			_keyWordsParser = keyWordsParser;
		}

		public override void Execute(object? parameter) {

			List<string> words = _keyWordsParser.DecodeKeyWords(_viewModel.KeyWords);

			words.Add(_word.Value);

			_viewModel.KeyWords = _keyWordsParser.EncodeKeyWords(words);
		}
	}
}
