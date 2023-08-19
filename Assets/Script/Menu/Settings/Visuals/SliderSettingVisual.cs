using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YARG.Settings.Types;

namespace YARG.Menu.Settings.Visuals
{
    public class SliderSettingVisual : BaseSettingVisual<SliderSetting>
    {
        [SerializeField]
        private ValueSlider _slider;

        // Unity sucks -_-
        private bool _ignoreCallback = false;

        protected override void OnSettingInit()
        {
            _ignoreCallback = true;
            _slider.MinimumValue = Setting.Min;
            _slider.MaximumValue = Setting.Max;
            _ignoreCallback = false;

            RefreshVisual();
        }

        public override void RefreshVisual()
        {
            _slider.SetValueWithoutNotify(Setting.Data);
        }

        public void OnValueChange()
        {
            if (_ignoreCallback) return;

            Setting.Data = _slider.Value;
            RefreshVisual();
        }
    }
}