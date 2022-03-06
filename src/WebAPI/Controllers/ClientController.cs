using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.Objects.BackgroundInfo;
using BLL.DTOs.Objects.ClientConnection;
using BLL.DTOs.Objects.Gear;
using BLL.DTOs.People.Client;
using BLL.DTOs.People.User;
using BLL.Facades.Client;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private IClientFacade _facade;

        public ClientController(IClientFacade facade)
        {
            _facade = facade;
        }

        // GET: api/<ClientController>/5
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Agent id not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Clients of agent retrieved.")]
        public async Task<ActionResult<IEnumerable<ClientGetDTO>>> Get([Range(1, int.MaxValue)] int agentId)
        {
            var clients = await _facade.GetAllClientsAsync(true, agentId);
            if (clients == null)
            {
                return NotFound();
            }
            return Ok(clients);
        }


        // GET api/<ClientController>/GetDTO/5
        [HttpGet("getDTO/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Client id not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Client retrieved.")]
        public async Task<ActionResult<ClientGetDTO>> GetDto([Range(1, int.MaxValue)] int id)
        {
            var client =  await _facade.GetAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        // GET api/<ClientController>/getExtended/5
        [HttpGet("getExtended/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Client id not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Client retrieved.")]
        public async Task<ActionResult<ClientGetDTO>> GetExtendedDto([Range(1, int.MaxValue)] int id)
        {
            var client = await _facade.GetWithExtendedInfoAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        // GET api/<ClientController>/getAggregated/5
        [HttpGet("getAggregated/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Client id not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Client retrieved.")]
        public async Task<ActionResult<ClientGetAggregatedDTO>> GetAggregatedDto([Range(1, int.MaxValue)] int id)
        {
            var client = await _facade.GetAggregatedAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        // GET: api/<ClientController>/getAllAggregated/5
        [HttpGet("getAllAggregated/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Agent id not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Clients of agent retrieved.")]
        public async Task<ActionResult<IEnumerable<ClientGetAggregatedDTO>>> GetAllAggregated([Range(1, int.MaxValue)] int agentId)
        {
            var clients = await _facade.GetAllClientsAggregatedAsync(agentId);
            if (clients == null)
            {
                return NotFound();
            }
            return Ok(clients);
        }


        // POST api/<ClientController>/AddClientConnection
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ClientConnectionCreateDTO connection)
        {
            var result = await _facade.AddClientConnectionAsync(connection);
            if (result == -1)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<ClientController>/AddGear
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] GearCreateDTO connection)
        {
            var result = await _facade.AddGearAsync(connection);
            if (result == -1)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<ClientController>/AddBackgroundInfo
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] BackgroundInfoCreateDTO connection)
        {
            var result = await _facade.AddBackgroundInfoAsync(connection);
            if (result == -1)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(int id, [FromBody] UserCreateDTO user)
        {
            var result = await _facade.CreateNewAsync(id, user);
            if (result == -1)
            {
                return NotFound();
            }
            return Ok(result);
        }



        // PUT api/<ClientController>/5
        [HttpPut("changeAgent/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Agent or client id not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Client's agent updated.")]
        public async Task<ActionResult<bool>> Put([Range(1, int.MaxValue)] int clientId, [FromBody] int agentId)
        {
            if (await _facade.ChangeAgentAsync(clientId, agentId))
            {
                return Ok(true);
            }
            return NotFound();
        }
    }
}
