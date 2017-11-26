using AccountExternalEntity;
using System.Data.Entity;

namespace AccountExternalContext
{
    public class Context : DbContext
    {
        public Context() : base("AccountExternal")
        {

            if (Database.Exists())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Migrations.Configuration>());
            }
            else
            {
                Database.SetInitializer(new DBInitializer());
            }
        }

        public DbSet<ECredential> Credentials { get; set; }
        public DbSet<ERole> Roles { get; set; }
        public DbSet<ECredentialRole> CredentialRoles { get; set; }
    }
}
