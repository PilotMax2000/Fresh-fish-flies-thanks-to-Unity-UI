using UnityEngine;

namespace FishingTestTask
{
    public class Bar : MonoBehaviour
    {

        [SerializeField] private UnityEngine.UI.Image _bar;

        private void Awake()
        {
            _bar = GetComponent<UnityEngine.UI.Image>();
        }

        public void SetBarValue(float currentValue, float maxValue)
        {
            _bar.fillAmount = currentValue / maxValue;
        }
    }

}
