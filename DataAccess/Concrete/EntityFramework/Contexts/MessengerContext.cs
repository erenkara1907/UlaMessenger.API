using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class MessengerContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=185.86.80.251;Database=UlaMessenger;User Id=eren;Password=12345;");
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Profile> Profiles { get; set; }

    }
}
