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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomerPersonalData>()
                .HasRequired(c => c.CustomerPassport)
                .WithRequiredPrincipal(t => t.CustomerPersonalData)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<CustomerPersonalData>()
                .HasRequired(c => c.CustomerContactData)
                .WithRequiredPrincipal(t => t.CustomerPersonalData)
                .WillCascadeOnDelete(true);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<CustomerPersonalData> CustomerPersonalDatas { get; set; }
        public virtual DbSet<CustomerPassport> CustomerPassports { get; set; }
        public virtual DbSet<CustomerContactData> CustomerContactDatas { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Citizenship> Citizenships { get; set; }
        public virtual DbSet<Disability> Disabilities { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
    }
}
