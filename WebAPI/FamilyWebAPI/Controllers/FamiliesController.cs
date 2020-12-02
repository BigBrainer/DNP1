using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using FamilyWebAPI.DataAccess;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FamiliesController : ControllerBase
    {

        private IFamilyRepository familyRepo;

        public FamiliesController(IFamilyRepository familyRepo)
        {
            this.familyRepo = familyRepo;
        }

        /// <summary>
        /// Gets families, you can query to specify more
        /// </summary>
        /// <param name="streetName">Street name</param>
        /// <param name="houseNumber">House number</param>
        /// <param name="numberOfAdults">Number of adults</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamiliesWithQueryAsync([FromQuery] string? streetName, [FromQuery] int? houseNumber)
        {
            try
            {
                IList<Family> family = await familyRepo.GetFamiliesAsync(houseNumber, streetName);
                return Ok(family);
            }
            catch (Exception e)
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
            try
            {
              Family addedFamily = await familyRepo.AddFamilyAsync(family);
              return Ok(addedFamily);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Could not add family!");
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
                await familyRepo.RemoveFamilyAsync(houseNumber, streetName);
                return Ok();
            }
            catch (Exception e)
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
        [Route("adults")]
        public async Task<ActionResult> DeleteAdultAsync([FromQuery] int id)
        {
            try
            {
                await familyRepo.RemoveMemberAsync(id);
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
