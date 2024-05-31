using Gym.Uninove.Core.Entities;

namespace Gym.Uninove.Web.Models.ViewModels
{
    public class GymBranchViewModel
    {

        public GymBranch GymBranch { get; set; }

        public Address Address { get; set; }

        public IFormFile ImageFile { get; set; }

    }
}
