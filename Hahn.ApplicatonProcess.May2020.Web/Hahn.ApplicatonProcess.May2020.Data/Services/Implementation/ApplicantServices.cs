using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Data.Services.Interfaces;
using Hahn.ApplicatonProcess.May2020.Domain;
using Hahn.ApplicatonProcess.May2020.Domain.Dto;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Domain.Repositories.Interfaces;

namespace Hahn.ApplicatonProcess.May2020.Data.Services.Implementation
{
    public class ApplicantServices : IApplicantServices
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantServices(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }
        public async Task<List<ApplicantDto>> GetAllApplicantsAsync()
        {
            try
            {
                var applicants =  _applicantRepository.GetAllApplicantAsync().Result.
                    Select(i => new ApplicantDto()
                    {
                        Id = i.Id,
                        Name = i.Name
                    }).ToList();

                return applicants;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseMessagesDto> AddApplicantAsync(ApplicantDto dto)
        {
            try
            {
                var customer = await _applicantRepository.AddApplicantAsync(new Applicant()
                {
                    Name = dto.Name
                });
                return new ResponseMessagesDto()
                {
                    Id = customer.Id,
                    SuccessMessage = ResponseMessages.InsertionSuccessMessage,
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
                    FailureMessage = ResponseMessages.InsertionFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

        public async Task<ApplicantDto> GetApplicantByIdAsync(int applicantId)
        {
            try
            {
                var applicant = await _applicantRepository.GetApplicantByIdAsync(applicantId);
                var dto = new ApplicantDto()
                {
                    Id = applicant.Id,
                    Name = applicant.Name
                };
                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<ResponseMessagesDto> DeleteApplicantAsync(ApplicantDto dto)
        {
            try
            {
                await _applicantRepository.DeleteApplicationAsync(new Applicant()
                {
                    Id = dto.Id
                });
                return new ResponseMessagesDto()
                {
                    Id = dto.Id,
                    SuccessMessage = ResponseMessages.DeleteSuccessMessage,
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
                    FailureMessage = ResponseMessages.DeleteFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

        public async Task<ResponseMessagesDto> UpdateApplicantAsync(ApplicantDto dto)
        {
            try
            {

                return new ResponseMessagesDto()
                {
                    Id = dto.Id,
                    SuccessMessage = ResponseMessages.UpdateSuccessMessage,
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
                    FailureMessage = ResponseMessages.UpdateFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }
    }
}
