using CodeBase.Manager;
using UnityEngine;

namespace CodeBase.UI.ColorPicker
{
    public class ColorPickerPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _colorPickerGameObject;
        [SerializeField] private GameObject _demoBlock;
        public bool isActive;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ToggleColorPicker();
            }
        }

        public void ToggleColorPicker()
        {
            isActive = !isActive;

            _colorPickerGameObject.SetActive(isActive);
            _demoBlock.SetActive(isActive);

            if (isActive)
                PauseManager.OnPauseEvent();
            else
                PauseManager.OnContinueEvent();
        }
    }
}