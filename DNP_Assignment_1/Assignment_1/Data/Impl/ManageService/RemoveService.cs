using FileData;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageService
{
    public class RemoveService : IRemoveService
    {
        private FileContext fileContext;

        public RemoveService()
        {
            fileContext = new FileContext();
        }
        public void RemoveMember(Family familyToRemoveFrom, int adultId)
        {
            string streetName = familyToRemoveFrom.StreetName;
            int houseNumber = familyToRemoveFrom.HouseNumber;
            Family family = fileContext.Families.FirstOrDefault((fam) => fam.HouseNumber == houseNumber && fam.StreetName.Equals(streetName, StringComparison.InvariantCultureIgnoreCase));
            int familyIndex = fileContext.Families.IndexOf(family);
            var adultToRemove = family.Adults.FirstOrDefault((ad) => ad.Id == adultId);
            fileContext.Families[familyIndex].Adults.Remove(adultToRemove);
            fileContext.SaveChanges();
        }
    }
}
