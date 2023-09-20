using HeadHunterAnalyzer.Desktop.ViewModels;
using System;

namespace HeadHunterAnalyzer.Desktop.Stores.Navigation {
	
    /// <summary>
    /// Хранит ныне отображаемую страницу.
    /// </summary>
    public interface INavigationStore {

        public ViewModelBase CurrentViewModel { get; set; }

        public event Action CurrentViewModelChanged;
    }
}
