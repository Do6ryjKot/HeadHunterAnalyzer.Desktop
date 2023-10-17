using HeadHunterAnalyzer.Desktop.Stores.Vacancies;
using System;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Commands.Async.AnalyzedVacancies {

	/// <summary>
	/// Команда загрузки след. страницы вакансий.
	/// </summary>
	public class LoadNextVacanciesPageCommand : AsyncCommandBase {

		private readonly IVacanciesStore _vacanciesStore;

		public LoadNextVacanciesPageCommand(Action<Exception> onError, IVacanciesStore vacanciesStore) : base(onError) {
			_vacanciesStore = vacanciesStore;
		}

		public override async Task ExecuteAsync(object? parameter) {

			await _vacanciesStore.LoadNextPage();
		}
	}
}
