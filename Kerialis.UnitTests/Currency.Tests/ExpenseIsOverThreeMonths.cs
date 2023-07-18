using Kerialis.Datas.Entities.V1;
using Kerialis.Repositories;
using Kerialis.Repositories.Factories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.UnitTests.Currency.Tests
{
    public class ExpenseIsOverThreeMonths
    {
        private readonly Mock<Expense> _repoExpense;

        public ExpenseIsOverThreeMonths()
        {
            _repoExpense = new Mock<Expense>();
        }

        [Fact]
        public void ExpenseIsOverThreeMonthsTest()
        {
            bool result = _repoExpense.Object.Date < DateTime.Now.AddMonths(-3);
            Assert.True(result, "Une dépense ne peut pas être datée de plus de 3 mois !");
        }
    }
}
