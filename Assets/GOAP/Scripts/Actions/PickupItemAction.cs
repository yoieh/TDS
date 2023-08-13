using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using TDS.GOAP.Behaviours;
using UnityEngine;

namespace TDS.GOAP.Actions
{
    public class PickupItemAction : ActionBase<PickupItemAction.Data>
    {
        public override void Created()
        {
        }

        public override void Start(IMonoAgent agent, Data data)
        {
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            if (data.Target is not TransformTarget transformTarget)
            {
                Debug.Log("Target is not TransformTarget on target " + agent.gameObject);
                return ActionRunState.Stop;
            }

            if (transformTarget?.Transform == null)
            {
                Debug.Log("TransformTarget or Transform is null on target " + agent.gameObject);
                return ActionRunState.Stop;
            }


            if (!transformTarget.Transform.TryGetComponent<ItemBehaviour>(out var item))
            {
                Debug.Log("ItemBehaviour not found on target " + agent.gameObject);
                return ActionRunState.Stop;
            }

            // Prevent picking up same item
            if (item.IsPickedUp)
            {
                Debug.Log("Item " + item.gameObject + " is already picked up " + agent.gameObject);
                return ActionRunState.Stop;
            }

            var inventory = agent.GetComponent<InventoryBehaviour>();

            if (inventory == null)
            {
                Debug.Log("InventoryBehaviour not found on agent " + agent.gameObject);
                return ActionRunState.Stop;
            }

            inventory.Add(item);

            return ActionRunState.Stop;
        }

        public override void End(IMonoAgent agent, Data data)
        {
        }

        public class Data : IActionData
        {
            public ITarget Target { get; set; }
        }
    }
}