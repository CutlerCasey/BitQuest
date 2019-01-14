using UnityEngine;

public class RndBaseStats : StatCalculations {
    //stats random
    public byte CalculateStat(ushort total, byte statVal, byte level) {
        calcStat(total, statVal, level, false, false);
        return (byte)modifer;
    }
    public byte CalculateRndStat(ushort total, byte statVal, byte level, bool isNpc) {
        calcStat(total, statVal, level, isNpc, true);
        return (byte)modifer;
    }
    private void calcStat(ushort total, byte statVal, byte level, bool isNpc, bool isRnd) {
        byte low = 0, high = 0;
        if(isRnd && isNpc) {
            low = high = 1; //random, but only up or down 1, could all be down
        }
        else if(isRnd && !isNpc) {
            low = high = 2; //random, enemis have more leway
        }
        modifer = (long)Mathf.Round(statVal + ((level - 1) * Random.Range(statsPerLevel - low, statsPerLevel + high + 1) * statVal) / total);
        //in this case modifer is a byte
        if(modifer < 2) {
            modifer = 1;
        }
        else if(modifer > 254) {
            modifer = 255;
        }
    }
}
