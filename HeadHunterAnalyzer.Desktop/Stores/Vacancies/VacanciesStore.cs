using Entities.Models;
using System;
using System.Collections.Generic;

namespace HeadHunterAnalyzer.Desktop.Stores.Vacancies {

	public class VacanciesStore : IVacanciesStore {

		public int PageNumber { get; private set; }

		public int PageSize { get; private set; }

		public bool HasPrevious { get; private set; }

		public bool HasNext { get; private set; }

		public IEnumerable<Vacancy> Items { get; private set; }

		public event Action ItemsLoaded;

		public void Load(int pageNumber, int pageSize) {

			// 

			OnItemsLoaded();
		}

		private void OnItemsLoaded() => 
			ItemsLoaded?.Invoke();
	}
}
