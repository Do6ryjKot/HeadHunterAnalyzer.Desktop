using HeadHunterAnalyzer.Desktop.ViewModels;

namespace HeadHunterAnalyzer.Desktop.Services.Navigation {
	
    /// <summary>
    /// Сервис перехода на другую страницу.
    /// </summary>
    /// <typeparam name="T">Модель представления страницы на которую нужно перейти.</typeparam>
    public interface INavigationService<T> where T : ViewModelBase {

        public void Navigate();
    }
}
