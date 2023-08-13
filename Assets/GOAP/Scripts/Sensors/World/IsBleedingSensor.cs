using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using TDS.GOAP.Behaviours;

namespace TDS.GOAP.Sensors.World
{
    public class IsBleedingSensor : LocalWorldSensorBase
    {
        public override void Created()
        {
        }

        public override void Update()
        {
        }

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            var healthBehaviour = references.GetCachedComponent<HealthBehavior>();

            if (healthBehaviour == null)
                return false;

            return healthBehaviour.bleeding > 0;
        }
    }
}