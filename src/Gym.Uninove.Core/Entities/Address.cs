using System.ComponentModel.DataAnnotations;

namespace Gym.Uninove.Core.Entities
{
    public class Address
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [MinLength(5, ErrorMessage = "Street must be at least 5 characters long")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Field Required")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Field Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Field Required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [MinLength(5, ErrorMessage = "Street must be at least 5 characters long")]
        public string Neighborhood { get; set; }

        public string Complement { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "ZipCode must be in the format 09999-999")]
        public string ZipCode { get; set; }

        // Foreign Key
        public GymBranch Gym { get; set; }
        public int GymId { get; set; }

    }
}
