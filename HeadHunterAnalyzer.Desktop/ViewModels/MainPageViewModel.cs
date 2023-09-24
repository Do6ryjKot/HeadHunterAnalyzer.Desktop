using Contracts.HeadHunterAnalyzer;
using Entities.DataTransferObjects;
using HeadHunterAnalyzer.Desktop.Commands.Async.MainPage;
using HeadHunterAnalyzer.Desktop.Commands.Sync.Navigation;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels {
    
	public class MainPageViewModel : ViewModelBase {

		private readonly IHeadHunterAnalyzerService _analyzerService;

		private readonly ICommand _loadWordsCommand;



		private List<WordStatisticsDto> _words;

		public List<WordStatisticsDto> Words {
			get => _words; 
			set { 
			
				_words = value;
				OnPropertyChanged(nameof(Words));
			}
		}



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


		public ICommand AnalyzeVacancyNavigationCommand { get; }


		public MainPageViewModel(IHeadHunterAnalyzerService analyzerService, 
			INavigationService<AnalyzeVacancyViewModel> analyzeVacancyNavigationService) {

			_analyzerService = analyzerService;
			_loadWordsCommand = new LoadWordsCommand(OnException, this, analyzerService);

			AnalyzeVacancyNavigationCommand = new NavigationCommand<AnalyzeVacancyViewModel>(analyzeVacancyNavigationService);

			_loadWordsCommand.Execute(null);
		}

		private void OnException(Exception exception) {

			Message = exception.Message;
		}
	}
}
