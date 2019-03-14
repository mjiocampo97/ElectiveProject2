using System;
using System.Collections.Generic;
using System.Text;
using OcampoElective2Project.Models;

namespace OcampoElective2Project.Services.IncomeService
{
    public interface IIncomeService
    {
        List<Income> GetIncomeUser(UserAccount incomeUnderUser);
        void AddIncome(Income income);
        void DeleteIncome(Income income);
        void UpdateIncome(Income oldIncome, Income newIncome);
        void AddIncomeUser(UserAccount user);

    }
}
