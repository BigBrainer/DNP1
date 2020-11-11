using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{
    public class Child : Person
    {
        [JsonPropertyName("ChildInterests")]
        public List<ChildInterest> ChildInterests { get; set; }
        [JsonPropertyName("Pets")]
        public List<Pet> Pets { get; set; }

        public void Update(Child toUpdate)
        {
            base.Update(toUpdate);
            ChildInterests = toUpdate.ChildInterests;
            Pets = toUpdate.Pets;
        }

    }
}