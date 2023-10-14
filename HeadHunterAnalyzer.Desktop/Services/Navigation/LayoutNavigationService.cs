using HeadHunterAnalyzer.Desktop.Stores.Navigation;
using HeadHunterAnalyzer.Desktop.ViewModels;
using HeadHunterAnalyzer.Desktop.ViewModels.Layouts;
using System;

namespace HeadHunterAnalyzer.Desktop.Services.Navigation {

	internal class LayoutNavigationService<TViewModel, TLayoutViewModel> : ILayoutNavigationService<TViewModel, TLayoutViewModel> 
			where TViewModel : ViewModelBase 
			where TLayoutViewModel : LayoutViewModelBase {

		private readonly Func<TLayoutViewModel> _createLayout;
		private readonly Func<TViewModel> _createViewModel;
		private readonly INavigationStore _navigationStore;

		public LayoutNavigationService(Func<TLayoutViewModel> createLayout, 
				Func<TViewModel> createViewModel, 
				INavigationStore navigationStore) {

			_createLayout = createLayout;
			_createViewModel = createViewModel;
			_navigationStore = navigationStore;
		}

		public void Navigate() {

			TLayoutViewModel layout = _createLayout();
			layout.CurrentViewModel = _createViewModel();
			_navigationStore.CurrentViewModel = layout;
		}
	}
}
