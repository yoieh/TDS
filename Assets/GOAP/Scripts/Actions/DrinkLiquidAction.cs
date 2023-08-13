using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using TDS.GOAP.Behaviours;
using UnityEngine;

namespace TDS.GOAP.Actions
{
    public class DrinkLiquidAction : ActionBase<DrinkLiquidAction.Data>
    {
        public override void Created()
        {
        }

        public override void Start(IMonoAgent agent, Data data)
        {
            var inventory = agent.GetComponent<InventoryBehaviour>();

            if (inventory == null)
                return;

            data.Liquid = inventory.Drop<LiquidBehaviour>();
            data.Health = agent.GetComponent<HealthBehavior>();
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            if (data.Liquid == null || data.Health == null)
                return ActionRunState.Stop;

            var drinkLiquid = context.DeltaTime * 20f;

            data.Liquid.liquidValue -= drinkLiquid;
            data.Health.thirst -= drinkLiquid;

            if (data.Liquid.liquidValue <= 0)
                GameObject.Destroy(data.Liquid.gameObject);

            return ActionRunState.Continue;
        }

        public override void End(IMonoAgent agent, Data data)
        {
            if (data.Liquid == null)
                return;

            var inventory = agent.GetComponent<InventoryBehaviour>();

            if (inventory == null)
                return;

            inventory.Add(data.Liquid);
        }

        public class Data : IActionData
        {
            public ITarget Target { get; set; }
            public LiquidBehaviour Liquid { get; set; }
            public HealthBehavior Health { get; set; }
        }
    }
}