using CodeBase.Manager;
using UnityEngine;

namespace CodeBase.Character
{
    public class CameraController : MonoBehaviour
    {
        [Tooltip("Чувствительность мыши")] public float sensitivity = 2.0f;

        [Tooltip("Максимальный угол вращения по вертикали")]
        public float maxYAngle = 80.0f;

        private float _rotationX = 0.0f;

        private void Update()
        {
            if (!PauseManager.IsPause)
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                transform.parent.Rotate(Vector3.up, mouseX * sensitivity);

                _rotationX -= mouseY * sensitivity;
                _rotationX = Mathf.Clamp(_rotationX, -maxYAngle, maxYAngle);
                transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
            }
        }
    }
}