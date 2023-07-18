using Kerialis.Datas.Entities.V1;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.UnitTests.Currency.Tests
{
    public class SameExpense
    {
        [Fact]
        public void SameExpenseTest()
        {
            var _repoExpense = new Expense();
            Mock<User> _repoUser = new Mock<User>();
            bool result = false;

            foreach (var expense in _repoUser.Object.Expenses)
            {
                int compDate = DateTime.Compare(expense.Date, _repoExpense.Date);
                bool compAmount = _repoExpense.Amount == expense.Amount;

                if (compDate == 0 && compAmount)
                {
                    result = true; break;
                }
            }
            Assert.True(result, "Un utilisateur ne peut pas déclarer deux fois la même dépense : même date et même montant !");
        }
    }
}
