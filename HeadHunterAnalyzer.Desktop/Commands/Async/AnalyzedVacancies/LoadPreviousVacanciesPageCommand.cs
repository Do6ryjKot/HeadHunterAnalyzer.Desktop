using HeadHunterAnalyzer.Desktop.Stores.Vacancies;
using System;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Commands.Async.AnalyzedVacancies {

	/// <summary>
	/// Команда загрузки пред. страницы вакансий.
	/// </summary>
	public class LoadPreviousVacanciesPageCommand : AsyncCommandBase {

		private readonly IVacanciesStore _vacanciesStore;

		public LoadPreviousVacanciesPageCommand(Action<Exception> onError, IVacanciesStore vacanciesStore) : base(onError) {
			_vacanciesStore = vacanciesStore;
		}

		public override async Task ExecuteAsync(object? parameter) {

			await _vacanciesStore.LoadPreviousPage();
		}
	}
}
