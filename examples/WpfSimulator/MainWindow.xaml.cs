using System.ComponentModel;
using System.Windows;
using WpfSimulator.Services;
using WpfSimulator.ViewModels;

namespace WpfSimulator
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel(new SimulatedInspectionService());
            DataContext = _viewModel;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _viewModel.Stop();
            base.OnClosing(e);
        }
    }
}
