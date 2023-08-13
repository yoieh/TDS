using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using TDS.GOAP.Behaviours;
using UnityEngine;


namespace TDS.GOAP.Actions
{
    public class EatFoodAction : ActionBase<EatFoodAction.Data>
    {
        public override void Created()
        {
        }

        public override void Start(IMonoAgent agent, Data data)
        {
            var inventory = agent.GetComponent<InventoryBehaviour>();

            if (inventory == null)
                return;

            data.Food = inventory.Drop<FoodBehaviour>();
            data.Health = agent.GetComponent<HealthBehavior>();
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            if (data.Food == null || data.Health == null)
                return ActionRunState.Stop;

            var eatNutrition = context.DeltaTime * 20f;

            data.Food.nutritionValue -= eatNutrition;
            data.Health.hunger -= eatNutrition;

            if (data.Food.nutritionValue <= 0)
                GameObject.Destroy(data.Food.gameObject);

            return ActionRunState.Continue;
        }

        public override void End(IMonoAgent agent, Data data)
        {
            if (data.Food == null)
                return;

            var inventory = agent.GetComponent<InventoryBehaviour>();

            if (inventory == null)
                return;

            inventory.Add(data.Food);
        }

        public class Data : IActionData
        {
            public ITarget Target { get; set; }
            public FoodBehaviour Food { get; set; }
            public HealthBehavior Health { get; set; }
        }
    }
}