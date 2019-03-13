using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OcampoElective2Project.Models;
using OcampoElective2Project.Repository;
using OcampoElective2Project.Repository.LocalRepository;

namespace OcampoElective2Project.Services.TransportationService
{
    public class MockTransportationService : ITransportationService
    {
        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OcampoElective.db3");

        private IRepository _repository;

        public MockTransportationService()
        {
            _repository = new LocalRepository();
        }

        public List<Transportation> GetTransportationUser(UserAccount transporatationUnderUser)
        {
            var transportation= _repository.Transportation.GetRange(c => c.UserId == transporatationUnderUser.AccountId);
            return transportation;
        }

        public void AddTransportation(Transportation transportation)
        {
            _repository.Transportation.Add(transportation);
        }

        public void DeleteTransportation(Transportation transportation)
        {
            _repository.Transportation.Delete(c => c.Id == transportation.Id);
        }

        public void UpdateTransportation(Transportation oldTransportation, Transportation newTransportation)
        {
            _repository.Transportation.Update(c => c.Id == oldTransportation.Id, newTransportation);
        }
    }
}
