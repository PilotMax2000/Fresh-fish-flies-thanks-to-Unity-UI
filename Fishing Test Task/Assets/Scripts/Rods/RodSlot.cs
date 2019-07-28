using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FishingTestTask
{
    public class RodSlot : MonoBehaviour
    {
        [SerializeField] private RodData _data;
        [SerializeField] private bool _isRodSelected;
        [Header("Slot elements")]
        [SerializeField] private GameObject _isRodSelectedBadge;
        [SerializeField] private GameObject _arrowBadge;
        [SerializeField] private Image _rodIconImage;
        [SerializeField] private Image _rarityBGImage;
        [SerializeField] private Image _rarityLevelBadgeImage;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _expText;
        [SerializeField] private Bar _bar;

        // Use this for initialization
        [Header("Rarity BG Sprites")]
        [SerializeField] private Sprite[] _rarityBGs;

        [Header("Rarity Level Badge Sprites")]
        [SerializeField] private Sprite[] _rarityLevelBadges;

        private LevelInfo _levelInfo;

        public void SetupSlot(RodData data)
        {
            _data = data;
            _nameText.text = data.RodName;
            _rodIconImage.sprite = data.Icon;
            _rarityBGImage.sprite = _rarityBGs[(int)data.Rarity];
            _rarityLevelBadgeImage.sprite = _rarityLevelBadges[(int)data.Rarity];

            _levelInfo = new LevelInfo(UnityEngine.Random.Range(1,10), UnityEngine.Random.Range(0,10));

            _levelText.text = _levelInfo.Level.ToString();
            _expText.text = String.Format("{0}/{1}", _levelInfo.CurrentExp, _levelInfo.ExpToNextLevel);
            _arrowBadge.SetActive(_levelInfo.CurrentExp >= _levelInfo.ExpToNextLevel);
            _bar.SetBarValue(_levelInfo.CurrentExp, _levelInfo.ExpToNextLevel);
        }

        public void SelectRod()
        {
            StatsPanel.Instans.SetupPanel(_data, _levelInfo);
            StatsPanel.Instans.DisablePreviousSlot += DisabelSelectedSlot;
            _isRodSelectedBadge.SetActive(true);
        }

        private void DisabelSelectedSlot()
        {
            _isRodSelectedBadge.SetActive(false);
            StatsPanel.Instans.DisablePreviousSlot -= DisabelSelectedSlot;
        }
    }

    



}

