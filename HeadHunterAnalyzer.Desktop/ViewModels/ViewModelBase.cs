﻿using System.ComponentModel;

namespace HeadHunterAnalyzer.Desktop.ViewModels {

	public abstract class ViewModelBase : INotifyPropertyChanged {

		public event PropertyChangedEventHandler? PropertyChanged;

		public void OnPropertyChanged(string propertyName) =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
