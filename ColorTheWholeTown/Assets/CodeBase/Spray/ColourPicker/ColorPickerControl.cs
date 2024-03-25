using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ColorUtility = UnityEngine.ColorUtility;

namespace CodeBase.Spray.ColourPicker
{
    public class ColorPickerControl : MonoBehaviour
    {
        public float currentHue, currentSat, currentVal;

        [SerializeField] private RawImage _hueImage, _satValImage, _outputImage;

        [SerializeField] private Slider _hueSlider;

        [SerializeField] private TMP_InputField _hexInputField;

        [SerializeField] private MeshRenderer _dempBlock;

        private Texture2D _hueTexture, _svTexture, _outputTexture;

        private void Start()
        {
            CreateHueImage();
            CreateSvImage();
            CreateOutputImage();

            UpdateOutputColorImage();
        }

        private void CreateHueImage()
        {
            _hueTexture = new Texture2D(1, 16);
            _hueTexture.wrapMode = TextureWrapMode.Clamp;
            _hueTexture.name = "HueTexture";

            for (int i = 0; i < _hueTexture.height; i++)
            {
                _hueTexture.SetPixel(0, i, Color.HSVToRGB((float)i / _hueTexture.height, 1, 1));
            }

            _hueTexture.Apply();
            currentHue = 0;

            _hueImage.texture = _hueTexture;
        }

        private void CreateSvImage()
        {
            _svTexture = new Texture2D(16, 16);
            _svTexture.wrapMode = TextureWrapMode.Clamp;
            _svTexture.name = "SVTexture";

            for (int y = 0; y < _svTexture.height; y++)
            {
                for (int x = 0; x < _svTexture.width; x++)
                {
                    _svTexture.SetPixel(x, y,
                        Color.HSVToRGB(currentHue, (float)x / _svTexture.width, (float)y / _svTexture.height));
                }
            }

            _svTexture.Apply();
            currentHue = 0;
            currentVal = 0;

            _satValImage.texture = _svTexture;
        }

        private void CreateOutputImage()
        {
            _outputTexture = new Texture2D(1, 16);
            _outputTexture.wrapMode = TextureWrapMode.Clamp;
            _outputTexture.name = "OutputTexture";

            Color currentColor = Color.HSVToRGB(currentHue, 1, 1);
            for (int i = 0; i < _outputTexture.height; i++)
            {
                _outputTexture.SetPixel(0, i, currentColor);
            }

            _outputTexture.Apply();

            _outputImage.texture = _outputTexture;
        }

        private void UpdateOutputColorImage()
        {
            if (_outputTexture != null && _outputImage != null && _hexInputField != null)
            {
                Color currentColor = Color.HSVToRGB(currentHue, currentSat, currentVal);

                for (int i = 0; i < _outputTexture.height; i++)
                {
                    _outputTexture.SetPixel(0, i, currentColor);
                }

                _outputTexture.Apply();

                _hexInputField.text = ColorUtility.ToHtmlStringRGB(currentColor);

                MaterialExporter.AddMaterialToReserves(currentColor);
                _dempBlock.material.color = currentColor;
            }
            else
            {
                Debug.LogError("One or more required components is null.");
            }
        }


        public void SetSv(float s, float v)
        {
            currentSat = s;
            currentVal = v;

            UpdateOutputColorImage();
        }

        public void UpdateSvImage()
        {
            currentHue = _hueSlider.value;

            for (int y = 0; y < _svTexture.height; y++)
            {
                for (int x = 0; x < _svTexture.width; x++)
                {
                    _svTexture.SetPixel(x, y,
                        Color.HSVToRGB(currentHue, (float)x / _svTexture.width, (float)y / _svTexture.height));
                }
            }

            _svTexture.Apply();

            _satValImage.texture = _svTexture;

            UpdateOutputColorImage();
        }

        public void OnTextInput()
        {
            if (_hexInputField.text.Length < 6)
                return;

            Color newColor;
            if (ColorUtility.TryParseHtmlString("#" + _hexInputField.text, out newColor))
            {
                Color.RGBToHSV(newColor, out currentHue, out currentSat, out currentVal);
            }

            _hueSlider.value = currentHue;
            _hexInputField.text = "";

            UpdateOutputColorImage();
        }
    }
}