using FileData;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageService
{
    public class FamilyService
    {
        private FileContext fileContext;
        public FamilyService()
        {
            fileContext = new FileContext();
        }
        private bool FamilyExists(Family familyToFind)
        {
            Family family = fileContext.Families.FirstOrDefault(fam => fam.StreetName.Equals(familyToFind.StreetName, StringComparison.InvariantCultureIgnoreCase)
           && fam.HouseNumber == familyToFind.HouseNumber);
            return family != null;
        }

        public void AddFamily(Family familyToAdd, List<Adult> adults)
        {
            for (int i = 0; i < adults.Count; i++)
            {
                adults[i].Id = LastId() + i + 1;
                familyToAdd.Adults.Add(adults[i]);
            }
            fileContext.Families.Add(familyToAdd);
            fileContext.SaveChanges();
        }

        public bool AddressTakenCheck(Family familyToAdd)
        {
            if (!FamilyExists(familyToAdd))
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
        public List<Family> LoadFamily()
        {
            return (List<Family>)fileContext.Families;
        }
    }
}

