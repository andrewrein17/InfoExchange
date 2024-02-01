using Microsoft.AspNetCore.Mvc;
using InfoExchange.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace InfoExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private UserDBContext _context;
        public UserController(UserDBContext context)
        {
            _context = context;
        }
        //GET
       [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        //POST
        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
