using Contracts.Logger;
using HeadHunterAnalyzer.Desktop.Stores.Navigation;
using HeadHunterAnalyzer.Desktop.ViewModels;
using System;

namespace HeadHunterAnalyzer.Desktop.Services.Navigation {

	public class NavigationService<T> : INavigationService<T> where T : ViewModelBase {

		private readonly Func<T> _createViewModel;
		private readonly INavigationStore _navigationStore;

		private readonly ILoggerManager _logger;

		public NavigationService(Func<T> createViewModel, INavigationStore navigationStore, ILoggerManager logger) {
			_createViewModel = createViewModel;
			_navigationStore = navigationStore;
			_logger = logger;
		}

		public void Navigate() {

			_navigationStore.CurrentViewModel = _createViewModel();

			_logger.LogInformation($"Navigated to {typeof(T)}");
		}
	}
}
