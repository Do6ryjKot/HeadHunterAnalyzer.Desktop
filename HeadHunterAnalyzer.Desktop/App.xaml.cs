using HeadHunterAnalyzer.Desktop.Extensions.Services;
using HeadHunterAnalyzer.Desktop.Services.Navigation;
using HeadHunterAnalyzer.Desktop.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace HeadHunterAnalyzer.Desktop {

	public partial class App : Application {

		private readonly IHost _host;

		public App() {

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

				services.ConfigureLocalStores();
				services.ConfigureLocalServices();
				services.ConfigureViewModels();
				services.ConfigureNavigationServices();

				services.AddSingleton<MainWindow>(s => new MainWindow { DataContext = s.GetRequiredService<MainWindowViewModel>() });
			});
	}
}
