using System;
class RNJesus
{
    public static float GetRange()
    {
        System.Random rd = new();
        int range = rd.Next(6, 13);
        return ((float)range) / 10;
    }
    public static float Crit()
    {
        float resp = 1;
        System.Random rd = new();
        int crit = rd.Next(1, 11);
        if (crit >= 9)
        {
            resp = 2;
        }
        return resp;

    }
    public static bool ErraAcao(int precisao)
    {
        System.Random rd = new();
        return rd.Next(1, 101) > precisao;
    }

}
