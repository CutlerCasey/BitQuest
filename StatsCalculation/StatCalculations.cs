public class StatCalculations {
    //stealing some info
    private static BaseCharacterClass stealingInfo = new BaseCharacterClass();
    protected byte statsPerLevel = stealingInfo.StatsPerLevel;

    public enum StatTypes {
        STRENGTH,
        AGILITY,
        STAMINA,
        INTELLECT,
        VITALITY,
        SPIRIT
    }
    public enum DerivedStatTypes {
        AttackPower,
        MagicPower,
        Speed,
        PhyDmgNeg,
        MagDmgNeg,
        HealthPoints,
        ManaPoints
    }

    //done for random generation
    protected long modifer = 0;
    
    //derived stats random/not random
    //need to work on the not random stuff
    protected int gearStr = 0, gearAgi = 0, gearSta = 0, gearInt = 0, gearVit = 0, gearSpi = 0;
    protected int gearAttPow = 0, gearMagPow = 0, gearSpe = 0, gearPhyDmgNeg = 0, gearMagDmgNeg = 0, gearHP = 0, gearMP = 0;
    protected int buffStr = 0, buffAgi = 0, buffSta = 0, buffInt = 0, buffVit = 0, buffSpi = 0;
    protected int buffAttPow = 0, buffMagPow = 0, buffSpe = 0, buffPhyDmgNeg = 0, buffMagDmgNeg = 0, buffHP = 0, buffMP = 0;
}
