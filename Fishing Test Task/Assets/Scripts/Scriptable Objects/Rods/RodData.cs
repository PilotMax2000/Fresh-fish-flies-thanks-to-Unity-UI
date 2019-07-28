using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FishingTestTask
{
    [CreateAssetMenu(fileName = "NewRod", menuName = "Rod Data", order = 59)]
    public class RodData : ScriptableObject
    {
        public string RodName;
        public Sprite Icon;
        public RodRarity Rarity;
        public RodType Type;
        public int RodModelID;
    
    }

    public enum RodRarity { Blue, Purple, Yellow }
    public enum RodType {Spin, Cast, Fly};
}
