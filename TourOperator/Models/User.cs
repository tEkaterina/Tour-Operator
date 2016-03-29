using System.Collections.Generic;

namespace Models
{
    public class User: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public User()
        {
            Roles = new List<Role>();
        }
    }
}
