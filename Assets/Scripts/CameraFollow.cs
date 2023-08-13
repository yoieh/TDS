using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;

        [SerializeField] private float maxZoom = 5f;
        [SerializeField] private float minZoom = 10f;

        // Update is called once per frame
        void Update()
        {
            if (target == null)
                return;
                
            Vector3 desiredPosition = target.position;
            transform.position = desiredPosition + new Vector3(0, 0, -10);

            // zoom in and out on scroll
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scroll, maxZoom, minZoom);
        }
    }
}