using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Data.Models;  
using DesktopFrontend.Utilities;
using System.Windows.Input;
using Backend.Services;
using System.Collections.ObjectModel;

namespace DesktopFrontend.ViewModels
{
    internal class KursViewModel : ViewModelBase // Inherit from ViewModelBase
    {
        private readonly KursService _kursService; // Reference to KursService
        private Kurs _selectedKurs; // Property for the selected Kurs

        public ObservableCollection<Kurs> Kurse { get; set; } // List of Kurse
        public ICommand AddKursCommand { get; }
        public ICommand UpdateKursCommand { get; }
        public ICommand DeleteKursCommand { get; }

        public Kurs SelectedKurs // Property for data binding
        {
            get => _selectedKurs;
            set
            {
                _selectedKurs = value;
                OnPropertyChanged(); // Notify the UI about the property change
            }
        }

        public KursViewModel()
        {
            _kursService = new KursService(); // Initialize the service
            Kurse = _kursService.GetAllKurse(); // Get the list of Kurse from the service

            // Initialize commands
            AddKursCommand = new RelayCommand(AddKurs);
            UpdateKursCommand = new RelayCommand(UpdateKurs, CanUpdateOrDeleteKurs);
            DeleteKursCommand = new RelayCommand(DeleteKurs, CanUpdateOrDeleteKurs);
        }

        private void AddKurs()
        {
            // Logic for adding a new Kurs
            if (SelectedKurs != null) // Ensure the SelectedKurs is not null
            {
                var newKurs = new Kurs
                {
                    Name = SelectedKurs.Name,
                    DozentID = SelectedKurs.DozentID // Assuming DozentID is a required field
                };

                _kursService.AddKurs(newKurs); // Use the service to add the Kurs
                Kurse.Add(newKurs); // Add the new Kurs to the collection
                SelectedKurs = null; // Clear selection after adding
            }
        }

        private void UpdateKurs()
        {
            // Logic for updating the selected Kurs
            if (SelectedKurs != null)
            {
                _kursService.UpdateKurs(SelectedKurs); // Use the service to update the Kurs
                OnPropertyChanged(nameof(Kurse)); // Notify the UI to update the Kurse list
            }
        }

        private void DeleteKurs()
        {
            // Logic for deleting the selected Kurs
            if (SelectedKurs != null)
            {
                _kursService.DeleteKurs(SelectedKurs); // Use the service to delete the Kurs
                Kurse.Remove(SelectedKurs); // Remove the selected Kurs from the collection
                SelectedKurs = null; // Clear selection after deleting
            }
        }

        private bool CanUpdateOrDeleteKurs()
        {
            // Enable/disable Update and Delete commands based on the selection
            return SelectedKurs != null; // Command can only execute if a Kurs is selected
        }
    }
}