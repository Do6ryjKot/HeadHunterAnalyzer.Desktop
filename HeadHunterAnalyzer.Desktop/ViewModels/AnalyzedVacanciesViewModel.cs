using Entities.Models;
using HeadHunterAnalyzer.Desktop.Commands.Async.AnalyzedVacancies;
using HeadHunterAnalyzer.Desktop.Stores.Vacancies;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels {
	
	public class AnalyzedVacanciesViewModel : ViewModelBase {

		private readonly IVacanciesStore _vacanciesStore;

		private readonly ICommand _loadVacanciesCommand;

		public IEnumerable<Vacancy> Vacancies => _vacanciesStore.Items;


		#region Pagination

		public bool HasNext => _vacanciesStore.HasNext;
		public bool HasPrevious => _vacanciesStore.HasPrevious;

		public int CurrentPage {

			get => _vacanciesStore.PageNumber;

			set { 
				
				_loadVacanciesCommand.Execute(null);
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

		public AnalyzedVacanciesViewModel(IVacanciesStore vacanciesStore) {

			_vacanciesStore = vacanciesStore;

			_loadVacanciesCommand = new LoadVacanciesCommand(OnException, _vacanciesStore);

			_vacanciesStore.ItemsLoaded += OnItemsLoaded;

			_loadVacanciesCommand.Execute(null);			
		}

		private void OnItemsLoaded() {
			
			OnPropertyChanged(nameof(Vacancies));
			OnPropertyChanged(nameof(HasNext));
			OnPropertyChanged(nameof(HasPrevious));
		}

		private void OnException(Exception exception) {
			
			Message = exception.Message;
		}
	}
}
