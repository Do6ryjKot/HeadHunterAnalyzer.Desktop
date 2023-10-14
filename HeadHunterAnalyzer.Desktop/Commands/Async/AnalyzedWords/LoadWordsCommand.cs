using Contracts.HeadHunterAnalyzer;
using HeadHunterAnalyzer.Desktop.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Commands.Async.AnalyzedWords {

	public class LoadWordsCommand : AsyncCommandBase {

		private readonly AnalyzedWordsViewModel _viewModel;
		private readonly IHeadHunterAnalyzerService _hhService;

		public LoadWordsCommand(Action<Exception> onException, AnalyzedWordsViewModel viewModel,
			IHeadHunterAnalyzerService hhService) : base(onException) {

			_hhService = hhService;
			_viewModel = viewModel;
		}

		public override async Task ExecuteAsync(object? parameter) {

			var words = await _hhService.GetAllWords();

			_viewModel.Words = words.ToList();
		}
	}
}
