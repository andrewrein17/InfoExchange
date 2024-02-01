using Microsoft.AspNetCore.Mvc;
using InfoExchange.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace InfoExchange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private PostDBContext _context;
        public PostController(PostDBContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        //GET: id
        [HttpGet("{id}")]
        public Post GetPost(int id)
        {
            var post = _context.Posts.Find(id);
          
            return post;
        }

        //GET: Replies
        public IEnumerable<Post> GetReplies(int OPId)
        {
            List<Post> replies;
            replies = _context.Posts.FromSqlRaw($"EXEC GetReplies @ID = {OPId}").ToList();
            return replies;
        }

        //POST
        public async Task AddPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        //DELETE: Post/Reply
        public async Task DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
