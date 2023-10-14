using HeadHunterAnalyzer.Desktop.Commands.Async.MainPageNavigationLayout;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy;
using HeadHunterAnalyzer.Desktop.ViewModels.Components.Navigation;
using System;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels.Layouts.MainPage {
	
	public class MainPageNavigationLayoutViewModel : LayoutViewModelBase {
		
		private int? _headHunterId;
		public int? HeadHunterId {

			get => _headHunterId;

			set => _headHunterId = value;
		}

		public NavigationBarViewModel NavigationBarViewModel { get; private set; }

		public ICommand AnalyzeVacancyNavigationCommand { get; }
		public MainPageNavigationLayoutViewModel(INavigationManager navigationManager, 
				IAnalyzedVacancyStore vacancyStore,
				Func<NavigationBarViewModel> createNavigationBarViewModel) {

			AnalyzeVacancyNavigationCommand = new AnalyzeVacancyNavigationCommand(OnException, this, navigationManager, vacancyStore);
			NavigationBarViewModel = createNavigationBarViewModel();
		}

		private void OnException(Exception exception) {
			throw new NotImplementedException();
		}
	}
}
