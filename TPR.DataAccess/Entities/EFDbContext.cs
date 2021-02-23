using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPR.DataAccess.Entities
{
    public class EFDbContext : IdentityDbContext<User>
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }
        public DbSet<Subreddit> Subreddits { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
