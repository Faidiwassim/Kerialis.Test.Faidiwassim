using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Datas.Entities.V1
{

    [Table("User", Schema = "Kerialis")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName {get;set;}
        public string LastName { get;set;}
        public int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
        public ICollection<Expense> Expenses { get;set;}

    }
}
