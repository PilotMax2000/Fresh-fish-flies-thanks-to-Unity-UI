using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace FishingTestTask
{
    public class StatsPanel : MonoBehaviour
    {

        [SerializeField] private Transform _rodParent;
        [SerializeField] private RodModelsDB _rodModelsDB;
        [SerializeField] private RodModelData _currentRodModelData;

        [Header("Rod Slot elements")]
        [SerializeField] private GameObject _arrowBadge;
        [SerializeField] private Image _rarityLevelBadgeImage;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _rodTypeTitleText;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _expText;
        [SerializeField] private Bar _bar;

        [Header("Rarity Level Badge Sprites")]
        [SerializeField] private Sprite[] _rarityLevelBadges;
        [Header("Rod Types")]
        [SerializeField] private RodTypeTitle[] _rodTypesTitles;

        private Dictionary<int, GameObject> _modelsCache = new Dictionary<int, GameObject>();
        public System.Action DisablePreviousSlot = delegate {};
        public static StatsPanel Instans;

        private void Awake()
        {
            if (Instans == null)
            {
                Instans = this;
            }
        }

        public void SetupPanel(RodData data, LevelInfo levelInfo)
        {
            DisablePreviousSlot();
            ShowRodModel(data.RodModelID);
            SetupPanelStats(data, levelInfo);
        }

        private void SetupPanelStats(RodData data, LevelInfo levelInfo)
        {
            _nameText.text = data.RodName;
            _rodTypeTitleText.text = GetRodTypeTitle(data.Type);
            _rarityLevelBadgeImage.sprite = _rarityLevelBadges[(int)data.Rarity];

            _levelText.text = levelInfo.Level.ToString();
            _expText.text = String.Format("{0}/{1}", levelInfo.CurrentExp, levelInfo.ExpToNextLevel);
            _arrowBadge.SetActive(levelInfo.CurrentExp >= levelInfo.ExpToNextLevel);
            _bar.SetBarValue(levelInfo.CurrentExp, levelInfo.ExpToNextLevel);
        }

        private void ShowRodModel(int id)
        {
            if (_currentRodModelData != null)
            {
                if (_currentRodModelData.ID == id)
                {
                    return;
                }
                else
                {
                    _currentRodModelData.RodPrefab.SetActive(false);
                }
            }

            if (_modelsCache.Count > 0)
            {
                GameObject rodModelFromCache;
                _modelsCache.TryGetValue(id, out rodModelFromCache);

                if (rodModelFromCache != null)
                {
                    rodModelFromCache.SetActive(true);
                    _currentRodModelData = Instantiate(GetRodModelDataFromDB(id));
                    //Link to current instance
                    _currentRodModelData.RodPrefab = rodModelFromCache;
                    return;
                }
            }

            RodModelData rodModelData =  GetRodModelDataFromDB(id);
            if(rodModelData != null)
            {
                GameObject rodModel = Instantiate(rodModelData.RodPrefab, _rodParent);
                rodModel.SetActive(true);
                _modelsCache.Add(id, rodModel);
                //Link to current instance
                _currentRodModelData = Instantiate(rodModelData);
                _currentRodModelData.RodPrefab = rodModel;
            }
        }

        private string GetRodTypeTitle(RodType rodTypeToSearch)
        {
            string res = "";
            for(int i=0; i < _rodTypesTitles.Length; i++)
            {
                if(_rodTypesTitles[i].Type == rodTypeToSearch)
                {
                    res = _rodTypesTitles[i].Title;
                    break;
                }
            }
            return res;
        }

        private RodModelData GetRodModelDataFromDB(int id)
        {
            for (int i = 0; i < _rodModelsDB.ModelsDB.Length; i++)
            {
                if(_rodModelsDB.ModelsDB[i].ID == id)
                {
                    return _rodModelsDB.ModelsDB[i];
                }
            }

            Debug.LogWarning("Rod Model with id: " + id + " was not found in DB!");
            return null;
        }
    }

    [Serializable]
    public class RodTypeTitle
    {
        public RodType Type;
        public string Title;
    }
}
