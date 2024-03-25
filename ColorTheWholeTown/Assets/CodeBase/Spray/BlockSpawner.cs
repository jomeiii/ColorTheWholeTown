using CodeBase.Spray.ColourPicker;
using UnityEngine;

namespace CodeBase.Spray
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        public static Material BlockMaterial;
        public static Vector3 BlockSize;

        private void Awake()
        {
            MaterialExporter.AddMaterialToReserves(Color.black);
            BlockSize = _prefab.GetComponent<Transform>().localScale;
        }

        public void SpawnBlock(Vector3 position)
        {
            GameObject sprayBlock = Instantiate(_prefab, position, Quaternion.identity);

            sprayBlock.AddComponent<SprayBlock>();

            sprayBlock.GetComponent<MeshRenderer>().material = BlockMaterial;

            // TODO: Переделать под правильный выбор ширины спрея
            sprayBlock.GetComponent<Transform>().localScale = BlockSize;
        }
    }
}