using HeadHunterAnalyzer.Desktop.ViewModels;

namespace HeadHunterAnalyzer.Desktop.Services.Navigation {

	public class NavigationManager : INavigationManager {

		private readonly INavigationService<MainPageViewModel> _mainPageNavigationService;
		
		public NavigationManager(INavigationService<MainPageViewModel> mainPageNavigationService) {
			_mainPageNavigationService = mainPageNavigationService;
		}

		public INavigationService<MainPageViewModel> MainPageNavigationService => _mainPageNavigationService;			
	}
}
