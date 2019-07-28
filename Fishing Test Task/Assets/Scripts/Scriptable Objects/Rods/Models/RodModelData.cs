using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FishingTestTask
{
    [CreateAssetMenu(fileName = "NewRodModel", menuName = "Rod Model Data", order = 50)]
    public class RodModelData : ScriptableObject
    {
        public int ID;
        public GameObject RodPrefab;
    }
}
