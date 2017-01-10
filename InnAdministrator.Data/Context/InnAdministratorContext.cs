using InnAdministrator.Data.Entities;
using System.Data.Entity;

namespace InnAdministrator.Data.Context
{
    public class InnAdministratorContext : DbContext
    {
        public InnAdministratorContext(): base("InnAdministratorConnectionString")
        {
            
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemProperty> ItemsProperties { get; set; }
    }
}
