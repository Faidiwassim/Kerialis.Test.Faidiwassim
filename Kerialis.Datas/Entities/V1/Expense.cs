using Kerialis.Datas.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Datas.Entities.V1
{
    [Table("Expense", Schema = "Kerialis")]
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public NatureEnum Nature { get; set; }
        public float Amount { get; set; }
        public int CurrencyId { get; set; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
