using CodeBase.Manager;
using UnityEngine;

namespace CodeBase.Character
{
    public class CameraController : MonoBehaviour
    {
        [Tooltip("Направление взгляда по осям x, y и z")]
        public static Vector3 ForwardVector;

        [Tooltip("Чувствительность мыши")] 
        public float sensitivity = 2.0f;

        [Tooltip("Максимальный угол вращения по вертикали")]
        public float maxYAngle = 80.0f;

        private float _rotationX = 0.0f;

        private void Update()
        {
            if (!PauseManager.IsPause)
            {
                RotateCamera();
                SetForwardVector();
            }
        }

        private void RotateCamera()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.parent.Rotate(Vector3.up, mouseX * sensitivity);

            _rotationX -= mouseY * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, -maxYAngle, maxYAngle);
            transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
        }

        private static void SetForwardVector()
        {
            Vector3 cameraForward = Vector3.zero;
            if (Camera.main != null)
            {
                cameraForward = Camera.main.transform.forward;
            }

            // Находим наибольший компонент вектора направления
            float maxComponent = Mathf.Max(Mathf.Abs(cameraForward.x), Mathf.Abs(cameraForward.y), Mathf.Abs(cameraForward.z));

            // Устанавливаем ForwardVector в направлении наибольшего компонента
            ForwardVector = Vector3.zero;
            if (Mathf.Abs(cameraForward.x) == maxComponent)
                ForwardVector.x = Mathf.Sign(cameraForward.x);
            else if (Mathf.Abs(cameraForward.y) == maxComponent)
                ForwardVector.y = Mathf.Sign(cameraForward.y);
            else if (Mathf.Abs(cameraForward.z) == maxComponent)
                ForwardVector.z = Mathf.Sign(cameraForward.z);
            
            // Debug.Log(ForwardVector);
        }
    }
}
