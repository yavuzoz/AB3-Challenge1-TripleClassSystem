using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Data.Models;
using Backend.Services;
using DesktopFrontend.Utilities;
using System.Collections.ObjectModel; // Add this line to use ObservableCollection
using System.Windows.Input; // Add this line to use ICommand

namespace DesktopFrontend.ViewModels
{
    public class DozentViewModel : ViewModelBase // Inherit from ViewModelBase
    {
        private readonly DozentService _dozentService; // Reference to DozentService
        private Dozent _selectedDozent; // Property for the selected Dozent

        public ObservableCollection<Dozent> Dozenten { get; set; } // List of Dozenten
        public ICommand AddDozentCommand { get; }
        public ICommand UpdateDozentCommand { get; }
        public ICommand DeleteDozentCommand { get; }

        public Dozent SelectedDozent // Property for data binding
        {
            get => _selectedDozent;
            set
            {
                _selectedDozent = value;
                OnPropertyChanged(); // Notify the UI about the property change
            }
        }

        public DozentViewModel()
        {
            _dozentService = new DozentService(); // Initialize the service
            Dozenten = _dozentService.GetAllDozenten(); // Get the list of Dozenten from the service

            // Initialize commands
            AddDozentCommand = new RelayCommand(AddDozent);
            UpdateDozentCommand = new RelayCommand(UpdateDozent, CanUpdateOrDeleteDozent);
            DeleteDozentCommand = new RelayCommand(DeleteDozent, CanUpdateOrDeleteDozent);
        }

        private void AddDozent()
        {
            // Logic for adding a new lecturer
            if (SelectedDozent != null) // Ensure the SelectedDozent is not null
            {
                _dozentService.AddDozent(new Dozent
                {
                    Name = SelectedDozent.Name,
                    Fachgebiet = SelectedDozent.Fachgebiet
                });

                Dozenten.Add(SelectedDozent); // Add the new Dozent to the collection
                SelectedDozent = null; // Clear selection after adding
            }
        }

        private void UpdateDozent()
        {
            // Logic for updating the selected lecturer
            if (SelectedDozent != null)
            {
                _dozentService.UpdateDozent(SelectedDozent);
                OnPropertyChanged(nameof(Dozenten)); // Notify the UI to update the Dozenten list
            }
        }

        private void DeleteDozent()
        {
            // Logic for deleting the selected lecturer
            if (SelectedDozent != null)
            {
                _dozentService.DeleteDozent(SelectedDozent); // Use the service to delete the Dozent
                Dozenten.Remove(SelectedDozent); // Remove the selected Dozent from the collection
                SelectedDozent = null; // Clear selection after deleting
            }
        }

        private bool CanUpdateOrDeleteDozent()
        {
            // Enable/disable Update and Delete commands based on the selection
            return SelectedDozent != null; // Command can only execute if a Dozent is selected
        }
    }
}
