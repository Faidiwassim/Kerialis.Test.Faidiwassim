using Kerialis.Datas.Entities.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.UnitTests.Currency.Tests
{
    public class CommentMandatory
    {
        [Fact]
        public void CommentMandatoryTest()
        {
            var _repoExpense = new Expense();
            bool result = string.IsNullOrEmpty(_repoExpense.Comment);
            Assert.True(result, "Le commentaire est obligatoire !");
        }
    }
}
