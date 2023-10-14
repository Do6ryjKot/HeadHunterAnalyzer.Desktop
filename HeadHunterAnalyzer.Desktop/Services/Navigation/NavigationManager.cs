using HeadHunterAnalyzer.Desktop.ViewModels;

namespace HeadHunterAnalyzer.Desktop.Services.Navigation {

	public class NavigationManager : INavigationManager {

		private readonly INavigationService<AnalyzedWordsViewModel> _analyzedWordsNavigationService;
		private readonly INavigationService<AnalyzedVacanciesViewModel> _analyzedVacanciesNavigationService;

		private readonly INavigationService<AnalyzeVacancyViewModel> _analyzeVacancyNavigationService;

		public NavigationManager(INavigationService<AnalyzedWordsViewModel> analyzedWordsNavigationService, 
				INavigationService<AnalyzedVacanciesViewModel> analyzedVacanciesNavigationService, 
				INavigationService<AnalyzeVacancyViewModel> analyzeVacancyNavigationService) {

			_analyzedWordsNavigationService = analyzedWordsNavigationService;
			_analyzedVacanciesNavigationService = analyzedVacanciesNavigationService;
			_analyzeVacancyNavigationService = analyzeVacancyNavigationService;
		}

		public INavigationService<AnalyzedWordsViewModel> AnalyzedWordsNavigatonService => _analyzedWordsNavigationService;

		public INavigationService<AnalyzeVacancyViewModel> AnalyzeVacancyNavigationService => _analyzeVacancyNavigationService;

		public INavigationService<AnalyzedVacanciesViewModel> AnalyzedVacanciesNavigatonService => _analyzedVacanciesNavigationService;
	}
}
