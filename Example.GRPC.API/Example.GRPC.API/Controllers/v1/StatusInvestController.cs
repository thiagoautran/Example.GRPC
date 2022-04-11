using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Autransoft.Api.Controllers.v1
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/statusinvest")]
    public class StatusInvestController : ControllerBase
    {
        [HttpGet("action")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = null)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = null)]
        public async Task<IActionResult> ListAsync()
        {
            try
            {
                var result = new List<string>();

                if (result == null || result.Count() == 0)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}