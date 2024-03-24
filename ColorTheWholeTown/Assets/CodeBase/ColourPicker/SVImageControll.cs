using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.ColourPicker
{
    public class SvImageControl : MonoBehaviour
    {
        public event Action pickerPositionChangedEvent;
        
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

            if (pos.x > deltaX) pos.x = deltaX;
            else if (pos.x < -deltaY) pos.x = -deltaY;
            if (pos.y > deltaY) pos.y = deltaY;
            else if (pos.y < -deltaY) pos.y = -deltaY;

            float x = pos.x + deltaX;
            float y = pos.y + deltaY;

            float xNorm = x / _rectTransform.sizeDelta.x;
            float yNorm = y / _rectTransform.sizeDelta.y;

            _pickerTransform.localPosition = pos;

            _colorPickerControl.SetSv(xNorm, yNorm);
        }

        public void UpdatePickerPos(Vector3 newPos)
        {
            _pickerTransform.localPosition = newPos;
        }
    }
}