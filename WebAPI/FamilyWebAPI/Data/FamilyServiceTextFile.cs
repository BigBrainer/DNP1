using FamilyWebAPI.Data;
using FileData;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageService
{
    public class FamilyServiceTextFile : IFamilyService
    {
        private FileContext fileContext;
        public FamilyServiceTextFile()
        {
            fileContext = new FileContext();
        }
        private bool FamilyExists(Family familyToFind)
        {
            Family family = fileContext.Families.FirstOrDefault(fam => fam.StreetName.Equals(familyToFind.StreetName, StringComparison.InvariantCultureIgnoreCase)
           && fam.HouseNumber == familyToFind.HouseNumber);
            return family != null;
        }

        public async Task<Family> AddFamilyAsync(Family familyToAdd)
        {
            for (int i = 0; i < familyToAdd.Adults.Count; i++)
            {
                familyToAdd.Adults[i].Id = LastId() + i + 1;
            }
            fileContext.Families.Add(familyToAdd);
            fileContext.SaveChanges();
            return familyToAdd;
        }

        public async Task<bool> AddressTakenCheckAsync(Family familyToAdd)
        {
            if (FamilyExists(familyToAdd))
            {
                throw new Exception("A family is already registered for that address");
            }
            return FamilyExists(familyToAdd);
        }

        private int LastId()
        {
            int last = 1;
            foreach (Family fam in fileContext.Families.Where(fam => fam.Adults.Any()))
            {
                last = fam.Adults.Max((Adult ad) => ad.Id);
            }
            return last;
        }
        public async Task RemoveMemberAsync(int adultId)
        {
            IList<Family> families = fileContext.Families;
            Adult adultToRemove = null;
            Family familyToRemoveFrom = families.FirstOrDefault((fam) => fam.Adults.Any(ad => ad.Id == adultId));
            foreach (Family fam in families)
            {
                foreach (Adult ad in fam.Adults)
                {
                    if (ad.Id == adultId)
                    {
                        adultToRemove = ad;
                    }
                    if (adultToRemove != null)
                    {
                        int familyIndex = fileContext.Families.IndexOf(fam);
                        fileContext.Families[familyIndex].Adults.Remove(adultToRemove);
                        fileContext.SaveChanges();
                        return;
                    }
                }
            }
        }
        public async Task<IList<Family>> LoadFamilyAsync(string? streetName, int? houseNumber, int? numberOfAdults)
        {
            IList<Family> families = fileContext.Families;
            IList<Family> familiesToReturn = new List<Family>();
            foreach(Family fam in families)
            {
                if ((streetName == null || streetName != null && streetName.Equals(fam.StreetName, StringComparison.InvariantCultureIgnoreCase)) && (houseNumber == null || houseNumber != null && houseNumber == fam.HouseNumber) &&
                    (numberOfAdults == null || numberOfAdults == fam.CalculateMembers(fam) && numberOfAdults != null))
                {
                    familiesToReturn.Add(fam);
                }
            }
            return familiesToReturn;
        }

        public async Task RemoveFamilyAsync(string streetName, int houseNumber)
        {
            Family familyToRemove = fileContext.Families.FirstOrDefault(fam => fam.StreetName.Equals(streetName, StringComparison.InvariantCultureIgnoreCase) && fam.HouseNumber == houseNumber);
            fileContext.Families.Remove(familyToRemove);
            fileContext.SaveChanges();
        }
    }
}

