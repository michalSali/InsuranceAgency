using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.Objects.ClientConnection;
using BLL.DTOs.Objects.Conflict;
using BLL.DTOs.Objects.ConflictInvolvement;
using BLL.DTOs.Objects.ConflictRecord;
using BLL.DTOs.People.Client;
using BLL.Facades.Client;
using BLL.Facades.Conflict;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConflictController : ControllerBase
    {
        private IConflictFacade _facade;

        public ConflictController(IConflictFacade facade)
        {
            _facade = facade;
        }


        // GET: api/<ConflictController>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Conflicts not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Conflicts retrieved.")]
        public async Task<ActionResult<IEnumerable<ConflictGetDTO>>> Get([Range(1, int.MaxValue)] int? directorId = null)
        {
            var conflicts = await _facade.GetAllConflictsAsync(directorId);
            if (conflicts == null)
            {
                return NotFound();
            }
            return Ok(conflicts);
        }

        // GET: api/<ClientController>/getConflictParticipants/5
        [HttpGet("getConflictParticipants/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Conflict id not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Conflict participants retrieved.")]
        public async Task<ActionResult<IEnumerable<ClientGetDTO>>> GetConflictParticipants([Range(1, int.MaxValue)] int id)
        {
            var clients = await _facade.GetAllConflictParticipantsAsync(id);
            if (clients == null)
            {
                return NotFound();
            }
            return Ok(clients);
        }

        // GET: api/<ClientController>/getConflictRecords/5
        [HttpGet("getConflictRecords/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Conflict id not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Conflict records retrieved.")]
        public async Task<ActionResult<IEnumerable<ConflictRecordGetDTO>>> GetConflictRecords([Range(1, int.MaxValue)] int id)
        {
            var records = await _facade.GetAllConflictRecords(id);
            if (records == null)
            {
                return NotFound();
            }
            return Ok(records);
        }

        // GET: api/<ClientController>/getConflict/5
        [HttpGet("getConflict/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Conflict id not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Conflict retrieved.")]
        public async Task<ActionResult<ConflictGetDTO>> GetConflict([Range(1, int.MaxValue)] int id)
        {
            var conflict = await _facade.GetAsync(id);
            if (conflict == null)
            {
                return NotFound();
            }
            return Ok(conflict);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ConflictInvolvementCreateDTO conflict)
        {
            var result = await _facade.AddConflictInvolvementAsync(conflict);
            if (result == -1)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ConflictRecordCreateDTO record)
        {
            var result = await _facade.AddConflictRecordAsync(record);
            if (result == -1)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([Range(1, int.MaxValue)] int clientId, [Range(1, int.MaxValue)] int conflictId, 
            [FromBody] ConflictRecordCreateDTO record)
        {
            var result = await _facade.AddConflictRecordAsync(clientId, conflictId, record);
            if (result == -1)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ConflictCreateDTO conflict)
        {
            var result = await _facade.CreateAsync(conflict);
            if (result == -1)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] ConflictUpdateDTO conflict)
        {
            if (!await _facade.UpdateAsync(conflict))
            {
                return NotFound();
            }
            return Ok(true);
        }

        // DELETE api/<ConflictController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete([Range(1, int.MaxValue)] int id)
        {
            if (!await _facade.DeleteAsync(id))
            {
                return NotFound();
            }

            return Ok(true);
        }
    }
}
