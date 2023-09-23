using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.Commands.Async {

	public abstract class AsyncCommandBase : ICommand {

		private readonly Action<Exception> _onException;

		private bool _isExecuting;

		public bool IsExecuting {
			
			get => _isExecuting;

			set { 

				_isExecuting = value;
				CanExecuteChanged?.Invoke(this, new EventArgs());
			}
		}

		public event EventHandler? CanExecuteChanged;


		public AsyncCommandBase(Action<Exception> onException) {
			_onException = onException;
		}


		public bool CanExecute(object? parameter) => !IsExecuting;

		public async void Execute(object? parameter) {

			IsExecuting = true;

			try {

				await ExecuteAsync(parameter);

			} catch (Exception ex) {

				_onException(ex);
			}

			IsExecuting = false;
		}

		public abstract Task ExecuteAsync(object? parameter);
	}
}
