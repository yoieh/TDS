using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private float fireForce = 20f;

        public void Fire()
        {
            GameObject bullet = BulletPoolingManager.SharedInstance.GetBullet();

            bullet.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);

            if (bullet.TryGetComponent(out Bullet bulletBehaviour))
            {
                bulletBehaviour.Shoot();
                bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            }
        }

    }
}