using HeadHunterAnalyzer.Desktop.ViewModels;

namespace HeadHunterAnalyzer.Desktop.Services.Navigation {

	public class NavigationManager : INavigationManager {

		private readonly INavigationService<MainPageViewModel> _mainPageNavigationService;
		private readonly INavigationService<AnalyzeVacancyViewModel> _analyzeVacancyNavigationService;
		
		public NavigationManager(INavigationService<MainPageViewModel> mainPageNavigationService,
			INavigationService<AnalyzeVacancyViewModel> analyzeVacancyNavigationService) {

			_mainPageNavigationService = mainPageNavigationService;
			_analyzeVacancyNavigationService = analyzeVacancyNavigationService;
		}

		public INavigationService<MainPageViewModel> MainPageNavigationService => _mainPageNavigationService;

		public INavigationService<AnalyzeVacancyViewModel> AnalyzeVacancyNavigationService => _analyzeVacancyNavigationService;
	}
}
