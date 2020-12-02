using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Adult : Person
    {
        [Required(ErrorMessage = "Enter a job position"), JsonPropertyName("JobTitle")]
        public string JobTitle { get; set; }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}