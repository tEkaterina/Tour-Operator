using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using Services.Interfaces;
using WebUI.Models;
using Models;
using WebUI.Infrastructure;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Singin()
        {
            return View(new UserModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Singin(UserModel user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (user.Email != null || user.Password != null)
            {
                var existedUser = _userService.GetByEmail(user.Email);
                if (existedUser == null)
                {
                    ViewBag.Message = "Указанный пользователь не существует.";
                }
                else
                {
                    if (GetPasswordHash(user.Password, existedUser.Salt) == existedUser.Password)
                    {
                        FormsAuthentication.SetAuthCookie(user.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                    ViewBag.Message = "Неверный пароль.";
                }
            }
            return View(user);
        }
        
        public ActionResult Singout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Singin");
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
                AddRoles(user, newUser);
                _userService.Add(newUser);
                return Json(true);
            }
            return Json(false);
        }

        public ActionResult GetUser(int id = 0)
        {
            return View();
        }

        public ActionResult GetAllUsers()
        {
            return View(_userService.GetAll().ToList());
        }

        [HttpPost]
        public ActionResult RemoveUser(int id)
        {
            _userService.Remove(id);
            return Json(true);
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var user = _userService.GetById(id);
            return View(user.ToUserModel());
        }

        [HttpPost]
        public ActionResult EditUser(UserModel model)
        {
            var userForUpdate = _userService.GetById(model.Id);
            var user = new User()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = userForUpdate.Password,
                Salt = userForUpdate.Salt,
            };
            RemoveRoles(userForUpdate);
            AddRoles(model, user);
            _userService.Update(user);
            return Json(true);
        }

        public string GetUsername()
        {
            var user = _userService.GetByEmail(User.Identity.Name);
            return user.Name;
        }

        public bool IsUserAdmin()
        {
            var user = _userService.GetByEmail(User.Identity.Name);
            return user.Roles.FirstOrDefault(r => r.Name == "ADMIN") != null;
        }

        private void RemoveRoles(User userForUpdate)
        {
            foreach (var role in userForUpdate.Roles)
            {
                role.Users.Remove(userForUpdate);
            }
        }

        private void AddRoles(UserModel model, User user)
        {
            foreach (var roleName in model.Roles)
            {
                var role = _roleService.GetByName(roleName);
                if (role != null)
                {
                    user.Roles.Add(role);
                }
            }
        }

        private string GenerateSalt()
        {
            var random = new Random();
            var byteSalt = new byte[sizeof (int)];
            random.NextBytes(byteSalt);

            return BitConverter.ToString(byteSalt);
        }

        private string GetPasswordHash(string password, string salt)
        {
            password += salt;
            var sha1 = new SHA1CryptoServiceProvider();
            var hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(password));

            return BitConverter.ToString(hash);
        }
    }
}