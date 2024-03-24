using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.ColourPicker
{
    public class SvImageControl : MonoBehaviour
    {
        [SerializeField] private Image _pickerImage;
        private RawImage _SVImage;
        private ColorPickerControl _colorPickerControl;
        private RectTransform _rectTransform, _pickerTransform;

        private void Awake()
        {
            _SVImage = GetComponent<RawImage>();
            _colorPickerControl = FindObjectOfType<ColorPickerControl>();
            _rectTransform = GetComponent<RectTransform>();

            _pickerTransform = _pickerImage.GetComponent<RectTransform>();
            _pickerTransform.localPosition =
                new Vector2(-(_rectTransform.sizeDelta.x / 2), -(_rectTransform.sizeDelta.y / 2));
        }

        private void Update()
        {
            if (Input.GetMouseButton(0) &&
                RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, Input.mousePosition, Camera.main))
            {
                UpdateColor();
            }
        }

        private void UpdateColor()
        {
            Vector2 pos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform,
                Input.mousePosition,
                Camera.main, out pos);

            float deltaX = _rectTransform.sizeDelta.x / 2;
            float deltaY = _rectTransform.sizeDelta.y / 2;

            float xNorm = (pos.x + deltaX) / _rectTransform.sizeDelta.x;
            float yNorm = (pos.y + deltaY) / _rectTransform.sizeDelta.y;

            _pickerTransform.localPosition = pos;

            _colorPickerControl.SetSv(xNorm, yNorm);
        }
    }
}