using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Security.Claims;
using DanceSchool.DTO.User;
using DanceSchool.Entities;
using DanceSchool.Repositories.IRepository;
using DanceSchool.Services.IService;


namespace DanceSchool.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IUserRoleService userRoleService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }

        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userDto);
            }

            if (!await _userService.UserExists(userDto.Email))
            {
                ModelState.AddModelError("Email", "User with this email address doesn't exist!");
                return View(userDto);
            }

            if (await _userService.AuthorizeUser(userDto) == null)
            {
                ModelState.AddModelError("Password", "Invalid password!");
                return View(userDto);
            }

            var user = await _userService.GetUserByEmail(userDto.Email);
            await CreateClaimsAndSignInAsync(user);

            return RedirectToAction("Privacy", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (await _userService.UserExists(user.Email))
            {
                ModelState.AddModelError("Email", "This email address is already used!");
            }

            if (!user.Password.Equals(user.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords are not same!");
            }

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            List<string> roles = new();
            if (user.IsTeacher)
            {
                roles.Add("Teacher");
            }

            if (user.IsStudent)
            {
                roles.Add("Student");
            }

            var newUser = new UserCreateDto
            {
                Email = user.Email,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = roles
            };


            await _userService.CreateUser(newUser);

            return RedirectToAction("Login", "User");
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<UserDto> users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _userService.GetUserByIdAsync(id.Value);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        await _userService.UpdateUserAsync(user);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _userService.GetUserByIdAsync(id.Value);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _userService.DeleteUserAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Login");
            }

            var id = int.Parse(User.Identity.Name);
            var user = await _userService.GetUserDetailById(id);
            return View(user);
        }

        private async Task CreateClaimsAndSignInAsync(UserDto user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Id.ToString())
            };

            foreach (var role in user.RoleNames)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }
    }
}
