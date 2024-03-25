using UnityEngine;

namespace CodeBase.Spray.ColourPicker
{
    public class MaterialExporter : MonoBehaviour
    {
        private const string BlockSprayMaterialPath = "BlockSprayMaterials/BlockSprayMaterialPrefab";

        public static void AddMaterialToReserves(Color colorMaterial)
        {
            Material material = LoadMaterial(BlockSprayMaterialPath);
            if (material != null)
            {
                material.color = colorMaterial;
                BlockSpawner.BlockMaterial =
                    new Material(material); // Клонируем материал для избежания изменения оригинала
            }
            else
            {
                Debug.LogError("Failed to load material at path: " + BlockSprayMaterialPath);
            }
        }

        private static Material LoadMaterial(string path)
        {
            Material loadedMaterial = Resources.Load<Material>(path);
            if (loadedMaterial == null)
            {
                Debug.LogError("Material not found at path: " + path);
            }

            return loadedMaterial;
        }
    }
}