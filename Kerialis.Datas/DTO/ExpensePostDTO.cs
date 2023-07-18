using Kerialis.Datas.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Datas.DTO
{
    public class ExpensePostDTO
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public NatureEnum NatureEnum { get; set; }
        public float Amount { get; set; }
        public int CurrencyId { get; set; }
        public string Comment { get; set; }
    }
}
