using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_ToDo.Models
{
    public class ToDo
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Enter value bigger than 1!")]
        public int UserId { get; set; }
        public int TodoId { get; set; }
        [Required, MaxLength(128)]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
