using System.Data.Entity;
using Models;

namespace Orm
{
    class EntityInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            var adminRole = new Role() {Name = "ADMIN"};
            var userRole = new Role() {Name = "USER"};
            context.Roles.AddRange(
            new Role[]{ adminRole, userRole });

            context.Cities.AddRange(new City[]
            {
                new City() {Name = "Минск"},
                new City() {Name = "Брест"},
                new City() {Name = "Витебск"},
                new City() {Name = "Гомель"},
                new City() {Name = "Могилев"},
                new City() {Name = "Кобрин"},
                new City() {Name = "Бобруйск"},
                new City() {Name = "Орша"},
                new City() {Name = "Полоцк"},
            });

            context.Citizenships.AddRange(new Citizenship[]
            {
                new Citizenship() { Name = "РБ"},
                new Citizenship() { Name = "Двойное гражданство"},
                new Citizenship() { Name = "Иное граждаство"},
                new Citizenship() { Name = "Без гражданства"},
            });

            context.Disabilities.AddRange(new Disability[]
            {
                new Disability() { Name = "Нет" },
                new Disability() { Name = "I группа"},
                new Disability() { Name = "II группа"},
                new Disability() { Name = "III группа"},
            });

            context.MaritalStatuses.AddRange(new MaritalStatus[]
            {
                new MaritalStatus() { Name = "Холост/не замужем"},
                new MaritalStatus() { Name = "Женат/замужем"},
                new MaritalStatus() { Name = "Разведен/разведена"},
                new MaritalStatus() { Name = "Вдовец/вдова"},
            });

            var user = new User()
            {
                Name = "admin",
                Email = "admin@mail.ru",
                Salt = "F8-46-25-BE",
                Password = "AC-21-E9-2A-61-0A-76-3C-9C-2C-1C-51-E3-6B-3D-32-8B-76-C0-93"
            };

            userRole.Users.Add(user);
            adminRole.Users.Add(user);

            context.Users.Add(user);

            base.Seed(context);
        }
    }
}
