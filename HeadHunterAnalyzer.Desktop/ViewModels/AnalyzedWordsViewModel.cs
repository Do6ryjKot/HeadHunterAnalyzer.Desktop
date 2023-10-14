using Contracts.HeadHunterAnalyzer;
using Entities.DataTransferObjects;
using HeadHunterAnalyzer.Desktop.Commands.Async.AnalyzedWords;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels {
	
	public class AnalyzedWordsViewModel : ViewModelBase {

		private readonly ICommand _loadWordsCommand;

		#region Words

		private List<WordStatisticsDto> _words;

		public List<WordStatisticsDto> Words {

			get => _words;

			set {

				_words = value;
				OnPropertyChanged(nameof(Words));
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

		public AnalyzedWordsViewModel(IHeadHunterAnalyzerService analyzerService) {

			_loadWordsCommand = new LoadWordsCommand(OnException, this, analyzerService);

			_loadWordsCommand.Execute(null);
		}

		private void OnException(Exception exception) {

			Message = exception.Message;
		}
	}
}
