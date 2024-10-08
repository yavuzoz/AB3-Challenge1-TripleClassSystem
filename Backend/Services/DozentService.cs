using Backend.Data.Models;
using Backend.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class DozentService
    {
        private readonly DozentRepository _dozentRepository;

        public DozentService()
        {
            _dozentRepository = new DozentRepository();
        }

        public ObservableCollection<Dozent> GetAllDozenten()
        {
            return _dozentRepository.GetAll();
        }

        public void AddDozent(Dozent dozent)
        {
            _dozentRepository.Add(dozent);
        }

        public void DeleteDozent(Dozent dozent)
        {
            _dozentRepository.Delete(dozent);
        }

        public void UpdateDozent(Dozent dozent)
        {
            _dozentRepository.Update(dozent);
        }
    }

}
