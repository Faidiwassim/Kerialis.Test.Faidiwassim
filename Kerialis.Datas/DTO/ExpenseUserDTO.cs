using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Datas.DTO
{

    public class ExpenseUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyAcronym { get; set; }
        public List<ExpenseDTO> Expenses { get; set; }
    }

    public class ExpenseDTO
    {
        public DateTime Date { get; set; }
        public string Nature { get; set; }
        public float Amount { get; set; }
        public string Comment { get; set; }
    }



 
}
