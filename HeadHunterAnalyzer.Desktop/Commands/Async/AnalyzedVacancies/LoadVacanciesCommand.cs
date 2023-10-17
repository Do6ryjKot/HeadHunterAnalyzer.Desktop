﻿using HeadHunterAnalyzer.Desktop.Stores.Vacancies;
using System;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Commands.Async.AnalyzedVacancies {

	/// <summary>
	/// Команда загрузки вакансий на странице анализировнаных вакансий.
	/// </summary>
	public class LoadVacanciesCommand : AsyncCommandBase {

		private readonly IVacanciesStore _vacanciesStore;

		public LoadVacanciesCommand(Action<Exception> onException, 
				IVacanciesStore vacanciesStore) : base(onException) {

			_vacanciesStore = vacanciesStore;
		}

		public override async Task ExecuteAsync(object? parameter) {

			await _vacanciesStore.Load();
		}
	}
}
