using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portfolio.FlyController
{
    public class CameraFollow : MonoBehaviour
    {

        public Transform target;
        public Vector3 deafultDistance = new Vector3(0f, 2f, -10f);
        public float distanceDamp = 0.15f;
        public float rotateSpeed = 1f;
        public Vector3 velocity = Vector3.one;

        private float distanceCamera;

        private void Update()
        {
            SetDistance();
        }

        private void LateUpdate()
        {
            SmoothFollow();
            SmoothLookAt();
        }

        private void SetDistance()
        {
            distanceCamera -= Input.GetAxis("Mouse ScrollWheel");
            distanceCamera = Mathf.Clamp(distanceCamera, 5, 30);
            deafultDistance.z = -distanceCamera;
        }

        private void SmoothFollow()
        {
            Vector3 toPosition = target.position + (target.rotation * deafultDistance);
            Vector3 currentPosition = Vector3.SmoothDamp(transform.position, toPosition, ref velocity, distanceDamp);
            transform.position = currentPosition;
        }

        private void SmoothLookAt()
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, rotateSpeed * Time.deltaTime * 15);
        }

        
    }
}
