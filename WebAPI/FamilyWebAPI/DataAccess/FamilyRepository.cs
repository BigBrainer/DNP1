using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyWebAPI.DataAccess
{
    public class FamilyRepository : IFamilyRepository
    {
        private FamilyDBContext dbContext;
        public FamilyRepository(FamilyDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Family> AddFamilyAsync(Family familyToAdd)
        {
                EntityEntry<Family> newlyAddedFamily = await dbContext.Family.AddAsync(familyToAdd);
                await dbContext.SaveChangesAsync();
                return newlyAddedFamily.Entity;
        }

        public async Task<IList<Family>> GetFamiliesAsync(int? houseNumber, string? streetName)
        {
            return await dbContext.Family
                .Where(f => streetName == null || streetName != null && streetName.Equals(f.StreetName, StringComparison.InvariantCultureIgnoreCase) && (houseNumber == null || houseNumber != null && houseNumber == f.HouseNumber))
                .Include(f => f.Adults)
                .Include(f => f.Children)
                .Include(f => f.Pets)
                .ToListAsync();
        }

        public async Task RemoveFamilyAsync(int houseNumber, string streetName)
        {
            var familyToRemove = await dbContext.Family
                .FirstOrDefaultAsync(f => f.StreetName.Equals(streetName, StringComparison.InvariantCultureIgnoreCase) && houseNumber == f.HouseNumber);
            dbContext.Family.Remove(familyToRemove);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveMemberAsync(int adultId)
        {
            var adultToRemove = await dbContext.Adult.FirstOrDefaultAsync(a => a.Id == adultId);
            dbContext.Adult.Remove(adultToRemove);
            await dbContext.SaveChangesAsync();
        }
    }
}