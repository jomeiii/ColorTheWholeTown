using CodeBase.Spray.ColourPicker;
using UnityEngine;

namespace CodeBase.Spray
{
    public class BlockSpawner : MonoBehaviour
    {
        private const float BlockWidth = 0.002f;

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
            GameObject sprayBlock = Instantiate(_prefab, hitPoint, GetBlockRotation(pointTransform));
            sprayBlock.GetComponent<MeshRenderer>().material = BlockMaterial;
            sprayBlock.AddComponent<SprayBlock>();

            SetBlockScale(sprayBlock.transform);
        }

        private Quaternion GetBlockRotation(Transform pointTransform)
        {
            var sideController = pointTransform.GetComponentInParent<SideController>();

            if (IsTransformPartOfSide(sideController.sideX, pointTransform))
                return Quaternion.Euler(90, 0, 0);
            if (IsTransformPartOfSide(sideController.sideY, pointTransform))
                return Quaternion.Euler(0, 0, 90);
            if (IsTransformPartOfSide(sideController.sideZ, pointTransform))
                return Quaternion.Euler(0, 90, 0);

            return Quaternion.identity;
        }

        private bool IsTransformPartOfSide(Transform[] side, Transform pointTransform)
        {
            return side[0] == pointTransform || side[1] == pointTransform;
        }

        private void SetBlockScale(Transform transform)
        {
            Vector3 scale = BlockSize;
            scale.x = BlockWidth;
            transform.localScale = scale;
        }
    }
}