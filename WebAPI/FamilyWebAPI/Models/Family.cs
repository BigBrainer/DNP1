using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Family
    {

        //public int Id { get; set; }
        [Required]
        [JsonPropertyName("StreetName")]
        public string StreetName { get; set; }
        [Required, Range(1,999)]
        [JsonPropertyName("HouseNumber")]
        public int HouseNumber { get; set; }
        [JsonPropertyName("Adults")]
        public List<Adult> Adults { get; set; }
        [JsonPropertyName("Children")]
        public List<Child> Children { get; set; }
        [JsonPropertyName("Pets")]
        public List<Pet> Pets { get; set; }
        public Family()
        {
            Adults = new List<Adult>();
        }

        public int CalculateMembers(Family family)
        {
            if (family.Children == null)
            {
                return family.Adults.Count;
            }
            else
            {
                return family.Children.Count + family.Adults.Count;
            }
        }

    }


}