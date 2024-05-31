
using System.ComponentModel.DataAnnotations;

namespace Gym.Uninove.Core.Entities
{
    public class GymBranch
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Field Required")]
        public int UnitNumber { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [MinLength(5, ErrorMessage = "Street must be at least 5 characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Required")]
        [RegularExpression(@"^\(\d{2}\) \d{5}-\d{4}$", ErrorMessage = "Phone must be in the format (11) 99999-9999")]
        public string Phone { get; set; }

        public string ImagePath { get; set; }

        public Address Address { get; set; }

        public ICollection<Equipment> Equipments { get; set; }

        public ICollection<Teacher> Instructors { get; set; }

        public ICollection<GroupClass> GroupClasses { get; set; }

    }
}
