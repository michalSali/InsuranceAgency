using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.People.Director;
using BLL.Facades.Director;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private IDirectorFacade _facade;

        public DirectorController(IDirectorFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Any director not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Directors retrieved.")]
        public async Task<ActionResult<IEnumerable<DirectorGetDTO>>> Get()
        {
            var directors = await _facade.GetAllAsync();
            if (directors == null)
            {
                return NotFound();
            }
            return Ok(directors);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Director not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Director retrieved.")]
        public async Task<ActionResult<DirectorGetDTO>> Get([Range(1, int.MaxValue)] int id)
        {
            var director = await _facade.GetAsync(id, true);
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director);
        }

    }
}
