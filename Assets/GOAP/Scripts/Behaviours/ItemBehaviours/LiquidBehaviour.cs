using DTS.GOAP;
using UnityEngine;

namespace TDS.GOAP.Behaviours
{
    public class LiquidBehaviour : BaseItemBehaviour
    {
        public float liquidValue = 50f;

        public override void OnAwake()
        {
            this.itemType = ItemType.Liquid;
            this.liquidValue = Random.Range(30f, 100f);
        }
    }
}