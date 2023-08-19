using System.Collections.Generic;
using System.Linq;
using DTS.GOAP;
using UnityEngine;


namespace TDS.GOAP.Behaviours
{
    public class InventoryBehaviour : MonoBehaviour
    {
        private List<BaseItemBehaviour> items = new();

        public void Add<T>(T item)
            where T : BaseItemBehaviour
        {
            item.PickUp();
            this.items.Add(item);
        }

        public T Drop<T>() where T : BaseItemBehaviour
        {
            BaseItemBehaviour item = this.items.FirstOrDefault(x => x is T);

            if (item == null)
                return null;

            this.items.Remove(item);
            item.Drop();

            return item as T;
        }

        public bool Has<T>()
            where T : BaseItemBehaviour
        {
            return this.items.Any(x => x is T);
        }

        public bool Has(ItemType itemType, int count = 1)
        {
            return this.items.Count(x => x.itemType == itemType) >= count;
        }

        public int Count<T>()
            where T : BaseItemBehaviour
        {
            return this.items.Count(x => x is T);
        }
    }
}