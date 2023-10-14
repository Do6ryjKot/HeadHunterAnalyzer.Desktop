using Contracts.HeadHunterAnalyzer;
using Contracts.Logger;
using HeadHunterAnalyzer.API;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.Services.Parser;
using HeadHunterAnalyzer.Desktop.Stores.AnalyzedVacancy;
using HeadHunterAnalyzer.Desktop.Stores.Navigation;
using HeadHunterAnalyzer.Desktop.ViewModels;
using HeadHunterAnalyzer.Desktop.ViewModels.Components.Navigation;
using HeadHunterAnalyzer.Desktop.ViewModels.Layouts.MainPage;
using HeadHunterAnalyzer.Desktop.Views.Components;
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

		public static void ConfigureViewsViewModels(this IServiceCollection services) {
						
			services.AddTransient<AnalyzedWordsViewModel>();
			services.AddTransient<AnalyzedVacanciesViewModel>();
			services.AddTransient<AnalyzeVacancyViewModel>();


			services.AddSingleton<Func<AnalyzedWordsViewModel>>(s =>
				() => s.GetRequiredService<AnalyzedWordsViewModel>());

			services.AddSingleton<Func<AnalyzedVacanciesViewModel>>(s =>
				() => s.GetRequiredService<AnalyzedVacanciesViewModel>());

			services.AddSingleton<Func<AnalyzeVacancyViewModel>>(s =>
				() => s.GetRequiredService<AnalyzeVacancyViewModel>());
		}

		/// <summary>
		/// Настройка моделей представления.
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureViewModels(this IServiceCollection services) {

			// Window
			services.AddTransient<MainWindowViewModel>();

			// Components
			services.AddTransient<NavigationBarViewModel>();

			services.ConfigureViewsViewModels();

			// Layout
			services.AddTransient<MainPageNavigationLayoutViewModel>();


			services.AddSingleton<Func<NavigationBarViewModel>>(s =>
				() => s.GetRequiredService<NavigationBarViewModel>());

			services.AddSingleton<Func<MainPageNavigationLayoutViewModel>>(s =>
				() => s.GetRequiredService<MainPageNavigationLayoutViewModel>());			
		}

		/// <summary>
		/// Сервисы навигации между страницами.
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureNavigationServices(this IServiceCollection services) {

			services.AddSingleton<INavigationService<AnalyzeVacancyViewModel>, NavigationService<AnalyzeVacancyViewModel>>();
			services.AddSingleton<INavigationService<AnalyzedWordsViewModel>, 
				LayoutNavigationService<AnalyzedWordsViewModel, MainPageNavigationLayoutViewModel>>();
			services.AddSingleton<INavigationService<AnalyzedVacanciesViewModel>,
				LayoutNavigationService<AnalyzedVacanciesViewModel, MainPageNavigationLayoutViewModel>>();

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
