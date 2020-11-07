using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HandIn3.Database;
using HandIn3.Models;
using Microsoft.AspNetCore.Mvc;

namespace HandIn3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private DAOAdults adults;

        public AdultController(DAOAdults adults)
        {
            this.adults = adults;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> getAdults(
            [FromQuery] string firstName,
            [FromQuery] string lastName,
            [FromQuery] string jobTitle,
            [FromQuery] string hairColor,
            [FromQuery] string eyeColor,
            [FromQuery] string sex,
            [FromQuery] int? age,
            [FromQuery] int? AdultID
        )
        {
            try
            {
                IList<Adult> adultList = await adults.getAdults(firstName,lastName,jobTitle,hairColor,eyeColor,sex,
                age,AdultID);

                return Ok(adultList);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> addAdults([FromBody]Adult adult)
        {
            try
            {
                await adults.addAdult(adult);
                return Created($"/{adult.AdultID}", adult);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> deleteAdult([FromRoute] int id)
        {
            try
            {
                await adults.deleteAdult(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}