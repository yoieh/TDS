using DTS.GOAP;
using UnityEngine;

namespace TDS.GOAP.Behaviours
{
    public class BaseItemBehaviour : MonoBehaviour
    {
        public ItemType itemType;

        [field: SerializeField]
        public bool IsPickedUp { get; private set; }

        private ItemCollection itemCollection;

        public virtual void OnAwake()
        {
        }

        private void Awake()
        {
            this.itemCollection = FindObjectOfType<ItemCollection>();
            OnAwake();
        }

        private void OnEnable()
        {
            this.itemCollection.Add(this);
        }

        private void OnDisable()
        {
            this.itemCollection.Remove(this);
        }

        public void PickUp()
        {
            this.IsPickedUp = true;
            this.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }

        public void Drop()
        {
            this.IsPickedUp = false;
            this.itemCollection.Remove(this);
        }
    }
}