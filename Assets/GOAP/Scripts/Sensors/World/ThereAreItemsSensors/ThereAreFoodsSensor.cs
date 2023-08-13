using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Sensors;
using DTS.GOAP;
using TDS.GOAP.Behaviours;
using UnityEngine;

namespace TDS.GOAP.Sensors.World
{
    public class ThereAreFoodsSensor : ThereAreItemsSensor
    {
        public override SenseValue Sense()
        {
            return this.items.Any(ItemType.Food);
        }
    }
}