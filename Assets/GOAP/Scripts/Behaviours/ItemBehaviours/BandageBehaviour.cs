using DTS.GOAP;
using UnityEngine;

namespace TDS.GOAP.Behaviours
{
    public class BandageBehaviour : BaseItemBehaviour
    {
        public float healingValue = 50f;

        public override void OnAwake()
        {
            this.itemType = ItemType.Bandage;
            this.healingValue = Random.Range(30f, 80f);
        }
    }
}