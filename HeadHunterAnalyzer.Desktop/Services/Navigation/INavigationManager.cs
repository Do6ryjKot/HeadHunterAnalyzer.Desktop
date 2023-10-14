using HeadHunterAnalyzer.Desktop.ViewModels;
using HeadHunterAnalyzer.Desktop.ViewModels.Layouts.MainPage;

namespace HeadHunterAnalyzer.Desktop.Services.Navigation {
	
    public interface INavigationManager {

        // public ILayoutNavigationService<MainPageViewModel, MainPageNavigationLayoutViewModel> MainPageNavigationService { get; }
        public INavigationService<AnalyzedWordsViewModel> MainPageNavigationService { get; }
        public INavigationService<AnalyzeVacancyViewModel> AnalyzeVacancyNavigationService { get; }
    }
}
