using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.May2020.Domain
{
   public class HahnDbContext:DbContext
    {
        public HahnDbContext(DbContextOptions<HahnDbContext> options)
            : base(options)
        {
        }

        public DbSet<Applicant> Applicant { get; set; }
    }
}
