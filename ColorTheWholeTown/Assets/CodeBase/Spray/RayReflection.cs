using CodeBase.Manager;
using UnityEngine;

namespace CodeBase.Spray
{
    public class RayReflection : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _range = 5;
        [SerializeField] private Transform _point;
        [SerializeField] private BlockSpawner _blockSpawner;

        private void Awake()
        {
            if (_blockSpawner == null) 
                _blockSpawner = GetComponent<BlockSpawner>();
        }

        private void Update()
        {
            if (!PauseManager.IsPause)
            {
                // Левая кнопка мыши
                if (Input.GetMouseButton(0))
                    Spawn();
                // Правая кнопка мыши
                else if (Input.GetMouseButton(1))
                    Delete();
            }
        }

        private void Spawn()
        {
            RaycastHit hit;

            if (Physics.Raycast(_point.position, _point.forward, out hit, _range, _layerMask))
            {
                _blockSpawner.SpawnBlock(hit.transform, hit.point);
                Debug.DrawRay(_point.position, _point.forward * hit.distance, Color.green, 2);
            }
        }

        private void Delete()
        {
            RaycastHit hit;

            if (Physics.Raycast(_point.position, _point.forward, out hit, _range))
            {
                Debug.DrawRay(_point.position, _point.forward * hit.distance, Color.red, 2);

                if (hit.collider.GetComponent<SprayBlock>() != null)
                    Destroy(hit.collider.gameObject);
            }
        }
    }
}