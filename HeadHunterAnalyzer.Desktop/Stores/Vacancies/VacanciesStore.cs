using Contracts.HeadHunterAnalyzer;
using Entities.Models;
using Entities.ResponseFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Stores.Vacancies {

	public class VacanciesStore : IVacanciesStore {

		private readonly IHeadHunterAnalyzerService _hhService;

		private PagedList<Vacancy> _pagedVacancies = new(new List<Vacancy>(), new PaginationMetadata());

		#region Pagination

		public int PageNumber => _pagedVacancies.Metadata.CurrentPage;

		public int PageSize => _pagedVacancies.Metadata.PageSize;

		public bool HasPrevious => _pagedVacancies.Metadata.HasPrevious;

		public bool HasNext => _pagedVacancies.Metadata.HasNext;

		#endregion

		public IEnumerable<Vacancy> Items => _pagedVacancies.Items;

		public event Action ItemsLoaded;

		public async Task Load(int pageNumber, int pageSize) {

			_pagedVacancies = await _hhService.GetAnalyzedVacancies(pageNumber, pageSize);

			OnItemsLoaded();
		}

		public VacanciesStore(IHeadHunterAnalyzerService hhService) {
			_hhService = hhService;
		}

		private void OnItemsLoaded() => 
			ItemsLoaded?.Invoke();
	}
}
