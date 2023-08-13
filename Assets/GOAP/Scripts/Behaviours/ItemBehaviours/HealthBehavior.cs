using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.GOAP.Behaviours
{
    public class HealthBehavior : MonoBehaviour
    {
        public float health = 100f;
        public float blood = 100f;
        public float bleeding = 0f;

        public float hunger = 50;
        public float thirst = 50;

        private void Awake()
        {
            this.health = Random.Range(0, 100f);
            this.hunger = Random.Range(0, 100f);
        }

        private void Update()
        {
            if (this.health <= 0)
            {
                this.Die();
            }
        }

        private void FixedUpdate()
        {
            float fixedDeltaTime = Time.fixedDeltaTime;

            this.hunger += fixedDeltaTime * 2f;
            this.thirst += fixedDeltaTime * 2f;

            if (this.bleeding > 0f)
            {
                this.blood -= fixedDeltaTime * this.bleeding;

                this.bleeding -= fixedDeltaTime * .03f;
            }

            if (this.hunger > 100f || this.thirst > 100f || this.blood < 10f)
            {
                // this.health -= fixedDeltaTime * 2f;
            }

            this.hunger = this.hunger > 100f ? 100f : this.hunger;
            this.hunger = this.hunger < 0f ? 0f : this.hunger;

            this.thirst = this.thirst > 100f ? 100f : this.thirst;
            this.thirst = this.thirst < 0f ? 0f : this.thirst;

            this.blood = this.blood < 0f ? 0f : this.blood;
            this.blood = this.blood > 100f ? 100f : this.blood;

            this.bleeding = this.bleeding < 0f ? 0f : this.bleeding;
            this.bleeding = this.bleeding > 100f ? 100f : this.bleeding;

            this.health = this.health < 0f ? 0f : this.health;
            this.health = this.health > 100f ? 100f : this.health;
        }

        public void TakeDamage(float damage, float chanceToBleed = 0f)
        {
            if (Random.Range(0f, 1f) < chanceToBleed)
            {
                this.bleeding += damage * 0.1f;
            }

            this.health -= damage;
        }

        public void Die()
        {
            Destroy(this.gameObject);
        }
    }
}
