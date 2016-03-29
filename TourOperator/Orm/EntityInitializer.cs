using System.Data.Entity;
using Models;

namespace Orm
{
    class EntityInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            context.Roles.Add(new Role()
            {
                Name = "USER"
            });
            context.Roles.Add(new Role()
            {
                Name = "ADMIN"
            });

            base.Seed(context);
        }
    }
}
