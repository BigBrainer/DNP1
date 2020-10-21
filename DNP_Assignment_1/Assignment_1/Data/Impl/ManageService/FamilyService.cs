using FileData;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageService
{
    public class FamilyService : IFamilyService
    {
        private FileContext fileContext;
        public FamilyService()
        {
            fileContext = new FileContext();
        }



        public void AddFamily(Family familyToAdd)
        {
            Family family = fileContext.Families.FirstOrDefault(fam => fam.StreetName.Equals(familyToAdd.StreetName, StringComparison.InvariantCultureIgnoreCase)
           && fam.HouseNumber == familyToAdd.HouseNumber);
            if (family == null)
            {
                fileContext.Families.Add(familyToAdd);
                if (!familyToAdd.Adults.Any())
                {
                    fileContext.Families.Remove(familyToAdd);
                }
                fileContext.SaveChanges();
            }
            else
            {
                throw new Exception("A family is already registered for that address");
            }
        }

        public void AddAdults(Family familyToAdd, List<Adult> adults)
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
            Family family = fileContext.Families.FirstOrDefault(fam => fam.StreetName.Equals(familyToAdd.StreetName, StringComparison.InvariantCultureIgnoreCase)
        && fam.HouseNumber == familyToAdd.HouseNumber);
            if (family != null)
            {
                throw new Exception("A family is already registered for that address");
            }
            return family != null;
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

