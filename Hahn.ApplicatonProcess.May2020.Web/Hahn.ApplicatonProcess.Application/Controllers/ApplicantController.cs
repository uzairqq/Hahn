using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Data.Services.Interfaces;
using Hahn.ApplicatonProcess.May2020.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicatonProcess.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantServices _applicantServices;
        public ApplicantController(IApplicantServices applicantServices)
        {
            _applicantServices = applicantServices;
        }
        /// <summary>
        /// Applicant
        /// Get ALL Applicants
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _applicantServices.GetAllApplicantsAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Applicant Post
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApplicantDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _applicantServices.AddApplicantAsync(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
       
        /// <summary>
        /// Get Applicant By ApplicantId
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        [HttpGet("applicantId/{applicantId}")]
        public async Task<IActionResult> GetById([FromRoute] int applicantId)
        {
            try
            {
                return Ok(await _applicantServices.GetApplicantByIdAsync(applicantId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Delete Applicant
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ApplicantDto dto)
        {
            try
            {
                return Ok(await _applicantServices.DeleteApplicantAsync(dto));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// To Update Applicant
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ApplicantDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _applicantServices.UpdateApplicantAsync(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}