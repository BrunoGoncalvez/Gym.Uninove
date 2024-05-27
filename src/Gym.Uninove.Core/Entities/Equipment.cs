
using Gym.Uninove.Core.Enums;

namespace Gym.Uninove.Core.Entities
{
    public class Equipment
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime UsageTime { get; set; }

        public DateTime DatePurchase { get; set; }

        public StatusEquipment StatusPurchase { get; set; }

        // TODO: Adicionar Foreign Keys - GymBranch

    }
}
