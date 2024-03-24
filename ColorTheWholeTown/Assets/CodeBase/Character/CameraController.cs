using System;
using UnityEngine;

namespace CodeBase.Character
{
    public class CameraController : MonoBehaviour
    {
        [Tooltip("Чувствительность мыши")]
        public float sensitivity = 2.0f; 
        [Tooltip("Максимальный угол вращения по вертикали")]
        public float maxYAngle = 80.0f; 

        private float _rotationX = 0.0f;
        private bool _cursorLocked;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked; // Захватываем курсор
            Cursor.visible = false; // Скрываем курсор
        }

        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");

            transform.parent.Rotate(Vector3.up * (mouseX * sensitivity));

            _rotationX -= mouseY * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, -maxYAngle, maxYAngle);
            transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (_cursorLocked)
                {
                    Cursor.lockState = CursorLockMode.Confined;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }

                _cursorLocked = !_cursorLocked;
            }
        }
    }
}