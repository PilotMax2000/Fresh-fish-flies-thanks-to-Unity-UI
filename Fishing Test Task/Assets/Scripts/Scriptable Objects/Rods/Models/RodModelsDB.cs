using UnityEngine;

namespace FishingTestTask
{
    [CreateAssetMenu(fileName = "NewRodModelsDB", menuName = "Create Rod Models DB", order = 49)]
    public class RodModelsDB : ScriptableObject
    {
        public RodModelData[] ModelsDB;
    }
}
