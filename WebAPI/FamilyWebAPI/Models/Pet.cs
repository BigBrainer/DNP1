using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Pet
    {

        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("Species")]
        public string Species { get; set; }
        [Required]
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [Required]
        [JsonPropertyName("Age")]
        public int Age { get; set; }
    }
}