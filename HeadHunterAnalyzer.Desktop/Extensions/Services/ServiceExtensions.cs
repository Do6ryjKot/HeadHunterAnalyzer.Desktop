using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.Stores.Navigation;
using HeadHunterAnalyzer.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HeadHunterAnalyzer.Desktop.Extensions.Services {
	
    public static class ServiceExtensions {

		/// <summary>
		/// Настройка моделей представления.
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureViewModels(this IServiceCollection services) {

			services.AddTransient<MainWindowViewModel>();
			services.AddTransient<MainPageViewModel>();

			services.AddSingleton<Func<MainPageViewModel>>(s => 
				() => s.GetRequiredService<MainPageViewModel>());
		}

		/// <summary>
		/// Настройка локальных хранилищ.
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureLocalStores(this IServiceCollection services) {

			services.AddSingleton<INavigationStore, NavigationStore>();
		}

		/// <summary>
		/// Настройка локальных сервисов
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureLocalServices(this IServiceCollection services) { }

		public static void ConfigureNavigationServices(this IServiceCollection services) {

			services.AddSingleton<INavigationService<MainPageViewModel>, NavigationService<MainPageViewModel>>();
			
			services.AddSingleton<INavigationManager, NavigationManager>();
		}
	}
}
