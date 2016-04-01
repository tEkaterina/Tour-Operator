using System.Data.Entity;
using Models;

namespace Orm
{
    public class EntityContext: DbContext
    {
        static EntityContext()
        {
            Database.SetInitializer(new EntityInitializer());
        }

        public EntityContext(): base("DBConnection") { } 

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<CustomerPersonalData> CustomerPersonalDatas { get; set; }
        public virtual DbSet<CustomerPassport> CustomerPassports { get; set; }
        public virtual DbSet<CustomerContactData> CustomerContactDatas { get; set; }
    }
}
