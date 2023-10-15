using HeadHunterAnalyzer.Desktop.Commands.Async.MainPageNavigationLayout;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy;
using HeadHunterAnalyzer.Desktop.ViewModels.Components.Navigation;
using System;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels.Layouts.MainPage {
	
	/// <summary>
	/// Лэйаут навигации на главной странице приложения.
	/// </summary>
	public class MainPageNavigationLayoutViewModel : LayoutViewModelBase {
		
		private int? _headHunterId;
		public int? HeadHunterId {

			get => _headHunterId;

			set => _headHunterId = value;
		}

		public NavigationBarViewModel NavigationBarViewModel { get; }

		#region Message

		private string _message;
		public string Message {

			get => _message;

			set {

				_message = value;
				OnPropertyChanged(nameof(Message));
				OnPropertyChanged(nameof(HasMessage));
			}
		}

		public bool HasMessage => !string.IsNullOrEmpty(Message);

		#endregion

		public ICommand AnalyzeVacancyNavigationCommand { get; }
		public MainPageNavigationLayoutViewModel(INavigationManager navigationManager, 
				IAnalyzedVacancyStore vacancyStore,
				Func<NavigationBarViewModel> createNavigationBarViewModel) {

			AnalyzeVacancyNavigationCommand = new AnalyzeVacancyNavigationCommand(OnException, this, navigationManager, vacancyStore);
			NavigationBarViewModel = createNavigationBarViewModel();
		}

		private void OnException(Exception exception) => 
			Message = exception.Message;
	}
}
