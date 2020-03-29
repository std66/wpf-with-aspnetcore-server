using System.Windows;
using WpfAppWithAspNetCoreServerDemo.ViewModels;

namespace WpfAppWithAspNetCoreServerDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly MainWindowViewModel viewModel;

        public MainWindow() : this(new MainWindowViewModel()) {

        }

        public MainWindow(MainWindowViewModel viewModel) {
            InitializeComponent();

            this.viewModel = viewModel;
            this.DataContext = this.viewModel;
        }
    }
}
