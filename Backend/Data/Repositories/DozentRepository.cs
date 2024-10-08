using Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Repositories
{
    public class DozentRepository
    {
        private ObservableCollection<Dozent> _dozenten;

        public DozentRepository()
        {
            _dozenten = new ObservableCollection<Dozent>();
        }

        public ObservableCollection<Dozent> GetAll()
        {
            return _dozenten;
        }

        public void Add(Dozent dozent)
        {
            _dozenten.Add(dozent);
        }

        public void Delete(Dozent dozent)
        {
            _dozenten.Remove(dozent);
        }

        public void Update(Dozent dozent)
        {
            var existingDozent = _dozenten.FirstOrDefault(d => d.ID == dozent.ID);
            if (existingDozent != null)
            {
                existingDozent.Name = dozent.Name;
                existingDozent.Fachgebiet = dozent.Fachgebiet;
            }
        }
    }
}
