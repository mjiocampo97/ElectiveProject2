using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OcampoElective2Project.Models;
using OcampoElective2Project.Repository;
using OcampoElective2Project.Repository.LocalRepository;

namespace OcampoElective2Project.Services.IncomeService
{
    public class MockIncomeService : IIncomeService
    {
        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OcampoElective.db3");
        private IRepository _repository;

        public MockIncomeService()
        {
            _repository = new LocalRepository();
        }
        public List<Income> GetIncomeUser(UserAccount incomeUnderUser)
        {
            var incomes = _repository.Income.GetRange(c => c.UserId == incomeUnderUser.AccountId);
            return incomes;
        }

        public void AddIncome(Income income)
        {
            _repository.Income.Add(income);
           
        }


        public void AddIncomeUser(UserAccount user)
        {
            _repository.UserAccount.Update(c => c.AccountId == user.AccountId, user);
        }

        public void DeleteIncome(Income income)
        {
            _repository.Income.Delete(c => c.Id == income.Id);
        }

        public void UpdateIncome(Income oldIncome, Income newIncome)
        {
            _repository.Income.Update(c => c.Id == oldIncome.Id, newIncome);
        }

        
    }
}
