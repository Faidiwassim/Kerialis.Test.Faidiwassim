using Kerialis.Datas.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.UnitTests.Currency.Tests
{
    public class ExpenseIsInFuture
    {
        [Fact]
        public void ExpenseIsInFutureTest()
        {
            var _repoExpense = new Expense();
            bool result = _repoExpense.Date > DateTime.Now;
            Assert.False(result, "Une dépense ne peut pas avoir une date dans le futur !");
        }
    }
}
