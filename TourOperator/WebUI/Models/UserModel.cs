using System.Collections.Generic;

namespace WebUI.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<string> Roles { get; set; }

        public UserModel()
        {
            Roles = new List<string>();
        }
    }
}