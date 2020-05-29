using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.May2020.Core.Dto;
using Hahn.ApplicationProcess.May2020.Core.Models;
using Hahn.ApplicationProcess.May2020.Data.Repositories.Interfaces;
using Hahn.ApplicationProcess.May2020.Domain.Services.Interfaces;

namespace Hahn.ApplicationProcess.May2020.Domain.Services.Implementation
{
    public class ApplicantService : IApplicantService
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
                    Name = dto.Name,
                    FamilyName = dto.FamilyName,
                    Address = dto.Address,
                    CountryOfOrigin = dto.CountryOfOrigin,
                    EmailAddress = dto.EmailAddress,
                    Age = dto.Age,
                    Hired = dto.Hired,
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

        public async Task<ApplicantDto> GetById(int applicantId)
        {
            try
            {
                var applicant = await _applicantRepository.GetById(applicantId);
                var applicantDto = new ApplicantDto()
                {
                    Id = applicant.Id,
                    Name = applicant.Name,
                    FamilyName = applicant.FamilyName,
                    Address = applicant.Address,
                    CountryOfOrigin = applicant.CountryOfOrigin,
                    EmailAddress = applicant.EmailAddress,
                    Age = applicant.Age,
                    Hired = applicant.Hired,
                };
                return applicantDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<ApplicantDto>> GetAll()
        {
            try
            {
                var applicants = await _applicantRepository.GetAll();
                return applicants.Select(i => new ApplicantDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    FamilyName = i.FamilyName,
                    Address = i.Address,
                    CountryOfOrigin = i.CountryOfOrigin,
                    EmailAddress = i.EmailAddress,
                    Age = i.Age,
                    Hired = i.Hired,
                }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public async Task<ResponseMessagesDto> DeleteApplicant(ApplicantDto applicantDto)
        {
            try
            {
                await _applicantRepository.Delete(new Applicant()
                {
                    Id = applicantDto.Id
                });
                return new ResponseMessagesDto()
                {
                    Id = applicantDto.Id,
                    SuccessMessage = "Successfully Deleted",
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
                    FailureMessage = "Failed To Delete",
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

        public async Task<ResponseMessagesDto> UpdateApplicant(ApplicantDto dto)
        {
            try
            {
                await _applicantRepository.Update(new Applicant()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    FamilyName = dto.FamilyName,
                    Address = dto.Address,
                    CountryOfOrigin = dto.CountryOfOrigin,
                    EmailAddress = dto.EmailAddress,
                    Age = dto.Age,
                    Hired = dto.Hired,
                });
                return new ResponseMessagesDto()
                {
                    Id = dto.Id,
                    SuccessMessage = "Successfully Updated",
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
                    FailureMessage = "Failed To Update",
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }
    }
}

