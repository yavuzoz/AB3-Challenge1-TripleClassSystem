using System.Collections.ObjectModel; // For ObservableCollection
using System.Windows.Input; // For ICommand
using Backend.Data.Models; // For Studierende model
using Backend.Services; // For StudierendeService
using DesktopFrontend.Utilities; // For ViewModelBase

namespace DesktopFrontend.ViewModels
{
    internal class StudierendeViewModel : ViewModelBase // Inherit from ViewModelBase
    {
        private readonly StudierendeService _studierendeService; // Reference to StudierendeService
        private Studierende _selectedStudierende; // Property for the selected Studierende

        public ObservableCollection<Studierende> Studierende { get; set; } // List of Studierende
        public ICommand AddStudierendeCommand { get; }
        public ICommand UpdateStudierendeCommand { get; }
        public ICommand DeleteStudierendeCommand { get; }

        public Studierende SelectedStudierende // Property for data binding
        {
            get => _selectedStudierende;
            set
            {
                _selectedStudierende = value;
                OnPropertyChanged(); // Notify the UI about the property change
            }
        }

        public StudierendeViewModel()
        {
            _studierendeService = new StudierendeService(); // Initialize the service
            Studierende = _studierendeService.GetAllStudierende(); // Get the list of Studierende from the service

            // Initialize commands
            AddStudierendeCommand = new RelayCommand(AddStudierende);
            UpdateStudierendeCommand = new RelayCommand(UpdateStudierende, CanUpdateOrDeleteStudierende);
            DeleteStudierendeCommand = new RelayCommand(DeleteStudierende, CanUpdateOrDeleteStudierende);
        }

        private void AddStudierende()
        {
            // Logic for adding a new Studierende
            if (SelectedStudierende != null) // Ensure the SelectedStudierende is not null
            {
                var newStudierende = new Studierende
                {
                    Name = SelectedStudierende.Name,
                    // Add any other required properties here
                };

                _studierendeService.AddStudierende(newStudierende); // Use the service to add the Studierende
                Studierende.Add(newStudierende); // Add the new Studierende to the collection
                SelectedStudierende = null; // Clear selection after adding
            }
        }

        private void UpdateStudierende()
        {
            // Logic for updating the selected Studierende
            if (SelectedStudierende != null)
            {
                _studierendeService.UpdateStudierende(SelectedStudierende); // Use the service to update the Studierende
                OnPropertyChanged(nameof(Studierende)); // Notify the UI to update the Studierende list
            }
        }

        private void DeleteStudierende()
        {
            // Logic for deleting the selected Studierende
            if (SelectedStudierende != null)
            {
                _studierendeService.DeleteStudierende(SelectedStudierende); // Use the service to delete the Studierende
                Studierende.Remove(SelectedStudierende); // Remove the selected Studierende from the collection
                SelectedStudierende = null; // Clear selection after deleting
            }
        }

        private bool CanUpdateOrDeleteStudierende()
        {
            // Enable/disable Update and Delete commands based on the selection
            return SelectedStudierende != null; // Command can only execute if a Studierende is selected
        }
    }
}
