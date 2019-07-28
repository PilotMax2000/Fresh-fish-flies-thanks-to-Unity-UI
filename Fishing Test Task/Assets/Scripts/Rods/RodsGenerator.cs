using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FishingTestTask
{
    public class RodsGenerator : MonoBehaviour
    {
        [SerializeField] [Range(1, 100)] int _numberOfSlots = 1;
        [SerializeField] private RodsDataDB _rodsDataDB;
        [SerializeField] private GameObject _rodSlotPrefab;
        [Header("Spinning group")]
        [SerializeField] private GameObject _spinningGroup;
        [SerializeField] private GameObject _spinningGroupContent;
        [Header("Fly group")]
        [SerializeField] private GameObject _flyGroup;
        [SerializeField] private GameObject _flyGroupContent;
        [Header("Cast group")]
        [SerializeField] private GameObject _castGroup;
        [SerializeField] private GameObject _castGroupContent;
        private bool _defaultRodWasSelected;

        private void Start()
        {
            for (int i = 0; i < _numberOfSlots; i++)
            {
                RodData data = _rodsDataDB.RodsDB[UnityEngine.Random.Range(0, _rodsDataDB.RodsDB.Length)];
                Transform parent = _spinningGroupContent.transform;
                switch (data.Type)
                {
                    case RodType.Fly:
                        parent = _flyGroupContent.transform;
                        break;
                    case RodType.Cast:
                        parent = _castGroupContent.transform;
                        break;
                }
                RodSlot rod = Instantiate(_rodSlotPrefab, parent).GetComponent<RodSlot>() as RodSlot;
                rod.SetupSlot(data);
                rod.gameObject.SetActive(true);
                
                if(_defaultRodWasSelected == false)
                {
                    rod.SelectRod();
                    _defaultRodWasSelected = true;
                }
            }

            ActivateGroupIfNotEmpty(_spinningGroup, _spinningGroupContent.transform);
            ActivateGroupIfNotEmpty(_flyGroup, _flyGroupContent.transform);
            ActivateGroupIfNotEmpty(_castGroup, _castGroupContent.transform);
        }

        private void ActivateGroupIfNotEmpty(GameObject groupParent, Transform content)
        {
            groupParent.SetActive(content.childCount > 0);
        }

    }

}
