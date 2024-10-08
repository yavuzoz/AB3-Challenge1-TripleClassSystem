using System.Windows.Input;
using DesktopFrontend.Utilities;

namespace DesktopFrontend.ViewModels
{
    public class MainViewModel : ViewModelBase // Inherit from ViewModelBase
    {
        private object _currentViewModel;

        public object CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(); // Notify about property change
            }
        }

        // Commands for navigating between views
        public ICommand ShowKursCommand { get; }
        public ICommand ShowDozentCommand { get; }
        public ICommand ShowStudierendeCommand { get; }

        public MainViewModel()
        {
            ShowKursCommand = new RelayCommand(ShowKurs);
            ShowDozentCommand = new RelayCommand(ShowDozent);
            ShowStudierendeCommand = new RelayCommand(ShowStudierende);

            // Set the initial view
            CurrentViewModel = new KursViewModel();
        }

        private void ShowKurs()
        {
            CurrentViewModel = new KursViewModel(); // Navigate to KursViewModel
        }

        private void ShowDozent()
        {
            CurrentViewModel = new DozentViewModel(); // Navigate to DozentViewModel
        }

        private void ShowStudierende()
        {
            CurrentViewModel = new StudierendeViewModel(); // Navigate to StudierendeViewModel
        }
    }
}
