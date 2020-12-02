using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyWebAPI.DataAccess
{
    public interface IFamilyRepository
    {

        Task<IList<Family>> GetFamiliesAsync(int? houseNumber, string? streetName);
        Task RemoveFamilyAsync(int houseNumber, string streetName);
        Task<Family> AddFamilyAsync(Family familyToAdd);
        Task RemoveMemberAsync(int adultId);
    }
}
