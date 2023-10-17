using Contracts.HeadHunterAnalyzer;
using Entities.Models;
using Entities.ResponseFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Stores.Vacancies {

	public class VacanciesStore : IVacanciesStore {

		private readonly IHeadHunterAnalyzerService _hhService;

		private PagedList<Vacancy> _pagedVacancies = new(new List<Vacancy>(), new PaginationMetadata() { TotalPages = 0 });

		#region Pagination

		private int _currentPage = 1;
		public int CurrentPage {

			get => _currentPage;

			set => _currentPage = value;
		}


		private int _pageSize = 10;
		public int PageSize {

			get => _pageSize;

			set => _pageSize = value;
		}

		public int TotalPages => _pagedVacancies.Metadata.TotalPages;

		public bool HasPrevious => _pagedVacancies.Metadata.HasPrevious;

		public bool HasNext => _pagedVacancies.Metadata.HasNext;

		#endregion

		public IEnumerable<Vacancy> Items => _pagedVacancies.Items;

		public event Action ItemsLoaded;
					

		public VacanciesStore(IHeadHunterAnalyzerService hhService) {
			_hhService = hhService;
		}

		private void OnItemsLoaded() => 
			ItemsLoaded?.Invoke();

		public async Task Load() {

			_pagedVacancies = await _hhService.GetAnalyzedVacancies(CurrentPage, PageSize);

			CurrentPage = _pagedVacancies.Metadata.CurrentPage;
			PageSize = _pagedVacancies.Metadata.PageSize;

			OnItemsLoaded();
		}

		public async Task LoadNextPage() {

			if (!HasNext)
				return;

			_pagedVacancies = await _hhService.GetAnalyzedVacancies(CurrentPage + 1, PageSize);

			CurrentPage = _pagedVacancies.Metadata.CurrentPage;
			PageSize = _pagedVacancies.Metadata.PageSize;

			OnItemsLoaded();
		}

		public async Task LoadPreviousPage() {

			if (!HasPrevious)
				return;

			_pagedVacancies = await _hhService.GetAnalyzedVacancies(CurrentPage - 1, PageSize);

			CurrentPage = _pagedVacancies.Metadata.CurrentPage;
			PageSize = _pagedVacancies.Metadata.PageSize;

			OnItemsLoaded();
		}
	}
}
