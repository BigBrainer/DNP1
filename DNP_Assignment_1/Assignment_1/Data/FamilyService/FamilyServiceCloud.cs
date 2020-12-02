using ManageService;
using Microsoft.AspNetCore.Authentication;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Assignment_1.Data.FamilyService
{
    public class FamilyServiceCloud : IFamilyService
    {
        readonly private string uri = "http://localhost:5003/api";
        readonly private HttpClient client;

        public FamilyServiceCloud()
        {
            client = new HttpClient();
        }

        public async Task AddFamilyAsync(Family family, IList<Adult> adults)
        {
            foreach (Adult ad in adults)
            {
                family.Adults.Add(ad);
            }
            family.Pets = new List<Pet>();
            family.Children = new List<Child>();
            string familySerialized = JsonSerializer.Serialize(family, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(familySerialized);
            StringContent content = new StringContent(
                familySerialized,
                Encoding.UTF8,
                "application/json"
                );
            HttpResponseMessage response = await client.PostAsync(uri + "/Families", content);
            Console.WriteLine(response);
        }

        public async Task<bool> AddressTakenCheckAsync(Family family)
        {
            int houseNumber = family.HouseNumber;
            string streetName = family.StreetName;
            streetName.Replace(" ", "%");
            HttpResponseMessage response = await client.GetAsync($"{uri}/Families?housenumber={houseNumber}&streetname={streetName}");
            return response.StatusCode != System.Net.HttpStatusCode.InternalServerError;
        }
        private async Task<int> LastIdAsync()
        {
            var families = await LoadFamilyAsync();
            int last = 1;
            foreach (Family fam in families.Where(fam => fam.Adults.Any()))
            {
                last = fam.Adults.Max((Adult ad) => ad.Id);
            }
            return last;
        }

        public async Task<List<Family>> LoadFamilyAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Families");
            string message = await stringAsync;
            Console.WriteLine(message);
            List<Family> response = JsonSerializer.Deserialize<List<Family>>(message);
            return response;
        }

        public async Task RemoveMemberAsync(int adultId)
        {
            var families = await LoadFamilyAsync();
            Family familyToRemoveFrom = families.FirstOrDefault((fam) => fam.Adults.Any(ad => ad.Id == adultId));
            String streetToRemoveFrom = familyToRemoveFrom.StreetName;
            int houseNumberToRemoveFrom = familyToRemoveFrom.HouseNumber;
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/Families/adults?id={adultId}");
            Console.WriteLine(response);
        }

        public async Task RemoveFamilyAsync(Family familyToRemoveFrom)
        {
            String streetToRemoveFrom = familyToRemoveFrom.StreetName;
            int houseNumberToRemoveFrom = familyToRemoveFrom.HouseNumber;
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/Families?streetname={streetToRemoveFrom}&housenumber={houseNumberToRemoveFrom}");
            Console.WriteLine(response);
        }
    }
}
