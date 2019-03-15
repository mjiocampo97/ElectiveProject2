using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;
using OcampoElective2Project.Repository;
using OcampoElective2Project.Repository.LocalRepository;

namespace OcampoElective2Project.Services.RegisterService
{
    public class MockRegisterService : IRegisterService
    {
        private IRepository _repository;
        public MockRegisterService()
        {
            _repository = new LocalRepository();
        }


        public void AddUserAccount(UserAccount user)
        {
            _repository.UserAccount.Add(user);
        }
    }
}
