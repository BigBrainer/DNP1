using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor_ToDo.Models
{
    public class ToDo
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Enter value bigger than 1!")]
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("id")]
        public int TodoId { get; set; }
        [Required, MaxLength(128), JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("completed")]
        public bool IsCompleted { get; set; }
    }
}
