using HeadHunterAnalyzer.Desktop.Commands.Async.MainPageNavigationLayout;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy;
using HeadHunterAnalyzer.Desktop.ViewModels.Components.Navigation;
using System;
using System.Windows.Input;

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

		private int? _headHunterId;
		public int? HeadHunterId {

			get => _headHunterId;

			set => _headHunterId = value;
		}

		public ICommand AnalyzeVacancyNavigationCommand { get; }
		public MainPageNavigationLayoutViewModel(INavigationManager navigationManager, IAnalyzedVacancyStore vacancyStore) {

			AnalyzeVacancyNavigationCommand = new AnalyzeVacancyNavigationCommand(OnException, this, navigationManager, vacancyStore);
		}

		private void OnException(Exception exception) {
			throw new NotImplementedException();
		}
	}
}
