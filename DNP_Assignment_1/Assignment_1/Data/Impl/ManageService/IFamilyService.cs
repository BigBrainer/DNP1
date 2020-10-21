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
        bool AddressTakenCheck(Family family);
        void AddAdults(Family family, List<Adult> adults);
        void AddFamily(Family family);
        void RemoveMember(Family familyToRemoveFrom, int adultId);
        List<Family> LoadFamily();
    }
}
