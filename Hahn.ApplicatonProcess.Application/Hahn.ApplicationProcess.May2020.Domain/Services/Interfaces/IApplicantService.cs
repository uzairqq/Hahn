using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.May2020.Core.Dto;

namespace Hahn.ApplicationProcess.May2020.Domain.Services.Interfaces
{
    public interface IApplicantService
    {
        Task<ResponseMessagesDto> AddApplicant(ApplicantDto dto);
    }
}
