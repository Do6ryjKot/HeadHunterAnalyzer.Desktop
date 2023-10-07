using Contracts.HeadHunterAnalyzer;
using Entities.Models;
using HeadHunterAnalyzer.Desktop.Services.Parser;
using HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy;
using HeadHunterAnalyzer.Desktop.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Commands.Async.AnalyzeVacancy {

	public class SendVacancyCommand : AsyncCommandBase {

		private readonly AnalyzeVacancyViewModel _viewModel;
		private readonly IHeadHunterAnalyzerService _hhService;
		private readonly IKeyWordsParser _parser;
		private readonly IAnalyzedVacancyStore _store;

		public SendVacancyCommand(Action<Exception> onException,
				AnalyzeVacancyViewModel viewModel,
				IHeadHunterAnalyzerService hhService,
				IKeyWordsParser parser,
				IAnalyzedVacancyStore store) : base(onException) {

			_viewModel = viewModel;
			_hhService = hhService;
			_parser = parser;
			_store = store;
		}

		public async override Task ExecuteAsync(object? parameter) {

			// Получаем слова из поля и переводим в модели
			List<string> wordsValues = _parser.DecodeKeyWords(_viewModel.KeyWords);

			if (wordsValues.Count == 0) {

				throw new Exception("Введите ключевые слова.");
			}

			List<Word> words = new List<Word>();

			foreach (string value in wordsValues) {

				words.Add(new Word { Value = value });
			}

			// Отправляем запрос
			string message = await _hhService.SaveAnalyzedVacancy(_viewModel.HeadHunterId, words);

			_viewModel.Message = message;

			await _store.LoadVacancy(_viewModel.HeadHunterId);
		}
	}
}
