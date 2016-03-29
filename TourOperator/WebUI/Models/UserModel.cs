using System.Collections.Generic;

namespace WebUI.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<string> Roles { get; }

        public UserModel()
        {
            Roles = new List<string>();
        }
    }
}