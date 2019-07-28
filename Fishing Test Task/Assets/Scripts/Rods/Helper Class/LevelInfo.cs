
namespace FishingTestTask
{
    public struct LevelInfo
    {
        public int Level;
        public int CurrentExp;
        public int ExpToNextLevel;

        public LevelInfo(int startExp)
        {
            RodLevelSystem.ExpToLevel(startExp, out Level, out CurrentExp, out ExpToNextLevel);
        }

        public LevelInfo(int setLevel, int extraExp)
        {
            Level = setLevel;
            ExpToNextLevel = RodLevelSystem.GetExpForNextLevel(Level);
            CurrentExp = extraExp;
        }
    }
}
