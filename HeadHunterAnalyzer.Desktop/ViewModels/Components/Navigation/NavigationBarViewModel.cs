using HeadHunterAnalyzer.Desktop.Commands.Sync.Navigation;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels.Components.Navigation {
	
	public class NavigationBarViewModel : ViewModelBase {

		public ICommand WordsAnalyticsNavigationCommand { get; }
		public ICommand AnalyzedVacanciesNavigationCommand { get; }

		public NavigationBarViewModel(INavigationManager navigationManager) {

			WordsAnalyticsNavigationCommand = new NavigationCommand<AnalyzedWordsViewModel>(navigationManager.AnalyzedWordsNavigatonService);
			AnalyzedVacanciesNavigationCommand = new NavigationCommand<AnalyzedVacanciesViewModel>(navigationManager.AnalyzedVacanciesNavigatonService);
		}
	}
}
