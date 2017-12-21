using System.Threading.Tasks;
using Foodinio.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Foodinio.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.BrowseAsync();
            return Json(users);
        }
    }
}