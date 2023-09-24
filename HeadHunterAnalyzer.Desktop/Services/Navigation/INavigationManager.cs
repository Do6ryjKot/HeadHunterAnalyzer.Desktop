using HeadHunterAnalyzer.Desktop.ViewModels;

namespace HeadHunterAnalyzer.Desktop.Services.Navigation {
	
    public interface INavigationManager {

        public INavigationService<MainPageViewModel> MainPageNavigationService { get; }
        public INavigationService<AnalyzeVacancyViewModel> AnalyzeVacancyNavigationService { get; }
    }
}
