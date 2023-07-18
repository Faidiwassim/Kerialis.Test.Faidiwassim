using Kerialis.Datas.Entities.V1;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Datas.Entities.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
       public void Configure(EntityTypeBuilder<Currency> builder)
        {}
    }
}
