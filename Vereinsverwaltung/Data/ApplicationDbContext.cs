using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vereinsverwaltung.Models;

namespace Vereinsverwaltung.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Interessengruppe> Interessengruppen { get; set; }
        public DbSet<Mitgliedschaft> Mitgliedschaften { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
