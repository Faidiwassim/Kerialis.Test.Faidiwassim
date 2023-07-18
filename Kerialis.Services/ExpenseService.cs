using Kerialis.Datas.DbContexts;
using Kerialis.Datas.DTO;
using Kerialis.Datas.Entities.V1;
using Kerialis.Datas.Enum;
using Kerialis.Repositories;
using Kerialis.Repositories.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository<Expense, int, KerialisContext> _repoExpense;
        public ExpenseService(IRepositoryFactory<KerialisContext> repo)
        {
            _repoExpense = repo.Create<Expense, int>();
        }

        public async Task<ExpenseUserDTO> GetExpenseUser(int userId, SortEnum sort)
        {

            var expenses = await _repoExpense.FindAsQuerableAsync(x => x.UserId == userId);
            var listExpense = expenses.Include(x => x.User).ThenInclude(x => x.Currency).ToList();

            switch(sort)
            {
                case SortEnum.Date:

                    listExpense = listExpense.OrderBy(x => x.Date).ToList();

                    break;
                case SortEnum.Amount:

                    listExpense = listExpense.OrderBy(x => x.Amount).ToList();
                    break;
                default:
                    break;
            }

            if (expenses != null && expenses.Count() > 0)
            {
                ExpenseUserDTO result = new ExpenseUserDTO
                {
                    FirstName = expenses.First().User.FirstName,
                    LastName = expenses.First().User.LastName,
                    CurrencyAcronym = expenses.First().User.Currency.Acronym,
                    CurrencyName = expenses.First().User.Currency.Name,
                    Expenses = new List<ExpenseDTO>()
                };
                foreach (var expense in listExpense)
                {
                    result.Expenses.Add(new ExpenseDTO
                    {
                        Amount = expense.Amount,
                        Comment = expense.Comment, 
                        Date = expense.Date,
                        Nature = expense.Nature.ToString()
                    });
                }
                return result;
            }
            return null;
        }
    }
}
