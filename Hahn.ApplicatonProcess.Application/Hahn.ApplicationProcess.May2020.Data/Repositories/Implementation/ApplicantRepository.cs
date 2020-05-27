using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.May2020.Core.Models;
using Hahn.ApplicationProcess.May2020.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.May2020.Data.Repositories.Implementation
{
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(HahnDbContext context) : base(context) { }

        public Task<Applicant> GetByName(string applicantName)
        {
            return context.Set<Applicant>().FirstOrDefaultAsync(i => i.Name == applicantName);
            // return FirstOrDefault(author => author.Name == name);
        }

       
    }
}
