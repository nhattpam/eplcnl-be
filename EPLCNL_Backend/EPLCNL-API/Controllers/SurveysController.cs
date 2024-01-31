﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.SurveysService;
using ViewModel.RequestModel;
using ViewModel.ResponseModel;

namespace EPLCNL_API.Controllers
{
    /// <summary>
    /// Controller for managing surveys.
    /// </summary>
    [Route("api/surveys")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveysController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        /// <summary>
        /// Get a list of all surveys.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SurveyResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<SurveyResponse>>> GetAll()
        {
            try
            {
                var rs = await _surveyService.GetAll();
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get survey by survey id.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SurveyResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<SurveyResponse>> Get(Guid id)
        {
            try
            {
                var rs = await _surveyService.Get(id);
                return Ok(rs);
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Create new survey.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SurveyResponse>> Create([FromBody] SurveyRequest request)
        {
            try
            {
                var result = await _surveyService.Create(request);
                return CreatedAtAction(nameof(Create), result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete survey by survey id.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<SurveyResponse>> Delete(Guid id)
        {
            var rs = await _surveyService.Delete(id);
            return Ok(rs);
        }

        /// <summary>
        /// Update survey by survey id.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<SurveyResponse>> Update(Guid id, [FromBody] SurveyRequest request)
        {
            try
            {
                var rs = await _surveyService.Update(id, request);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
