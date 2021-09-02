using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ImpulsoTeste.Marcilio.EntityFrameworkCore
{
    public static class MarcilioDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MarcilioDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MarcilioDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
