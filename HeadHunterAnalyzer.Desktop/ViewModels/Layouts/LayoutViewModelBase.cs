namespace HeadHunterAnalyzer.Desktop.ViewModels.Layouts {
	
	public class LayoutViewModelBase : ViewModelBase {

		private ViewModelBase _currentViewModel;

		public ViewModelBase CurrentViewModel {

			get => _currentViewModel;

			set {

				_currentViewModel = value;
				OnPropertyChanged(nameof(CurrentViewModel));
			}
		}
	}
}
