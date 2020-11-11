using ManageService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment_2.Data.FamilyService
{
    public class FamilyServiceCloud : IFamilyService
    {
        readonly private string uri = "http://dnp.metamate.me";
        readonly private HttpClient client;

        public FamilyServiceCloud()
        {
            client = new HttpClient();
        }

        public Task AddFamilyAsync(Family family, IList<Adult> adults)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddressTakenCheckAsync(Family family)
        {
            int houseNumber = family.HouseNumber;
            string streetName = family.StreetName;
            streetName.Replace(" ", "%");
            Task<string> stringAsync = client.GetStringAsync($"{uri}/Families?housenumber={houseNumber}&streetname={streetName}");
            string message = await stringAsync;
            return message != null;
        }


        public async Task<List<Family>> LoadFamilyAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Families");
            string message = await stringAsync;
            List<Family> response = JsonSerializer.Deserialize<List<Family>>(message);
            return response;
        }

        public Task RemoveMemberAsync(Family familyToRemoveFrom, int adultId)
        {
            throw new NotImplementedException();
        }
    }
}
