using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Stores.Vacancies {

	public interface IVacanciesStore {

		public int CurrentPage { get; }

		public int PageSize { get; }

		public int TotalPages { get; }

		public bool HasPrevious { get; }

		public bool HasNext { get; }

		public IEnumerable<Vacancy> Items { get; }

		public Task Load();

		public Task LoadNextPage();

		public Task LoadPreviousPage();


		public event Action ItemsLoaded;
	}
}
