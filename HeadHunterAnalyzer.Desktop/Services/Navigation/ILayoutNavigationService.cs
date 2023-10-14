using HeadHunterAnalyzer.Desktop.ViewModels;
using HeadHunterAnalyzer.Desktop.ViewModels.Layouts;

namespace HeadHunterAnalyzer.Desktop.Services.Navigation {
	
	public interface ILayoutNavigationService<TViewModel, TLayoutViewModel> : INavigationService<TViewModel> 
			where TViewModel : ViewModelBase
			where TLayoutViewModel : LayoutViewModelBase {
	}
}
