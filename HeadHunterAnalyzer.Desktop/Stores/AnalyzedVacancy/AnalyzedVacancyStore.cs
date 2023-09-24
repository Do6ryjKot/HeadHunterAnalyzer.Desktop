using Contracts.HeadHunterAnalyzer;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy {

	/// <summary>
	/// Хранилище данных анализированной вакансии.
	/// </summary>
	public class AnalyzedVacancyStore : IAnalyzedVacancyStore {

		private readonly IHeadHunterAnalyzerService _hhService;

		private Entities.Models.AnalyzedVacancy _vacancyData;

		private int _headHunterId;
		public int HeadHunterId {

			get => _headHunterId;

			set => _headHunterId = value;
		}

		public string VacancyName => _vacancyData.Name;

		public string VacancyExperience => _vacancyData.Experience;

		public string VacancyBody => _vacancyData.Body;

		public AnalyzedCompany Company => _vacancyData.Company;

		public bool AlreadyAnalyzed => _vacancyData.AlreadyAnalyzed;

		public IEnumerable<Word> Words => _vacancyData.Words;

		public event Action OnVacancyLoaded;

		public AnalyzedVacancyStore(IHeadHunterAnalyzerService hhService) {
			_hhService = hhService;
		}		

		public async Task LoadVacancy(int headHunterId) {

			HeadHunterId = headHunterId;

			_vacancyData = await _hhService.AnalyzeVacancy(HeadHunterId);
		}
	}
}
