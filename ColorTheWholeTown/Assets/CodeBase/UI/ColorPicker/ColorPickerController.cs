using CodeBase.Manager;
using UnityEngine;

namespace CodeBase.UI.ColorPicker
{
    public class ColorPickerController : MonoBehaviour
    {
        [SerializeField] private ColorPickerPresenter _colorPickerPresenter;

        private void OnDisable()
        {
            PauseManager.OnContinueEvent();
            _colorPickerPresenter.isActive = false;
        }
    }
}