using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyWebAPI.Data
{
    public interface IFamilyService
    {
        Task<Family> AddFamilyAsync(Family familyToAdd);
        Task<bool> AddressTakenCheckAsync(Family familyToAdd);

        Task RemoveMemberAsync(int adultId);

        Task RemoveFamilyAsync(string streetName, int houseNumber);

        Task<IList<Family>> LoadFamilyAsync(string? streetName, int? houseNumber, int? numberOfAdults);
    }
}
