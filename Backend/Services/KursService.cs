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
    public class KursService
    {
        private readonly KursRepository _kursRepository;

        public KursService()
        {
            _kursRepository = new KursRepository();
        }

        public ObservableCollection<Kurs> GetAllKurse()
        {
            return _kursRepository.GetAll();
        }

        public void AddKurs(Kurs kurs)
        {
            _kursRepository.Add(kurs);
        }

        public void DeleteKurs(Kurs kurs)
        {
            _kursRepository.Delete(kurs);
        }

        public void UpdateKurs(Kurs kurs)
        {
            _kursRepository.Update(kurs);
        }
    }

}
