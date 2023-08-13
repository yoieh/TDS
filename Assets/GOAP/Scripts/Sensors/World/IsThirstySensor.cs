using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using TDS.GOAP.Behaviours;

namespace TDS.GOAP.Sensors.World
{
    public class IsThirstySensor : LocalWorldSensorBase
    {
        public override void Created()
        {
        }

        public override void Update()
        {
        }

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            var hungerBehaviour = references.GetCachedComponent<HealthBehavior>();

            if (hungerBehaviour == null)
                return false;

            return hungerBehaviour.thirst > 20f;
        }
    }
}