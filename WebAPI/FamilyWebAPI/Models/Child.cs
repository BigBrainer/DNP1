using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models {
    public class Child : Person
    {
        [JsonPropertyName("ChildInterests")]
        public List<ChildInterest> ChildInterests { get; set; }
        [JsonPropertyName("Pets")]
        public List<Pet> Pets { get; set; }

    }
}