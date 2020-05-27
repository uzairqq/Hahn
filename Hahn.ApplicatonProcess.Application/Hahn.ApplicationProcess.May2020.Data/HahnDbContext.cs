using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicationProcess.May2020.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.May2020.Data
{
    public class HahnDbContext : DbContext
    {
        public HahnDbContext(DbContextOptions<HahnDbContext> options) : base(options)
        { }
        public DbSet<Applicant> Applicants { get; set; }
    }
}
