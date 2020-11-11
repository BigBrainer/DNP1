using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class FamiliesController : ControllerBase
    {

        private IFamilyService service;

        public FamiliesController(IFamilyService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets families, you can query to specify more
        /// </summary>
        /// <param name="streetName">Street name</param>
        /// <param name="houseNumber">House number</param>
        /// <param name="numberOfAdults">Number of adults</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Family>> GetFamiliesWithQueryAsync([FromQuery] string? streetName, [FromQuery] int? houseNumber, [FromQuery] int? numberOfAdults)
        {
            try
            {
                IList<Family> families = await service.LoadFamilyAsync(streetName, houseNumber, numberOfAdults);
                return Ok(families);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Adds a family
        /// </summary>
        /// <param name="family">Family to be added</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Family>> AddFamilyAsync([FromBody] Family family)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!await service.AddressTakenCheckAsync(family))
                {
                    Family addedFamily = await service.AddFamilyAsync(family);
                    return Ok(family);
                }
                else
                {
                    return StatusCode(500, "The house number on this street is already taken!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Deletes a whole family
        /// </summary>
        /// <param name="streetName">Street name the family will be removed from</param>
        /// <param name="houseNumber">House number the family will be removed from</param>
        /// <returns></returns>
        // DELETE api/<FamilyController>
        [HttpDelete]
        public async Task<ActionResult> DeleteFamilyAsync([FromQuery] string streetName, [FromQuery] int houseNumber)
        {
            try
            {
                await service.RemoveFamilyAsync(streetName,houseNumber);
                return Ok();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Could not delete this family");
            }
        }

        /// <summary>
        /// Removes an adult from family
        /// </summary>
        /// <param name="id">Id of adult to remove</param>
        /// <returns></returns>
        [HttpDelete]
        [Route ("adults")]
        public async Task<ActionResult> DeleteAdultAsync([FromQuery] int id)
        {
            try
            {
                await service.RemoveMemberAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Could not delete this adult");
            }
        }

    }
}
