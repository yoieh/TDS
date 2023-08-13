using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using TDS.GOAP.Behaviours;
using UnityEngine;

namespace TDS.GOAP.Actions
{
    public class BandageWoundAction : ActionBase<BandageWoundAction.Data>
    {
        public override void Created()
        {
        }

        public override void Start(IMonoAgent agent, Data data)
        {
            var inventory = agent.GetComponent<InventoryBehaviour>();

            if (inventory == null)
                return;

            data.Bandage = inventory.Drop<BandageBehaviour>();
            data.Health = agent.GetComponent<HealthBehavior>();
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            if (data.Bandage == null || data.Health == null)
                return ActionRunState.Stop;

            var bandageWound = context.DeltaTime * 20f;

            data.Bandage.healingValue -= bandageWound;
            data.Health.bleeding -= bandageWound;

            if (data.Bandage.healingValue <= 0)
                GameObject.Destroy(data.Bandage.gameObject);

            return ActionRunState.Continue;
        }

        public override void End(IMonoAgent agent, Data data)
        {
            if (data.Bandage == null)
                return;

            var inventory = agent.GetComponent<InventoryBehaviour>();

            if (inventory == null)
                return;

            inventory.Add(data.Bandage);
        }

        public class Data : IActionData
        {
            public ITarget Target { get; set; }
            public BandageBehaviour Bandage { get; set; }
            public HealthBehavior Health { get; set; }
        }
    }
}