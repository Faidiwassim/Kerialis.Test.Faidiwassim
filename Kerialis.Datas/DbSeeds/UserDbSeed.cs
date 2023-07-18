using Kerialis.Datas.Entities.V1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Datas.DbSeeds
{
    public class UserDbSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                Id = 1,
                FirstName = "Stark",
                LastName = "Anthony",
                CurrencyId = 1,
            },
            new User
            {
                Id = 2,
                FirstName = "Romanova",
                LastName = "Natasha",
                CurrencyId = 2,
            });
        }
    }
}
