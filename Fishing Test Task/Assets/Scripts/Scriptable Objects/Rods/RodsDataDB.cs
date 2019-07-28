using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FishingTestTask
{
    [CreateAssetMenu(fileName = "New Rods Data DB", menuName = "Rods Data DB", order = 60)]
    public class RodsDataDB : ScriptableObject
    {
        public RodData[] RodsDB;
    }

}
