using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using Unity.Mathematics;
using UnityEngine;

using Random = UnityEngine.Random;

namespace TDS.GOAP.Sensors.Targets
{
    public class WanderTargetSensor : LocalTargetSensorBase
    {
        // Called when the class is created.
        public override void Created()
        {
        }

        // Called each frame. This can be used to gather data from the world before the sense method is called.
        // This can be used to gather 'base data' that is the same for all agents, and otherwise would be performed multiple times during the Sense method.
        public override void Update()
        {
        }

        // Called when the sensor needs to sense a target for a specific agent.
        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            var random = this.GetRandomPosition(agent);

            return new PositionTarget(random);
        }

        private Vector3 GetRandomPosition(IMonoAgent agent)
        {
            var random = Random.insideUnitCircle * 10f;
            var position = agent.transform.position + (Vector3)random;

            //TODO: check if target is reachable...

            return new float3
            {
                x = position.x,
                y = position.y,
                z = .0f
            };
        }
    }
}