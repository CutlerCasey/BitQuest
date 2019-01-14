using UnityEngine;
using System.Collections;

public class GameInfoScripts : MonoBehaviour {

    public void setGenderMale()
    {
        GameInformation.SpriteString = "Base Male";
        GameInformation.IsMale = true;
    }

    public void setGenderFemale()
    {
        GameInformation.SpriteString = "Base Female";
        GameInformation.IsMale = false;
    }

    public void setFemaleSkin_1() { GameInformation.SpriteString = "NPCWMage_f"; }
    public void setFemaleSkin_2() { GameInformation.SpriteString = "NPCRouge_f"; }
    public void setFemaleSkin_3() { GameInformation.SpriteString = "NPCWFighter_f"; }

    public void setMaleSkin_1() { GameInformation.SpriteString = "NPCRookie_m"; }
    public void setMaleSkin_2() { GameInformation.SpriteString = "NPCRouge_m"; }
    public void setMaleSkin_3() { GameInformation.SpriteString = "NPCWarrior_m"; }

    public void setClassBase()
    {
        GameInformation.PlayerClass = BaseCharacterClass.CharacterClasses.BASE;
        GameInformation.Strength = 3;
        GameInformation.Agility = 2;
        GameInformation.Stamina = 3;
        GameInformation.Intelect = 3;
        GameInformation.Vitality = 4;
        GameInformation.Spirit = 2;
        PointsHolder.Points = 5;
    }
    public void setClassWarrior()
    {
        GameInformation.PlayerClass = BaseCharacterClass.CharacterClasses.WARRIOR;
        GameInformation.Strength = 9;
        GameInformation.Agility = 2;
        GameInformation.Stamina = 8;
        GameInformation.Intelect = 3;
        GameInformation.Vitality = 9;
        GameInformation.Spirit = 2;
        PointsHolder.Points = 5;
    }
    public void setClassRouge()
    {
        GameInformation.PlayerClass = BaseCharacterClass.CharacterClasses.ROUGE;
        GameInformation.Strength = 7;
        GameInformation.Agility = 5;
        GameInformation.Stamina = 6;
        GameInformation.Intelect = 4;
        GameInformation.Vitality = 5;
        GameInformation.Spirit = 6;
        PointsHolder.Points = 5;
    }
    public void setClassBMage()
    {
        GameInformation.PlayerClass = BaseCharacterClass.CharacterClasses.BMAGE;
        GameInformation.Strength = 3;
        GameInformation.Agility = 2;
        GameInformation.Stamina = 4;
        GameInformation.Intelect = 9;
        GameInformation.Vitality = 6;
        GameInformation.Spirit = 9;
        PointsHolder.Points = 5;
    }
    public void setClassWMage()
    {
        GameInformation.PlayerClass = BaseCharacterClass.CharacterClasses.WMAGE;
        GameInformation.Strength = 5;
        GameInformation.Agility = 1;
        GameInformation.Stamina = 6;
        GameInformation.Intelect = 7;
        GameInformation.Vitality = 4;
        GameInformation.Spirit = 10;
        PointsHolder.Points = 5;
    }

    public void PointsUp() { PointsHolder.Points++; }
    public void PointsDown() { PointsHolder.Points--; }
    public void StrUp() { GameInformation.Strength++; }
    public void StrDown() { GameInformation.Strength--; }
    public void IntUp() { GameInformation.Intelect++; }
    public void IntDown() { GameInformation.Intelect--; }
    public void AgiUp() { GameInformation.Agility++; }
    public void AgiDown() { GameInformation.Agility--; }
    public void StmUp() { GameInformation.Stamina++; }
    public void StmDown() { GameInformation.Stamina--; }
    public void VitUp() { GameInformation.Vitality++; }
    public void VitDown() { GameInformation.Vitality--; }
    public void SprUp() { GameInformation.Spirit++; }
    public void SprDown() { GameInformation.Spirit--; }
}
