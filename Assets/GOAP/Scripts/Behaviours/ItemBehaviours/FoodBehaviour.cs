using DTS.GOAP;
using UnityEngine;

namespace TDS.GOAP.Behaviours
{
    public class FoodBehaviour : ItemBehaviour
    {
        public float nutritionValue = 50f;

        public override void OnAwake()
        {
            this.itemType = ItemType.Food;
            this.nutritionValue = Random.Range(80f, 150f);
        }
    }
}