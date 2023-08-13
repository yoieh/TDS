using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Weapon weapon;

        Vector2 moveDirection;
        Vector2 mousePosition;

        // Update is called once per frame
        void Update()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if (Input.GetMouseButtonDown(0))
            {
                weapon.Fire();
            }

            moveDirection = new Vector2(moveX, moveY).normalized;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
        }
    }
}