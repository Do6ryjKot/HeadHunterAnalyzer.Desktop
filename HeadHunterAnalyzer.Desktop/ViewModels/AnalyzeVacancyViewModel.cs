using Entities.Models;
using HeadHunterAnalyzer.Desktop.Commands.Sync.Navigation;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy;
using System.Collections.Generic;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels {
	
	public class AnalyzeVacancyViewModel : ViewModelBase {

		private readonly IAnalyzedVacancyStore _vacancyStore;


		public int HeadHunterId => _vacancyStore.HeadHunterId;
		public string VacancyName => _vacancyStore.VacancyName;
		public string VacancyExperience => _vacancyStore.VacancyExperience;
		public string VacancyBody => _vacancyStore.VacancyBody;
		public int CompanyHeadHunterId => _vacancyStore.Company.HeadHunterId;
		public string CompanyName => _vacancyStore.Company.Name;
		public IEnumerable<Word> RecommendedKeyWords => _vacancyStore.Words;


		public ICommand MainPageNavigationCommand { get; }

		public AnalyzeVacancyViewModel(INavigationService<MainPageViewModel> mainPageNavigationService, IAnalyzedVacancyStore vacancyStore) {

			MainPageNavigationCommand = new NavigationCommand<MainPageViewModel>(mainPageNavigationService);

			_vacancyStore = vacancyStore;

			_vacancyStore.OnVacancyLoaded += VacancyLoaded;
		}

		private void VacancyLoaded() {

			OnPropertyChanged(nameof(HeadHunterId));
			OnPropertyChanged(nameof(VacancyName));
			OnPropertyChanged(nameof(VacancyExperience));
			OnPropertyChanged(nameof(VacancyBody));
			OnPropertyChanged(nameof(CompanyHeadHunterId));
			OnPropertyChanged(nameof(CompanyName));
			OnPropertyChanged(nameof(RecommendedKeyWords));
		}
	}
}
