using System.Collections;
using System.Collections.Generic;
using TDS.GOAP.Behaviours;
using UnityEngine;

namespace TDS
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime = 1f;

        public void Shoot()
        {
            gameObject.SetActive(true);
            StartCoroutine(DeactivateAfterTime());
        }

        private IEnumerator DeactivateAfterTime()
        {
            yield return new WaitForSeconds(lifeTime);

            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out HealthBehavior healthBehaviour))
            {
                float damage = Random.Range(10f, 30f);
                healthBehaviour.TakeDamage(damage, .8f);
            }

            gameObject.SetActive(false);
        }
    }
}