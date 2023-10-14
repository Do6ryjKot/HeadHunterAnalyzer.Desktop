using HeadHunterAnalyzer.Desktop.ViewModels.Components.Navigation;

namespace HeadHunterAnalyzer.Desktop.ViewModels.Layouts.MainPage {
	
	public class MainPageNavigationLayoutViewModel : LayoutViewModelBase {

		private NavigationBarViewModel _navigatioBarViewModel;

		public NavigationBarViewModel NavigationBarViewModel {
			
			get => _navigatioBarViewModel;

			set { 
			
				_navigatioBarViewModel = value;
				OnPropertyChanged(nameof(NavigationBarViewModel));
			}
		}
	}
}
