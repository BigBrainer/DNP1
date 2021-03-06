using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;

namespace Models
{
    public class Person
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a first name"), NotNull]
        [MinLength(2, ErrorMessage = "Enter a valid name")]
        [MaxLength(40, ErrorMessage = "Name too long")]
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter a last name"), NotNull]
        [MinLength(2, ErrorMessage = "Enter a valid name")]
        [MaxLength(40, ErrorMessage = "Name too long")]

        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [ValidHairColor, Required(ErrorMessage = "Enter a hair color")]
        [JsonPropertyName("HairColor")]
        public string HairColor { get; set; }
        [NotNull]
        [ValidEyeColor, Required(ErrorMessage = "Enter an eye color")]
        [JsonPropertyName("EyeColor")]
        public string EyeColor { get; set; }
        [NotNull, Range(0, 125, ErrorMessage = "Enter a valid age"), Required]
        [JsonPropertyName("Age")]
        public int Age { get; set; }
        [JsonPropertyName("Weight")]
        [NotNull, Range(1, 250, ErrorMessage = "Enter a valid weight"), Required]
        public float Weight { get; set; }
        [NotNull, Range(30, 300, ErrorMessage = "Enter a valid height"), Required]
        [JsonPropertyName("Height")]
        public int Height { get; set; }
        [NotNull, ValidSex, Required(ErrorMessage = "Enter a sex")]
        [JsonPropertyName("Sex")]
        public string Sex { get; set; }



        public void Update(Person toUpdate)
        {
            Age = toUpdate.Age;
            Height = toUpdate.Height;
            HairColor = toUpdate.HairColor;
            Sex = toUpdate.Sex;
            Weight = toUpdate.Weight;
            EyeColor = toUpdate.EyeColor;
            FirstName = toUpdate.FirstName;
            LastName = toUpdate.LastName;
        }

    }

    public class ValidHairColor : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> valid = new[] {"blond", "red", "brown", "black",
            "white", "grey", "blue", "green", "leverpostej"}.ToList();
            if (value != null && valid.Contains(value.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Valid hair colors are: Blond, Red, Brown, Black, White, Grey, Blue, Green, Leverpostej");
        }
    }

    public class ValidEyeColor : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> valid = new[] {"brown", "grey", "green", "blue",
            "amber", "hazel"}.ToList();
            if (value != null && valid.Contains(value.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Valid hair colors are: Brown, Grey, Green, Blue, Amber, Hazel");
        }
    }

    public class ValidSex : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString().Equals("M") || value.ToString().Equals("F"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Select a sex");
            }
        }
    }

}