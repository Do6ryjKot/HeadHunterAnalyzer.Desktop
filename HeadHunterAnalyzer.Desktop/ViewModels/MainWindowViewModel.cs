using HeadHunterAnalyzer.Desktop.Stores.Navigation;

namespace HeadHunterAnalyzer.Desktop.ViewModels {
    
	/// <summary>
	/// Модель представления основного окна.
	/// </summary>
    public class MainWindowViewModel : ViewModelBase {

        private readonly INavigationStore _navigationStore;

		public MainWindowViewModel(INavigationStore navigationStore) {
		
			_navigationStore = navigationStore;

			_navigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
		}

		private void CurrentViewModelChanged() => OnPropertyChanged(nameof(CurrentViewModel));

		public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
	}
}
