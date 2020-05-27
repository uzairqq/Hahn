using System;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.May2020.Core.Dto;
using Hahn.ApplicationProcess.May2020.Core.Models;
using Hahn.ApplicationProcess.May2020.Data.Repositories.Interfaces;
using Hahn.ApplicationProcess.May2020.Domain.Services.Interfaces;

namespace Hahn.ApplicationProcess.May2020.Domain.Services.Implementation
{
    public class ApplicantService:IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        public ApplicantService(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task<ResponseMessagesDto> AddApplicant(ApplicantDto dto)
        {
            try
            {
               
                var customer = await _applicantRepository.Insert(new Applicant()
                {
                    Name = dto.Name
                });
                return new ResponseMessagesDto()
                {
                    Id = customer.Id,
                    SuccessMessage = "Success",
                    Success = true,
                    Error = false
                };
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessagesDto()
                {
                    Id = 0,
                    FailureMessage = "Failed Insertion",
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

    }
}
