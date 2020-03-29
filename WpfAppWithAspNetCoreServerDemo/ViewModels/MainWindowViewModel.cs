using System.ComponentModel;

namespace WpfAppWithAspNetCoreServerDemo.ViewModels {
	public class MainWindowViewModel : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		private string text = "Change this text by invoking\nlocalhost:5000/setText/?text=newText";

		public string Text {
			get { return text; }
			set {
				bool changed = text != value;
				text = value;

				if (changed) 
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
			}
		}

	}
}
