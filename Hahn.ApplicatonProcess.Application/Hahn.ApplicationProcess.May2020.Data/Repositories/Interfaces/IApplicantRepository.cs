using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.May2020.Core.Models;

namespace Hahn.ApplicationProcess.May2020.Data.Repositories.Interfaces
{
    public interface IApplicantRepository : IRepository<Applicant>
    {
        Task<Applicant> GetByName(string applicantName);
    }
}
