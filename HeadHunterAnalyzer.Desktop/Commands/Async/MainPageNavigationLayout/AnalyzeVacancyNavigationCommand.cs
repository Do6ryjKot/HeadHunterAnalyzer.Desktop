using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy;
using HeadHunterAnalyzer.Desktop.ViewModels.Layouts.MainPage;
using System;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Commands.Async.MainPageNavigationLayout {

	public class AnalyzeVacancyNavigationCommand : AsyncCommandBase {

		private readonly MainPageNavigationLayoutViewModel _viewModel;
		private readonly INavigationManager _navigationManager;
		private readonly IAnalyzedVacancyStore _vacancyStore;

		public AnalyzeVacancyNavigationCommand(Action<Exception> onException, MainPageNavigationLayoutViewModel viewModel, 
				INavigationManager navigationManager, IAnalyzedVacancyStore vacancyStore) : base(onException) {
			_viewModel = viewModel;
			_navigationManager = navigationManager;
			_vacancyStore = vacancyStore;
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
