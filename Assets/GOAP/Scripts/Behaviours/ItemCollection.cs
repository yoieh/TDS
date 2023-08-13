using System.Collections.Generic;
using System.Linq;
using DTS.GOAP;
using UnityEngine;


namespace TDS.GOAP.Behaviours
{
    public class ItemCollection : MonoBehaviour
    {
        private readonly List<ItemBehaviour> items = new();

        public void Add(ItemBehaviour item)
        {
            this.items.Add(item);
        }

        public void Remove(ItemBehaviour item)
        {
            this.items.Remove(item);
        }

        public ItemBehaviour[] All()
        {
            return this.items.ToArray();
        }

        public T[] Get<T>()
            where T : ItemBehaviour
        {
            return this.items.Where(x => x is T).Cast<T>().ToArray();
        }

        public bool Any()
        {
            return this.items.Any();
        }

        public bool Any<t>()
            where t : ItemBehaviour
        {
            return this.items.Any(x => x is t);
        }

        public bool Any(ItemType itemType)
        {
            return this.items.Any(x => x.itemType == itemType);
        }
    }
}