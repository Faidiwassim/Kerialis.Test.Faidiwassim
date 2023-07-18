using Kerialis.Datas.DTO;
using Kerialis.Datas.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Services
{
    public interface IExpenseService
    {
        Task<ExpenseUserDTO> GetExpenseUser(int userId,SortEnum sort);
    }
}
