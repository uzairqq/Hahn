using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.May2020.Core.Dto;
using Hahn.ApplicationProcess.May2020.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicationProcess.May2020.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "name": "Uzair",
        ///        "familyName": "ABC",
        ///         "address": "XYZ",
        ///         "countryOfOrigin": "US",
        ///         "emailAddress": "xyz.qq@outlook.com",
        ///         "age": 25,
        ///         "hired": false,
        ///         "id": 0,
        ///     }
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created Applicant</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ApplicantDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _applicantService.AddApplicant(dto));
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
                return Ok(await _applicantService.GetById(applicantId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Customer
        /// Get ALL Applicant
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _applicantService.GetAll());
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
                return Ok(await _applicantService.DeleteApplicant(dto));

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
                return Ok(await _applicantService.UpdateApplicant(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}