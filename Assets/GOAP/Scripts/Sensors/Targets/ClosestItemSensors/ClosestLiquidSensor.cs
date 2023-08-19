using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using DTS.GOAP;
using TDS.GOAP.Behaviours;
using UnityEngine;


namespace TDS.GOAP.Sensors.Targets
{
    public class ClosestLiquidSensor : ClosestItemSensor
    {
        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            var closestItem = this.items.AllFiltered().Closest(agent.transform.position, ItemType.Liquid);

            if (closestItem == null)
                return null;

            return new TransformTarget(closestItem.transform);
        }
    }
}