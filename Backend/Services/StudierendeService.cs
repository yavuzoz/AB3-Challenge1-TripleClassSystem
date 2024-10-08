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
    public class StudierendeService
    {
        private readonly StudierendeRepository _studierendeRepository;

        public StudierendeService()
        {
            _studierendeRepository = new StudierendeRepository();
        }

        public ObservableCollection<Studierende> GetAllStudierende()
        {
            return _studierendeRepository.GetAll();
        }

        public void AddStudierende(Studierende studierende)
        {
            _studierendeRepository.Add(studierende);
        }

        public void DeleteStudierende(Studierende studierende)
        {
            _studierendeRepository.Delete(studierende);
        }

        public void UpdateStudierende(Studierende studierende)
        {
            _studierendeRepository.Update(studierende);
        }
    }

}
