using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Sensors;
using DTS.GOAP;
using TDS.GOAP.Behaviours;
using UnityEngine;

namespace TDS.GOAP.Sensors.World
{
    public class ThereAreItemsSensor : GlobalWorldSensorBase
    {
        protected ItemCollection items;

        public override void Created()
        {
            this.items = GameObject.FindObjectOfType<ItemCollection>();
        }

        public override SenseValue Sense()
        {
            return this.items.Any();
        }
    }
}