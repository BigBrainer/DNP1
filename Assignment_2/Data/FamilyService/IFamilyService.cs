using FileData;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageService
{
    public interface IFamilyService
    {
        Task<bool> AddressTakenCheckAsync(Family family);
        Task AddFamilyAsync(Family family, IList<Adult> adults);
        Task RemoveMemberAsync(Family familyToRemoveFrom, int adultId);
        Task<List<Family>> LoadFamilyAsync();
    }
}
