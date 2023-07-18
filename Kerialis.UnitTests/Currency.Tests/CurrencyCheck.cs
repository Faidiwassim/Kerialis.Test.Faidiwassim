using Kerialis.Datas.Entities.V1;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.UnitTests.Currency.Tests
{
    public class CurrencyCheck
    {
        [Fact]
        public void CurrencyCheckTest()
        {
            var _repoUser = new Mock<User>();
            var _repoExpense= new Mock<Expense>();
            bool result = false;

            foreach (var expense in _repoUser.Object.Expenses)
            {
                if (expense.Currency == _repoExpense.Object.Currency)
                {
                    result = true; break;
                }
            }
            Assert.False(result, "la devise de la dépense doit étre identique de celle de l'utilisateur !");
        }
    }
}
