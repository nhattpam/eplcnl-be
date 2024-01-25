﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.AssignmentAttemptsService;
using ViewModel.RequestModel;
using ViewModel.ResponseModel;

namespace EPLCNL_API.Controllers
{
    [Route("api/assignment-attempts")]
    [ApiController]
    public class AssignmentAttemptsController : ControllerBase
    {
        private readonly IAssignmentAttemptService _assignmentattemptService;

        public AssignmentAttemptsController(IAssignmentAttemptService assignmentattemptService)
        {
            _assignmentattemptService = assignmentattemptService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AssignmentAttemptResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<AssignmentAttemptResponse>>> GetAll()
        {
            try
            {
                var rs = await _assignmentattemptService.GetAll();
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AssignmentAttemptResponse>> Create([FromBody] AssignmentAttemptRequest request)
        {
            try
            {
                var result = await _assignmentattemptService.Create(request);
                return CreatedAtAction(nameof(Create), result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<AssignmentAttemptResponse>> Delete([FromQuery] Guid id)
        {
            var rs = await _assignmentattemptService.Delete(id);
            return Ok(rs);
        }


        [HttpPut]
        public async Task<ActionResult<AssignmentAttemptResponse>> Update([FromQuery] Guid id, [FromBody] AssignmentAttemptRequest request)
        {
            try
            {
                var rs = await _assignmentattemptService.Update(id, request);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}