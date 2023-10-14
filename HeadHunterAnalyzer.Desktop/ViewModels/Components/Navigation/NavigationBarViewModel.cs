
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels.Components.Navigation {
	
	public class NavigationBarViewModel : ViewModelBase {

		public ICommand WordsAnalyticsNavigationCommand { get; }
		public ICommand AnalyzedVacanciesNavigationCommand { get; }
	}
}
