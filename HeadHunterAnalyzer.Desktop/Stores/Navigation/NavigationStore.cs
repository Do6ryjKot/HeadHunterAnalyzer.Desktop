using HeadHunterAnalyzer.Desktop.ViewModels;
using System;

namespace HeadHunterAnalyzer.Desktop.Stores.Navigation {

	public class NavigationStore : INavigationStore {

		private ViewModelBase _currentViewModel;

		public ViewModelBase CurrentViewModel {
			
			get => _currentViewModel; 
			
			set { 

				_currentViewModel = value;
				OnCurrentViewModelChanged();
			}
		}

		public event Action CurrentViewModelChanged;

		private void OnCurrentViewModelChanged() => CurrentViewModelChanged?.Invoke();
	}
}
