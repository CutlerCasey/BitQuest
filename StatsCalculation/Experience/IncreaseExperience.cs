using UnityEngine;
using System.Collections;

public static class Experience {
    private static float xpToGive;
    private static LevelUp levelUpScript = new LevelUp();

    //different options for us to use
    public static void BattleExp(uint exp, bool winLoss, int avgLevelMobs, int avgPlayerLevel, bool wL, bool levelBased, bool anyExp) {
        int forWL = 100;
        if(anyExp) {
            if(levelBased && wL) {
                if(avgLevelMobs >= avgPlayerLevel) {
                    //seems high, but might be right
                    xpToGive = exp * (avgLevelMobs + 1 - avgPlayerLevel);  //exp * (1 + 1 -1) = exp: exp * (20 + 1 - 10) = exp * 11
                    if(winLoss) {
                        //xpToGive = xpToGive;
                    }
                    else
                        xpToGive = xpToGive / forWL;
                }
                else {
                    //might not effect enough
                    xpToGive = exp / (-avgLevelMobs + 1 + avgPlayerLevel) + 1;  //exp / (-1 + 1 + 2) = exp / 2: exp / (-6 + 1 + 10) = exp / 5
                    if(winLoss) {
                        //xpToGive = xpToGive;
                    }
                    else
                        xpToGive = xpToGive / forWL;
                }
            }
            else if(levelBased) {
                if(avgLevelMobs >= avgPlayerLevel) {
                    //seems high, but might be right
                    xpToGive = exp * (avgLevelMobs + 1 - avgPlayerLevel);  //exp * (1 + 1 -1) = exp: exp * (20 + 1 - 10) = exp * 11
                }
                else {
                    //might not effect enough
                    xpToGive = exp / (-avgLevelMobs + 1 + avgPlayerLevel) + 1;  //exp / (-1 + 1 + 2) = exp / 2: exp / (-6 + 1 + 10) = exp / 5
                }
            }
            else if(wL) {
                if(winLoss)
                    xpToGive = exp;
                else
                    xpToGive = exp / forWL;
            }
            else {
                xpToGive = exp;
            }
        }
        else {
            xpToGive = 0;
        }
        CheckToSeeIfPlayerLeveled();
    }
    public static void ExploriationExp() {
        CheckToSeeIfPlayerLeveled();
    }
    public static void InitialLevel() {
        CheckToSeeIfPlayerLeveled();
    }

    private static void CheckToSeeIfPlayerLeveled() {
        while(GameInformation.PlayerCurrentExp >= GameInformation.PlayerRequriredExp) {
            //level up the player
            levelUpScript.LevelUpCharacter();
        }
    }
}
