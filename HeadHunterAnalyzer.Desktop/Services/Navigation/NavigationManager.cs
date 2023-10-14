using HeadHunterAnalyzer.Desktop.ViewModels;

namespace HeadHunterAnalyzer.Desktop.Services.Navigation {

	public class NavigationManager : INavigationManager {

		private readonly INavigationService<AnalyzedWordsViewModel> _mainPageNavigationService;
		private readonly INavigationService<AnalyzeVacancyViewModel> _analyzeVacancyNavigationService;
		
		public NavigationManager(INavigationService<AnalyzedWordsViewModel> mainPageNavigationService,
			INavigationService<AnalyzeVacancyViewModel> analyzeVacancyNavigationService) {

			_mainPageNavigationService = mainPageNavigationService;
			_analyzeVacancyNavigationService = analyzeVacancyNavigationService;
		}

		public INavigationService<AnalyzedWordsViewModel> MainPageNavigationService => _mainPageNavigationService;

		public INavigationService<AnalyzeVacancyViewModel> AnalyzeVacancyNavigationService => _analyzeVacancyNavigationService;
	}
}
