using UnityEngine;
using System.Collections;

public class LevelUp {
    private byte maxLevel = 20;
    public void LevelUpCharacter() {
        //check to see if current xp > than required xp
        CheckExp(); //required
        //give player stats
        Stats();
        //give player stat points
        StatPoints();
        //give player skill points
        SkillPoints();
        //maybe give a player random items
        Items();
        //give them moves/abilities
        Moves();
        Abilities();
        //give money
        Money();
        //determine the next amount of exp to level
        DetermineRequiredXP(); //required
    }
    
    //required
    private void CheckExp() {
        uint requExp = GameInformation.PlayerRequriredExp;
        if(GameInformation.PlayerCurrentExp > requExp && GameInformation.PlayerLevel < maxLevel) {
            GameInformation.PlayerLevel += 1;
            GameInformation.PlayerCurrentExp -= requExp;
        }
        else if(GameInformation.PlayerLevel < maxLevel) {
            GameInformation.PlayerLevel += 1;
            GameInformation.PlayerCurrentExp = 0;
        }
        else {
            GameInformation.PlayerLevel = maxLevel;
            GameInformation.PlayerCurrentExp = 0;
        }
    }
    public void DetermineRequiredXP() {
        uint playerLevel = GameInformation.PlayerLevel; //current level
        playerLevel += 1;
        float xpLevel1 = 30; //exp to level from 0 to 1
        float xpLevel20 = 2371630; //exp to level from 19 to 20

        float b = Mathf.Log(xpLevel20 / xpLevel1) / (maxLevel - 1);
        float a = xpLevel1 / (Mathf.Exp(b) - 1);
        float oldxp = a * Mathf.Exp((float)b * (playerLevel - 1));
        float newxp = a * Mathf.Exp((float)b * playerLevel);

        uint temp = (uint)Mathf.Round((newxp - oldxp) / 10.0f) * 10;
        GameInformation.PlayerRequriredExp = temp;
    }
    //up to the user
    private void Stats() {

    }
    private void StatPoints() {

    }
    private void SkillPoints() {
        PointsHolder.Points = PointsHolder.Points + 10;
    }
    private void Items() {

    }
    private void Moves() {

    }
    private void Abilities() {

    }
    private void Money() {

    }
}
