using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FishingTestTask
{
    public class StopScrollingOnLowValues : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.ScrollRect _scrollRect;
        [SerializeField] private float _diffValueForStopping = 0.001f;
        private UnityEngine.UI.Scrollbar _scrollbar;
        private float _prevValue = 0;

        private void Awake() {
            _scrollbar = GetComponent<UnityEngine.UI.Scrollbar>();
        }

        private void OnEnable() {
            _scrollbar.onValueChanged.AddListener(StopScrollingIfValueDiffIsLow);
        }

        public void StopScrollingIfValueDiffIsLow(float _)
        {
            if( Mathf.Abs(_scrollbar.value - _prevValue) < _diffValueForStopping)
            {
                _scrollRect.StopMovement();
            }
            _prevValue = _scrollbar.value;
        }
    }

}
