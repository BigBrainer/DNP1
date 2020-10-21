using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Models
{
    public class Adult : Person
    {
        [Required(ErrorMessage = "Enter a job position")]
        public string JobTitle { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public void Update(Adult toUpdate)
        {
            JobTitle = toUpdate.JobTitle;
            base.Update(toUpdate);
        }

    }
}