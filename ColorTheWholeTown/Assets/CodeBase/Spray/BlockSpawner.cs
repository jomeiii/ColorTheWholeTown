using CodeBase.Spray.ColourPicker;
using UnityEngine;

namespace CodeBase.Spray
{
    public class BlockSpawner : MonoBehaviour
    {
        private const float BlockWidth = 0.2f;

        [SerializeField] private GameObject _prefab;
        public static Material BlockMaterial;
        public static Vector3 BlockSize;

        private void Start()
        {
            MaterialExporter.AddMaterialToReserves(Color.black);
            BlockSize = _prefab.transform.localScale;
        }

        public void SpawnBlock(Transform pointTransform, Vector3 hitPoint)
        {
            GameObject sprayBlock = Instantiate(_prefab, hitPoint, Quaternion.identity);

            Vector3 a = hitPoint - Camera.main.transform.position;

            Vector3 b = hitPoint - pointTransform.position;

            Vector3 c = hitPoint + (b - a);

            sprayBlock.transform.LookAt(c);

            Vector3 scale = new Vector3(BlockWidth, BlockSize.y, BlockSize.z);
            sprayBlock.transform.localScale = scale;

            sprayBlock.GetComponent<MeshRenderer>().material = BlockMaterial;
            sprayBlock.AddComponent<SprayBlock>();
        }
    }
}