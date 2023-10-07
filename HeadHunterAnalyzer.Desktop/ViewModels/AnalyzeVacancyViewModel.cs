using Entities.Models;
using HeadHunterAnalyzer.Desktop.Commands.Sync.Navigation;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.Services.Parser;
using HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy;
using HeadHunterAnalyzer.Desktop.ViewModels.Components.KeyWords;
using System.Collections.Generic;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels {
	
	public class AnalyzeVacancyViewModel : ViewModelBase {

		private readonly IAnalyzedVacancyStore _vacancyStore;
		private readonly IKeyWordsParser _keyWordsParser;


		public int HeadHunterId => _vacancyStore.HeadHunterId;
		public string VacancyName => _vacancyStore.VacancyName;
		public string VacancyExperience => _vacancyStore.VacancyExperience;
		public string VacancyBody => _vacancyStore.VacancyBody;
		public int CompanyHeadHunterId => _vacancyStore.Company.HeadHunterId;
		public string CompanyName => _vacancyStore.Company.Name;

		public List<RecommendedKeyWordViewModel> RecommendedKeyWords { get; }


		private string _keyWords = "";
		public string KeyWords {
			get => _keyWords;
			set { 			
				_keyWords = value;
				OnPropertyChanged(nameof(KeyWords));
			}
		}


		public ICommand MainPageNavigationCommand { get; }

		public AnalyzeVacancyViewModel(INavigationService<MainPageViewModel> mainPageNavigationService, 
				IAnalyzedVacancyStore vacancyStore, 
				IKeyWordsParser keyWordsParser) {

			_keyWordsParser = keyWordsParser;

			MainPageNavigationCommand = new NavigationCommand<MainPageViewModel>(mainPageNavigationService);

			RecommendedKeyWords = new List<RecommendedKeyWordViewModel>();

			_vacancyStore = vacancyStore;

			_vacancyStore.OnVacancyLoaded += VacancyLoaded;
			UpdateKeyWordList();
		}

		private void VacancyLoaded() {

			UpdateKeyWordList();

			OnPropertyChanged(nameof(HeadHunterId));
			OnPropertyChanged(nameof(VacancyName));
			OnPropertyChanged(nameof(VacancyExperience));
			OnPropertyChanged(nameof(VacancyBody));
			OnPropertyChanged(nameof(CompanyHeadHunterId));
			OnPropertyChanged(nameof(CompanyName));
			OnPropertyChanged(nameof(RecommendedKeyWords));
		}

		private void UpdateKeyWordList() {

			RecommendedKeyWords.Clear();

			foreach (Word word in _vacancyStore.Words) {

				RecommendedKeyWords.Add(new RecommendedKeyWordViewModel(word, this, _keyWordsParser));
			}
		}
	}
}
