using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace InfoExchange.Models
{
    public class PostDBContext : DbContext
    {
        public PostDBContext(DbContextOptions<PostDBContext> options)
            : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
