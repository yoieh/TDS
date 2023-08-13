using System.Collections.Generic;
using System.Linq;
using TDS.GOAP.Behaviours;
using UnityEngine;

namespace DTS.GOAP
{
    public enum ItemType
    {
        Other = default,
        Food,
        Liquid,
        Bandage,
        Weapon,
        Tool,
    }

    public static class Extensions
    {
        public static ItemBehaviour Closest(this IEnumerable<ItemBehaviour> items, Vector3 position, ItemType itemType)
        {
            return items
                .OrderBy(x => Vector3.Distance(x.transform.position, position))
                .Where(x => x.itemType == itemType)
                .FirstOrDefault();
        }

        public static T Closest<T>(this IEnumerable<T> items, Vector3 position, ItemType itemType)
            where T : MonoBehaviour
        {
            return items
                .OrderBy(x => Vector3.Distance(x.transform.position, position))
                .Where(x => x.GetComponent<ItemBehaviour>().itemType == itemType)
                .FirstOrDefault();
        }
    }
}