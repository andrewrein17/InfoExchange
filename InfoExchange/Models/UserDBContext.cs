using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace InfoExchange.Models
{
    public class UserDBContext : DbContext
    {
        public static string UserDb = nameof(UserDb).ToLower();
        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
