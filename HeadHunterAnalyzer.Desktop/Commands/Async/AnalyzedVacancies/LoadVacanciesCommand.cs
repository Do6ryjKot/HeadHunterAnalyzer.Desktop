using Contracts.HeadHunterAnalyzer;
using HeadHunterAnalyzer.Desktop.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Commands.Async.AnalyzedVacancies {

	public class LoadVacanciesCommand : AsyncCommandBase {

		private readonly AnalyzedVacanciesViewModel _viewModel;
		private readonly IHeadHunterAnalyzerService _hhService;

		public LoadVacanciesCommand(Action<Exception> onException, AnalyzedVacanciesViewModel viewModel, 
				IHeadHunterAnalyzerService hhService) : base(onException) {

			_viewModel = viewModel;
			_hhService = hhService;
		}

		public override async Task ExecuteAsync(object? parameter) {

			int pageNumber = 1;
			int pageSize = 10;

			var vacancies = await _hhService.GetAnalyzedVacancies(pageNumber, pageSize);

			_viewModel.Vacancies = vacancies.ToList();
		}
	}
}
