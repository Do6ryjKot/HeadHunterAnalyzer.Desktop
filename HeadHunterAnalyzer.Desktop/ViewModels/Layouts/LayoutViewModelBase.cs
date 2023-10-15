namespace HeadHunterAnalyzer.Desktop.ViewModels.Layouts {
	
	/// <summary>
	/// Базовый класс для лэйаутов.
	/// </summary>
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
