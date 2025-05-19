using UnityEngine;

public static class RandomStatic
{
    static int rndNum = 0;

    static int rndNum2 = 2;

    static void RndNumber()
    {

    }

    static int RndIntNum()
    {
        return rndNum++;
    }
}
