using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy;
using HeadHunterAnalyzer.Desktop.ViewModels;
using System;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Commands.Async.MainPage {

	public class AnalyzeVacancyNavigationCommand : AsyncCommandBase {

		private readonly MainPageViewModel _viewModel;
		private readonly INavigationManager _navigationManager;
		private readonly IAnalyzedVacancyStore _vacancyStore;

		public AnalyzeVacancyNavigationCommand(Action<Exception> OnException, 
				MainPageViewModel viewModel, INavigationManager navigationManager, IAnalyzedVacancyStore vacancyStore) : base(OnException) {

			_navigationManager = navigationManager;
			_vacancyStore = vacancyStore;
			_viewModel = viewModel;
		}

		public async override Task ExecuteAsync(object? parameter) {

			if (_viewModel.HeadHunterId == null) {

				throw new Exception("Введите ид вакансии");
			}

			await _vacancyStore.LoadVacancy((int)_viewModel.HeadHunterId);

			_navigationManager.AnalyzeVacancyNavigationService.Navigate();
		}
	}
}
