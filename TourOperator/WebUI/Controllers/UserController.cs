using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using Services.Interfaces;
using WebUI.Models;
using Models;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserModel user)
        {
            if (user != null)
            {
                var salt = GenerateSalt();
                var newUser = new User()
                {
                    Email = user.Email,
                    Name = user.Name,
                    Salt = salt,
                    Password = GetPasswordHash(user.Password, salt),
                };

                foreach (var roleName in user.Roles)
                {
                    var role = _roleService.GetByName(roleName);
                    if (role != null)
                    {
                        newUser.Roles.Add(role);
                    }
                }

                _userService.AddUser(newUser);
                return Json(true);
            }
            else
                return Json(false);
        }

        public ActionResult GetUser(int id = 0)
        {
            return View();
        }

        public ActionResult GetAllUsers()
        {
            return View(_userService.GetAll());
        }

        private string GenerateSalt()
        {
            var random = new Random();
            var byteSalt = new byte[sizeof (int)];
            random.NextBytes(byteSalt);

            return Encoding.Unicode.GetString(byteSalt);
        }

        private string GetPasswordHash(string password, string salt)
        {
            password += salt;
            var sha1 = new SHA1CryptoServiceProvider();
            var hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(password));

            return Encoding.Unicode.GetString(hash);
        }
    }
}