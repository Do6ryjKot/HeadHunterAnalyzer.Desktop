using Contracts.HeadHunterAnalyzer;
using Contracts.Logger;
using HeadHunterAnalyzer.API;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.Services.Parser;
using HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy;
using HeadHunterAnalyzer.Desktop.Stores.Navigation;
using HeadHunterAnalyzer.Desktop.ViewModels;
using HeadHunterAnalyzer.Desktop.ViewModels.Layouts.MainPage;
using LoggerService;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HeadHunterAnalyzer.Desktop.Extensions.Services {
	
    public static class ServiceExtensions {

		/// <summary>
		/// Добавление логгера в пулл сервисов.
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureLoggerService(this IServiceCollection services) =>
			services.AddSingleton<ILoggerManager, LoggerManager>();

		/// <summary>
		/// Настройка моделей представления.
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureViewModels(this IServiceCollection services) {

			services.AddTransient<MainWindowViewModel>();
			// services.AddTransient<MainPageViewModel>();
			services.AddTransient<AnalyzedWordsViewModel>();
			services.AddTransient<AnalyzeVacancyViewModel>();
			services.AddTransient<MainPageNavigationLayoutViewModel>();
			services.AddTransient<MainPageNavigationLayoutViewModel>();

			// services.AddSingleton<Func<MainPageViewModel>>(s => 
			//	() => s.GetRequiredService<MainPageViewModel>());
			
			services.AddSingleton<Func<AnalyzeVacancyViewModel>>(s => 
				() => s.GetRequiredService<AnalyzeVacancyViewModel>());

			services.AddSingleton<Func<MainPageNavigationLayoutViewModel>>(s =>
				() => s.GetRequiredService<MainPageNavigationLayoutViewModel>());

			services.AddSingleton<Func<AnalyzedWordsViewModel>>(s =>
				() => s.GetRequiredService<AnalyzedWordsViewModel>());
		}

		/// <summary>
		/// Сервисы навигации между страницами.
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureNavigationServices(this IServiceCollection services) {

			// services.AddSingleton<INavigationService<MainPageViewModel>, NavigationService<MainPageViewModel>>();
			services.AddSingleton<INavigationService<AnalyzeVacancyViewModel>, NavigationService<AnalyzeVacancyViewModel>>();
			services.AddSingleton<INavigationService<AnalyzedWordsViewModel>, 
				LayoutNavigationService<AnalyzedWordsViewModel, MainPageNavigationLayoutViewModel>>();

			services.AddSingleton<INavigationManager, NavigationManager>();
		}

		/// <summary>
		/// Настройка локальных хранилищ.
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureLocalStores(this IServiceCollection services) {

			services.AddSingleton<INavigationStore, NavigationStore>();
			services.AddSingleton<IAnalyzedVacancyStore, AnalyzedVacancyStore>();
		}

		/// <summary>
		/// Настройка локальных сервисов.
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureLocalServices(this IServiceCollection services) {

			services.AddSingleton<IKeyWordsParser, KeyWordsParser>();
		}

		/// <summary>
		/// Настройка внешних сервисов.
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureExternalServices(this IServiceCollection services) {

			services.AddSingleton<IHeadHunterAnalyzerService, HeadHunterAnalyzerApiService>();
		}		

		public static void ConfigureHttpClients(this IServiceCollection services) {

			services.AddHttpClient<HeadHunterAnalyzerApiHttpClient>(c => { 
				
				c.BaseAddress = new Uri("http://localhost:5248");
			});
		}
	}
}
