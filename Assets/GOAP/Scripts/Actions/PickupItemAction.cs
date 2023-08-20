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
            if (data.Target is not TransformTarget transformTarget || transformTarget?.Transform == null)
            {
                return;
            }

            if (!transformTarget.Transform.TryGetComponent<BaseItemBehaviour>(out var item))
            {
                return;
            }

            if (item.IsPickedUp || item.IsClaimed)
            {
                Debug.Log("Item " + item.gameObject + " is already picked up or claimed " + agent.gameObject);
                return;
            }

            item.Claim();
            data.Item = item;
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            if (data.Target is not TransformTarget transformTarget || transformTarget?.Transform == null)
            {
                return ActionRunState.Stop;
            }

            if (!transformTarget.Transform.TryGetComponent<BaseItemBehaviour>(out var item))
            {
                return ActionRunState.Stop;
            }

            // Prevent picking up same item
            if (item.IsPickedUp)
            {
                return ActionRunState.Stop;
            }

            var inventory = agent.GetComponent<InventoryBehaviour>();

            if (inventory == null)
            {
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

            public BaseItemBehaviour Item { get; set; }
        }
    }
}