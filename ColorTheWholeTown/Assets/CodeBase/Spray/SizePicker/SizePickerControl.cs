﻿using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Spray.SizePicker
{
    public class SizePickerControl : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Transform _demoBlock;

        private void OnEnable()
        {
            _slider.value = BlockSpawner.BlockSize.x;
            _demoBlock.localScale = BlockSpawner.BlockSize;
        }

        public void OnValueChanged()
        {
            // TODO: Переделать под правильный выбор ширины спрея
            Vector3 scale = _demoBlock.localScale;
            scale.x = _slider.value;
            scale.y = _slider.value;
            scale.z = _slider.value;
            _demoBlock.localScale = scale;

            BlockSpawner.BlockSize = scale;
        }
    }
}