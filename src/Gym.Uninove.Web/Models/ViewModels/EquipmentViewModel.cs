using Gym.Uninove.Core.Enums;

namespace Gym.Uninove.Web.Models.ViewModels
{
    public class EquipmentViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DatePurchase { get; set; }

        public StatusEquipment StatusPurchase { get; set; }

    }
}
