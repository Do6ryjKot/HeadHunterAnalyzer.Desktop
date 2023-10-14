using HeadHunterAnalyzer.Desktop.ViewModels;

namespace HeadHunterAnalyzer.Desktop.Services.Navigation {
	
    public interface INavigationManager {

        public INavigationService<AnalyzedWordsViewModel> AnalyzedWordsNavigatonService { get; }
        public INavigationService<AnalyzedVacanciesViewModel> AnalyzedVacanciesNavigatonService { get; }
        public INavigationService<AnalyzeVacancyViewModel> AnalyzeVacancyNavigationService { get; }
    }
}
