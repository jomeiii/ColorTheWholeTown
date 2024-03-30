using UnityEngine;

namespace CodeBase.Spray
{
    public class ColorWallController : MonoBehaviour
    {
        public Vector3 forwardVector;

        private void Awake()
        {
            forwardVector = transform.forward;
        }
    }
}