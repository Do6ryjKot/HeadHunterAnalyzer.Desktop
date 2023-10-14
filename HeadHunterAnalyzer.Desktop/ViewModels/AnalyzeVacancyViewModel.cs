using Contracts.HeadHunterAnalyzer;
using Entities.Models;
using HeadHunterAnalyzer.Desktop.Commands.Async.AnalyzeVacancy;
using HeadHunterAnalyzer.Desktop.Commands.Sync.AnalyzeVacancy;
using HeadHunterAnalyzer.Desktop.Commands.Sync.Navigation;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.Services.Parser;
using HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy;
using HeadHunterAnalyzer.Desktop.ViewModels.Components.KeyWords;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels {
	
	public class AnalyzeVacancyViewModel : ViewModelBase {

		private readonly IAnalyzedVacancyStore _vacancyStore;
		private readonly IKeyWordsParser _keyWordsParser;
		
		#region Vacancy

		public int HeadHunterId => _vacancyStore.HeadHunterId;
		public string VacancyName => _vacancyStore.VacancyName;
		public string VacancyExperience => _vacancyStore.VacancyExperience;
		public string VacancyBody => _vacancyStore.VacancyBody;
		public int CompanyHeadHunterId => _vacancyStore.Company.HeadHunterId;
		public string CompanyName => _vacancyStore.Company.Name;

		public bool VacancyCanBeSaved => !_vacancyStore.AlreadyAnalyzed;

		#endregion

		#region KeyWords

		public ObservableCollection<RecommendedKeyWordViewModel> RecommendedKeyWords { get; }


		private string _keyWords = "";
		public string KeyWords {
			get => _keyWords;
			set {
				_keyWords = value;
				OnPropertyChanged(nameof(KeyWords));
			}
		}

		#endregion

		#region Message

		private string _message;
		public string Message {

			get => _message;

			set {
				_message = value;
				OnPropertyChanged(nameof(Message));
				OnPropertyChanged(nameof(HasMessage));
			}
		}
		public bool HasMessage => !string.IsNullOrEmpty(Message);

		#endregion

		public ICommand MainPageNavigationCommand { get; }
		public ICommand SendVacancyCommand { get; }
		public ICommand AddAllRecommendedKeyWords { get; }

		public AnalyzeVacancyViewModel(INavigationService<AnalyzedWordsViewModel> mainPageNavigationService, 
				IAnalyzedVacancyStore vacancyStore, 
				IKeyWordsParser keyWordsParser,
				IHeadHunterAnalyzerService hhService) {

			_keyWordsParser = keyWordsParser;

			MainPageNavigationCommand = new NavigationCommand<AnalyzedWordsViewModel>(mainPageNavigationService);
			SendVacancyCommand = new SendVacancyCommand(OnSendException, this, hhService, keyWordsParser, vacancyStore);
			AddAllRecommendedKeyWords = new AddAllRecommendedKeyWords(vacancyStore, this, keyWordsParser);

			RecommendedKeyWords = new ObservableCollection<RecommendedKeyWordViewModel>();

			_vacancyStore = vacancyStore;

			_vacancyStore.OnVacancyLoaded += VacancyLoaded;
			UpdateKeyWordList();
		}

		private void OnSendException(Exception exception) {

			Message = exception.Message;
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
			OnPropertyChanged(nameof(VacancyCanBeSaved));
		}

		private void UpdateKeyWordList() {

			RecommendedKeyWords.Clear();

			foreach (Word word in _vacancyStore.Words) {

				RecommendedKeyWords.Add(new RecommendedKeyWordViewModel(word, this, _keyWordsParser));
			}
		}
	}
}
