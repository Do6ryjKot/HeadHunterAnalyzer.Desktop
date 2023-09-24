﻿using System;
using System.Windows.Input;

namespace HeadHunterAnalyzer.Desktop.Commands.Sync {

	public abstract class CommandBase : ICommand {

		public event EventHandler? CanExecuteChanged;

		public virtual bool CanExecute(object? parameter) => true;

		public abstract void Execute(object? parameter);
	}
}
