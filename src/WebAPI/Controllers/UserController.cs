using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.People.Administrator;
using BLL.DTOs.People.Client;
using BLL.DTOs.People.Director;
using BLL.DTOs.People.InsuranceAgent;
using BLL.DTOs.People.User;
using BLL.Facades.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserManagementFacade _facade;

        public UserController(IUserManagementFacade facade)
        {
            _facade = facade;
        }

        // GET: api/<ClientController>/5
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User id not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User retrieved.")]
        public async Task<ActionResult<UserGetDTO>> Get([Range(1, int.MaxValue)] int id)
        {
            var user = await _facade.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User id not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User retrieved.")]
        public async Task<ActionResult<UserGetDTO>> Get(string name)
        {
            var user = await _facade.GetAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] UserUpdateDTO user)
        {
            if (!await _facade.UpdateAsync(user))
            {
                return NotFound(false);
            }
            return Ok(true);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] AdministratorCreateDTO administrator)
        {
            if (!await _facade.AddRoleAsync(administrator))
            {
                return NotFound(false);
            }
            return Ok(true);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] ClientCreateDTO client)
        {
            if (!await _facade.AddRoleAsync(client))
            {
                return NotFound(false);
            }
            return Ok(true);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] DirectorCreateDTO director)
        {
            if (!await _facade.AddRoleAsync(director))
            {
                return NotFound(false);
            }
            return Ok(true);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] InsuranceAgentCreateDTO insuranceAgent)
        {
            if (!await _facade.AddRoleAsync(insuranceAgent))
            {
                return NotFound(false);
            }
            return Ok(true);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] DirectorUpdateDTO director)
        {
            if (!await _facade.UpdateRoleAsync(director))
            {
                return NotFound(false);
            }
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete([Range(1, int.MaxValue)] int id)
        {
            if (!await _facade.DeleteAsync(id))
            {
                return NotFound(false);
            }

            return Ok(true);
        }

        [HttpDelete("deleteAdminRole/{id}")]
        public async Task<ActionResult<bool>> DeleteAdminRole([Range(1, int.MaxValue)] int id)
        {
            if (!await _facade.DeleteAdministratorRoleAsync(id))
            {
                return NotFound(false);
            }

            return Ok(true);
        }


        [HttpDelete("deleteClientRole/{id}")]
        public async Task<ActionResult<bool>> DeleteClientRole([Range(1, int.MaxValue)] int id)
        {
            if (!await _facade.DeleteClientRoleAsync(id))
            {
                return NotFound(false);
            }

            return Ok(true);
        }


        [HttpDelete("deleteDirectorRole/{id}")]
        public async Task<ActionResult<bool>> DeleteDirectorRole([Range(1, int.MaxValue)] int id)
        {
            if (!await _facade.DeleteDirectorRoleAsync(id))
            {
                return NotFound(false);
            }

            return Ok(true);
        }


        [HttpDelete("deleteAgentRole/{id}")]
        public async Task<ActionResult<bool>> DeleteAgentRole([Range(1, int.MaxValue)] int id)
        {
            if (!await _facade.DeleteInsuranceAgentRoleAsync(id))
            {
                return NotFound(false);
            }

            return Ok(true);
        }
    }
}
