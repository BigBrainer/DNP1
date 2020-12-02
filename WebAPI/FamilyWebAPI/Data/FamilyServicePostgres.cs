using FamilyWebAPI.DataAccess;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyWebAPI.Data
{
    public class FamilyServicePostgres : IFamilyService
    {
        public async Task<Family> AddFamilyAsync(Family familyToAdd)
        {
            using(FamilyDBContext dbContext = new FamilyDBContext())
            {
                await dbContext.Family.AddAsync(familyToAdd);
                await dbContext.SaveChangesAsync();
                var result = dbContext.Family.Where(fam => fam.HouseNumber == familyToAdd.HouseNumber && fam.StreetName.Equals(familyToAdd.StreetName, StringComparison.InvariantCultureIgnoreCase));
                return result.First();
            }
        }

        public Task<bool> AddressTakenCheckAsync(Family familyToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Family>> LoadFamilyAsync(string streetName, int? houseNumber, int? numberOfAdults)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFamilyAsync(string streetName, int houseNumber)
        {
            throw new NotImplementedException();
        }

        public Task RemoveMemberAsync(int adultId)
        {
            throw new NotImplementedException();
        }
    }
}
