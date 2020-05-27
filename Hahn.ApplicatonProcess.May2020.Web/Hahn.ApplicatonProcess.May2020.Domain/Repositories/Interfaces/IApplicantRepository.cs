using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Domain.Models;

namespace Hahn.ApplicatonProcess.May2020.Domain.Repositories.Interfaces
{
    public interface IApplicantRepository
    {
        Task<ResponseMessagesDto> AddApplicantAsync(Applicant applicant);

        Task<ResponseMessagesDto> UpdateApplicantAsync(Applicant applicant);
        Task<IEnumerable<Applicant>> GetAllApplicantAsync();
        Task<ResponseMessagesDto> DeleteApplicationAsync(Applicant applicant);
        Task<Applicant> GetApplicantByIdAsync(int applicantId);

    }
}
