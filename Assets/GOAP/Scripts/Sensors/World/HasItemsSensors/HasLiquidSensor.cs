using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using TDS.GOAP.Behaviours;

namespace TDS.GOAP.Sensors.World
{
    public class HasLiquidSensor : LocalWorldSensorBase
    {
        public override void Created()
        {
        }

        public override void Update()
        {
        }

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            var inventory = references.GetCachedComponent<InventoryBehaviour>();

            if (inventory == null)
                return false;

            return inventory.Has<LiquidBehaviour>();
        }
    }
}