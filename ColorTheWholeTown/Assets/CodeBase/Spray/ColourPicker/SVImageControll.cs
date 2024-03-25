using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Spray.ColourPicker
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

            if (_colorPickerControl == null) Debug.LogError("Error");
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 pos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform,
                    Input.mousePosition, null, out pos);

                if (_rectTransform.rect.Contains(pos))
                {
                    UpdateColor(pos);
                }
            }
        }

        private void UpdateColor(Vector2 localCursorPos)
        {
            float deltaX = _rectTransform.sizeDelta.x / 2;
            float deltaY = _rectTransform.sizeDelta.y / 2;

            float xNorm = (localCursorPos.x + deltaX) / _rectTransform.sizeDelta.x;
            float yNorm = (localCursorPos.y + deltaY) / _rectTransform.sizeDelta.y;

            _pickerTransform.localPosition = localCursorPos;

            _colorPickerControl.SetSv(xNorm, yNorm);
        }
    }
}