using HeadHunterAnalyzer.Desktop.Extensions.Services;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.IO;
using System.Windows;

namespace HeadHunterAnalyzer.Desktop {

	public partial class App : Application {

		private readonly IHost _host;

		public App() {

			LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

			_host = CreateHostBuilder().Build();
		}

		protected override void OnStartup(StartupEventArgs e) {

			_host.Start();

			_host.Services.GetRequiredService<INavigationManager>()
				.MainPageNavigationService.Navigate();

			Window window = _host.Services.GetRequiredService<MainWindow>();
			window.Show();
			
			base.OnStartup(e);
		}

		protected override async void OnExit(ExitEventArgs e) {

			await _host.StopAsync();
			_host.Dispose();

			base.OnExit(e);
		}

		private IHostBuilder CreateHostBuilder() =>
			Host.CreateDefaultBuilder().ConfigureServices((context, services) => {

				services.ConfigureLoggerService();

				services.ConfigureHttpClients();

				services.ConfigureLocalStores();
				services.ConfigureLocalServices();
				services.ConfigureExternalServices();
				services.ConfigureViewModels();
				services.ConfigureNavigationServices();

				services.AddSingleton<MainWindow>(s => new MainWindow { DataContext = s.GetRequiredService<MainWindowViewModel>() });
			});
	}
}
