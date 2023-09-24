using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.ViewModels;

namespace HeadHunterAnalyzer.Desktop.Commands.Sync.Navigation {

	/// <summary>
	/// Команда навигации на другую страницу.
	/// </summary>
	/// <typeparam name="T">Модель представления страницы, на которую нужно переходить.</typeparam>
	public class NavigationCommand<T> : CommandBase where T : ViewModelBase {

		private readonly INavigationService<T> _navigationService;

		public NavigationCommand(INavigationService<T> navigationService) {
			_navigationService = navigationService;
		}

		public override void Execute(object? parameter) {

			_navigationService.Navigate();
		}
	}
}
