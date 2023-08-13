using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class BulletPoolingManager : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private int bulletPoolSize = 10;
        public static BulletPoolingManager SharedInstance;

        private List<GameObject> bullets;

        void Awake()
        {
            SharedInstance = this;
        }
 
        // Start is called before the first frame update
        void Start()
        {
            bullets = new List<GameObject>();
            for (int i = 0; i < bulletPoolSize; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.SetActive(false);
                bullets.Add(bullet);
            }
        }

        public GameObject GetBullet()
        {
            foreach (GameObject bullet in bullets)
            {
                if (!bullet.activeInHierarchy)
                {
                    return bullet;
                }
            }

            GameObject newBullet = Instantiate(bulletPrefab);
            bullets.Add(newBullet);
            return newBullet;
        }
    }
}
