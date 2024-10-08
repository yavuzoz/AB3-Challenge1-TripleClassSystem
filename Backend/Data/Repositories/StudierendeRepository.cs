using Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Repositories
{
    public class StudierendeRepository
    {
        private ObservableCollection<Studierende> _studierende;

        public StudierendeRepository()
        {
            _studierende = new ObservableCollection<Studierende>();
        }

        public ObservableCollection<Studierende> GetAll()
        {
            return _studierende;
        }

        public void Add(Studierende studierende)
        {
            _studierende.Add(studierende);
        }

        public void Delete(Studierende studierende)
        {
            _studierende.Remove(studierende);
        }

        public void Update(Studierende studierende)
        {
            var existingStudierende = _studierende.FirstOrDefault(s => s.ID == studierende.ID);
            if (existingStudierende != null)
            {
                existingStudierende.Name = studierende.Name;
                existingStudierende.KursID = studierende.KursID;
            }
        }
    }
}
