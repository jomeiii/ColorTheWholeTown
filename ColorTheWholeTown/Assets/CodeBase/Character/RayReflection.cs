using UnityEngine;

namespace CodeBase.Character
{
    public class RayReflection : MonoBehaviour
    {
        public LayerMask layerMask;
        public float range;
        public Transform point;
        public GameObject prefab;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(point.position, point.forward, out hit, range, layerMask))
                {
                    var a = Instantiate(prefab, hit.point, Quaternion.identity);
                    
                    Debug.DrawRay(point.position, point.forward * hit.distance, Color.green, 2);
                }
                else
                {
                    Debug.DrawRay(point.position, point.forward * hit.distance, Color.red, 2);
                }
            }
        }
    }
}