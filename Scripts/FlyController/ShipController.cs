using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portfolio.FlyController
{

    public class ShipController : MonoBehaviour
    {
        public ShipControllerScriptable shipControllerScriptable;

        private float currentForwardSpeed, currentStrafeSpeed, currentHoverSpeed;

        private Vector2 loockInput, screenCenter, mouseDistance;

        private float rollInput;

        private void Start()
        {
            screenCenter.x = Screen.width * .5f;
            screenCenter.y = Screen.height * .5f;

            Cursor.lockState = CursorLockMode.Confined;
        }

        void Update()
        {
            SetInputs();
            Movment();
            Roll();
            if (IsMouseLook()) {
                MouseLook();
            }
            else
            {
                SlowDownMouseLook();
            }
        }

        private bool IsMouseLook()
        {
            return Input.GetButton("Fire2");
        }

        private bool IsCorrectSpeed()
        {
            return (currentForwardSpeed >= 5f || currentStrafeSpeed >= 5f || currentHoverSpeed >= 5f) || (currentForwardSpeed <= -5f || currentStrafeSpeed <= -5f || currentHoverSpeed <= -5f);
        }

        private void SetInputs()
        {
            currentForwardSpeed = Mathf.Lerp(currentForwardSpeed, Input.GetAxisRaw("Vertical") * shipControllerScriptable.forwardSpeed, shipControllerScriptable.forwardAcceleration * Time.deltaTime);
            currentStrafeSpeed = Mathf.Lerp(currentStrafeSpeed, Input.GetAxisRaw("Horizontal") * shipControllerScriptable.strafeSpeed, shipControllerScriptable.strafeAcceleration * Time.deltaTime);
            currentHoverSpeed = Mathf.Lerp(currentHoverSpeed, Input.GetAxisRaw("Hover") * shipControllerScriptable.hoverSpeed, shipControllerScriptable.hoverAcceleration * Time.deltaTime);
        }

        private void Movment()
        {
            transform.position += transform.forward * currentForwardSpeed * Time.deltaTime;
            transform.position += (transform.right * currentStrafeSpeed * Time.deltaTime) + (transform.up * currentHoverSpeed * Time.deltaTime);
        }

        private void MouseLook()
        {
            loockInput.x = Input.mousePosition.x;
            loockInput.y = Input.mousePosition.y;

            mouseDistance.x = (loockInput.x - screenCenter.x) / screenCenter.x;
            mouseDistance.y = (loockInput.y - screenCenter.y) / screenCenter.y;

            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        }

        private void SlowDownMouseLook()
        {
            if (mouseDistance.x != 0)
            {
                if (mouseDistance.x < 0f) mouseDistance.x = Mathf.Lerp(mouseDistance.x, 0f, shipControllerScriptable.lookSlowdownSpeed * Time.deltaTime);
                if (mouseDistance.x > 0f) mouseDistance.x = Mathf.Lerp(mouseDistance.x, 0f, shipControllerScriptable.lookSlowdownSpeed * Time.deltaTime);
            }

            if (mouseDistance.y != 0)
            {
                if (mouseDistance.y < 0f) mouseDistance.y = Mathf.Lerp(mouseDistance.y, 0f, shipControllerScriptable.lookSlowdownSpeed * Time.deltaTime);
                if (mouseDistance.y > 0f) mouseDistance.y = Mathf.Lerp(mouseDistance.y, 0f, shipControllerScriptable.lookSlowdownSpeed * Time.deltaTime);
            }
        }

        private void Roll()
        {
            transform.Rotate(-mouseDistance.y * shipControllerScriptable.lookRateSpeed * Time.deltaTime, mouseDistance.x * shipControllerScriptable.lookRateSpeed * Time.deltaTime, rollInput * shipControllerScriptable.rollSpeed * Time.deltaTime, Space.Self);
            rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), shipControllerScriptable.rollAcceleration * Time.deltaTime);
        }
    }
}