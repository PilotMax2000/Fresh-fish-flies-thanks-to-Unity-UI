namespace FishingTestTask
{
    public static class RodLevelSystem  {

    public const int EXP_INCREMENTOR = 1;
    public static void ExpToLevel(int expOnStart, out int level, out int expToNextLevel, out int currLevelExp)
    {
        int exp = expOnStart;
        int currLevel = 1;
        while(true)
        {
            if(exp - GetExpForNextLevel(currLevel) < 0)
            {
                level = currLevel;
                currLevelExp = exp;
                expToNextLevel = GetExpForNextLevel(currLevel);
                return;
            }
            currLevel++;
            exp -= GetExpForNextLevel(currLevel);

        }
    }

    public static int GetExpForNextLevel(int currLevel)
    {
        return currLevel + EXP_INCREMENTOR;
    }
}

}
