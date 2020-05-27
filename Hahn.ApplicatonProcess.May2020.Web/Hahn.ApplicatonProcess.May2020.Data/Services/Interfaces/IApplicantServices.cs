using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Domain;
using Hahn.ApplicatonProcess.May2020.Domain.Dto;

namespace Hahn.ApplicatonProcess.May2020.Data.Services.Interfaces
{
    public interface IApplicantServices
    {

        Task<List<ApplicantDto>> GetAllApplicantsAsync();
        Task<ResponseMessagesDto> AddApplicantAsync(ApplicantDto dto);
        Task<ApplicantDto> GetApplicantByIdAsync(int applicantId);
        Task<ResponseMessagesDto> DeleteApplicantAsync(ApplicantDto dto);
        Task<ResponseMessagesDto> UpdateApplicantAsync(ApplicantDto dto);
    }
}
