using Kerialis.Datas.Entities.V1;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Datas.DbSeeds
{
    public class CurrencyDbSeed : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasData(new Currency
            {
                Id = 1,
                Name = "Dollar américain",
                Acronym = "$",
            },
            new Currency
            {
                Id = 2,
                Name = "Rouble russe",
                Acronym = "₽",
            },
            new Currency
            {
                Id = 3,
                Name = "Euro",
                Acronym = "€",
            });
        }
    }
}
