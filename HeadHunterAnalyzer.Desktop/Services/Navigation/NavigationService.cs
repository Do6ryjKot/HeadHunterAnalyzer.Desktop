using HeadHunterAnalyzer.Desktop.Stores.Navigation;
using HeadHunterAnalyzer.Desktop.ViewModels;
using System;

namespace HeadHunterAnalyzer.Desktop.Services.Navigation {

	public class NavigationService<T> : INavigationService<T> where T : ViewModelBase {

		private readonly Func<T> _createViewModel;
		private readonly INavigationStore _navigationStore;

		public NavigationService(Func<T> createViewModel, INavigationStore navigationStore) {
			_createViewModel = createViewModel;
			_navigationStore = navigationStore;
		}

		public void Navigate() {

			_navigationStore.CurrentViewModel = _createViewModel();
		}
	}
}
