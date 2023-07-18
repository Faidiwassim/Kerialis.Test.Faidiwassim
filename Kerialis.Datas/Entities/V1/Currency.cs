using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Datas.Entities.V1
{
    [Table("Currency", Schema = "Kerialis")]
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
