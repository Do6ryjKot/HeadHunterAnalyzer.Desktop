using Entities.Models;
using HeadHunterAnalyzer.Desktop.Commands.Sync.Navigation;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using System.Collections.Generic;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.ViewModels {
	
	public class AnalyzeVacancyViewModel : ViewModelBase {

		public List<Word> RecommendedKeyWords { get; }

		public ICommand MainPageNavigationCommand { get; }

		public AnalyzeVacancyViewModel(INavigationService<MainPageViewModel> mainPageNavigationService) {

			MainPageNavigationCommand = new NavigationCommand<MainPageViewModel>(mainPageNavigationService);

			RecommendedKeyWords = new List<Word> { 
				
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
				new Word { Value = "dasdasdasdsadsadsad" },
			};
		}
	}
}
