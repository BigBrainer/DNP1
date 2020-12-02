using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class User
    {
        public User()
        {

        }

        [Required(ErrorMessage = "Enter a username"), MinLength(5, ErrorMessage = "The username must have at least 5 characters"), MaxLength(25, ErrorMessage = "The username must have a maximum of 25 characters")]
        [JsonPropertyName("Username")]
        [Key]
        public string Username { get; set; }
        [Required, MinLength(5, ErrorMessage = "The password must have at least 5 characters"), MaxLength(25, ErrorMessage = "The password must have a maximum of 25 characters"), ValidPassword(ErrorMessage = "The password must contain at least one uppercase letter and one digit")]
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Select a department")]
        [JsonPropertyName("Department")]
        public string Department { get; set; }
        [JsonPropertyName("SecurityLevel")]
        public int SecurityLevel{ get; set; }

        public class ValidPassword : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (!value.ToString().Any(char.IsUpper))
                {
                    return new ValidationResult("Password must contain at least 1 uppercase letter");
                }
                else if (!value.ToString().Any(char.IsDigit))
                {
                    return new ValidationResult("Password must contain at least 1 digit");
                }
                return ValidationResult.Success;
            }
        }
    }
}
