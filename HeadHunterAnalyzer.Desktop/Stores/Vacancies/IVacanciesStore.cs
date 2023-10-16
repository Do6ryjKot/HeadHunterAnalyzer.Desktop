using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Stores.Vacancies {

	public interface IVacanciesStore {

		public int PageNumber { get; }

		public int PageSize { get; }

		public bool HasPrevious { get; }
		public bool HasNext { get; }

		public IEnumerable<Vacancy> Items { get; }

		public Task Load(int pageNumber, int pageSize);

		public event Action ItemsLoaded;
	}
}
