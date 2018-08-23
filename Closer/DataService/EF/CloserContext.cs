using Closer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.DataService.EF
{
    public class CloserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<UserDiscussion> UserDiscussions { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }

        public CloserContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
