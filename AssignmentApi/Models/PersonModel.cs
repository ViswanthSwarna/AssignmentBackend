using System.ComponentModel.DataAnnotations;

namespace AssignmentApi.Models
{
    public class PersonModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public int Id { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? HomeAddress { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
    }
}