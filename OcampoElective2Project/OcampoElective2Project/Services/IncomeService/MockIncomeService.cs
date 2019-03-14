using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;
using OcampoElective2Project.Repository;
using OcampoElective2Project.Repository.LocalRepository;

namespace OcampoElective2Project.Services.IncomeService
{
    public class MockIncomeService : IIncomeService
    {
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
