using Contracts.HeadHunterAnalyzer;
using Entities.DataTransferObjects;
using HeadHunterAnalyzer.Desktop.Commands.Async.AnalyzedVacancies;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels {
	
	public class AnalyzedVacanciesViewModel : ViewModelBase {

		private readonly ICommand _loadVacanciesCommand;


		private List<VacancyDto> _vacancies;
		public List<VacancyDto> Vacancies {

			get => _vacancies;

			set { 

				_vacancies = value; 
				OnPropertyChanged(nameof(Vacancies));
			}
		}


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

		public AnalyzedVacanciesViewModel(IHeadHunterAnalyzerService hhService) {

			_loadVacanciesCommand = new LoadVacanciesCommand(OnException, this, hhService);

			_loadVacanciesCommand.Execute(null);
		}

		private void OnException(Exception exception) {
			
			Message = exception.Message;
		}
	}
}
