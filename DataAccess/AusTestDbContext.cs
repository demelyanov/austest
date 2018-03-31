using AusTest.Domain.Model;
using AusTest.Domain.Model.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AusTest.DataAccess
{
    public class AusTestDbContext : IdentityDbContext<AusTestUser, AusTestRole, int>
    {
        public AusTestDbContext(DbContextOptions<AusTestDbContext> options) : base(options) { }

        public DbSet<Requirement> Requirements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
