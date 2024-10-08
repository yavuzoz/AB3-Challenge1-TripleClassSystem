using Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Repositories
{
    public class KursRepository
    {
        private ObservableCollection<Kurs> _kurse;

        public KursRepository()
        {
            _kurse = new ObservableCollection<Kurs>();
        }

        public ObservableCollection<Kurs> GetAll()
        {
            return _kurse;
        }

        public void Add(Kurs kurs)
        {
            _kurse.Add(kurs);
        }

        public void Delete(Kurs kurs)
        {
            _kurse.Remove(kurs);
        }

        public void Update(Kurs kurs)
        {
            var existingKurs = _kurse.FirstOrDefault(k => k.ID == kurs.ID);
            if (existingKurs != null)
            {
                existingKurs.Name = kurs.Name;
                existingKurs.DozentID = kurs.DozentID;
            }
        }
    }
}
