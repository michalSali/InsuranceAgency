using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.People.Director;
using BLL.DTOs.People.InsuranceAgent;
using BLL.Facades.InsuranceAgent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceAgentController : ControllerBase
    {
        private IInsuranceAgentFacade _facade;

        public InsuranceAgentController(IInsuranceAgentFacade facade)
        {
            _facade = facade;
        }

        [HttpGet("getById")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Insurance agent not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Insurance agent retrieved.")]
        public async Task<ActionResult<InsuranceAgentGetDTO>> GetById([Range(1, int.MaxValue)] int id)
        {
            var agent = await _facade.GetAsync(id);
            if (agent == null)
            {
                return NotFound();
            }
            return Ok(agent);
        }

        [HttpGet("getAll")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Insurance agents not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Insurance agents retrieved.")]
        public async Task<ActionResult<IEnumerable<InsuranceAgentGetDTO>>>  GetAll([Range(1, int.MaxValue)] int? id)
        {
            var agents = await _facade.GetAllAsync(id);
            if (agents == null)
            {
                return NotFound();
            }
            return Ok(agents);
        }

    }
}
