using System.Collections.Generic;
using System.Linq;
using DTS.GOAP;
using UnityEngine;


namespace TDS.GOAP.Behaviours
{
    public class ItemCollection : MonoBehaviour
    {
        private readonly List<BaseItemBehaviour> items = new();

        private bool IsAvailable(BaseItemBehaviour item) => !item.IsPickedUp || !item.IsClaimed;

        public void Add(BaseItemBehaviour item)
        {
            this.items.Add(item);
        }

        public void Remove(BaseItemBehaviour item)
        {
            this.items.Remove(item);
        }

        public BaseItemBehaviour[] All()
        {
            return this.items.ToArray();
        }

        public BaseItemBehaviour[] AllFiltered()
        {
            return this.items.Where(IsAvailable).ToArray();
        }

        public T[] Get<T>()
            where T : BaseItemBehaviour
        {
            return this.items.Where(x => x is T).Cast<T>().ToArray();
        }

        public bool Any()
        {
            return this.items.Where(IsAvailable).Any();
        }

        public bool Any<t>()
            where t : BaseItemBehaviour
        {
            return this.items.Where(IsAvailable).Any(x => x is t);
        }

        public bool Any(ItemType itemType)
        {
            return this.items.Where(IsAvailable).Any(x => x.itemType == itemType);
        }
    }
}