using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.Objects.Insurance;
using BLL.DTOs.Objects.InsuranceOffer;
using BLL.DTOs.People.Director;
using BLL.Facades.Insurance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private IInsuranceFacade _facade;

        public InsuranceController(IInsuranceFacade facade)
        {
            _facade = facade;
        }

        [HttpGet("getInsuranceOffer/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Offer not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Offer retrieved.")]
        public async Task<ActionResult<InsuranceOfferGetDTO>> GetOffer([Range(1, int.MaxValue)] int id)
        {
            var offer = await _facade.GetInsuranceOfferAsync(id);
            if (offer == null)
            {
                return NotFound();
            }
            return Ok(offer);
        }


        [HttpGet("getInsurance/{id}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Insurance not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Insurance retrieved.")]
        public async Task<ActionResult<InsuranceGetDTO>> GetInsurance([Range(1, int.MaxValue)] int id)
        {
            var insurance = await _facade.GetInsuranceAsync(id);
            if (insurance == null)
            {
                return NotFound();
            }
            return Ok(insurance);
        }

        [HttpGet("getAllInsurances")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Insurances not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Insurances retrieved.")]
        public async Task<ActionResult<IEnumerable<InsuranceGetDTO>>> GetAllInsurances([Range(1, int.MaxValue)] int? clientId = null)
        {
            var insurance = await _facade.GetAllInsurancesAsync(clientId);
            if (insurance == null)
            {
                return NotFound();
            }
            return Ok(insurance);
        }

        [HttpGet("getAllInsuranceOffers")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Insurance offers not found.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Insurance offers retrieved.")]
        public async Task<ActionResult<IEnumerable<InsuranceOfferGetDTO>>> GetAllInsuranceOffers([Range(1, int.MaxValue)] int? directorId = null)
        {
            var insuranceOffers = await _facade.GetAllInsuranceOffersAsync(directorId);
            if (insuranceOffers == null)
            {
                return NotFound();
            }
            return Ok(insuranceOffers);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] InsuranceOfferCreateDTO offer)
        {
            var result = await _facade.CreateInsuranceOfferAsync(offer);
            if (result == -1)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] InsuranceCreateDTO insurance)
        {
            var result = await _facade.CreateInsuranceAsync(insurance);
            if (result == -1)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] InsuranceUpdateDTO insurance)
        {
            if (!await _facade.UpdateInsuranceAsync(insurance))
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}
