using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy {
	
	public interface IAnalyzedVacancyStore {

		public int HeadHunterId { get; set; }

		public string VacancyName { get; }
		public string VacancyExperience { get; }
		public string VacancyBody { get; }

		public AnalyzedCompany Company { get; }

		public bool AlreadyAnalyzed { get; }

		public IEnumerable<Word> Words { get; }
		
		public event Action OnVacancyLoaded;


		public Task LoadVacancy(int headHunterId);
	}
}
