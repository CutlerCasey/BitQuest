using UnityEngine;

public class CalculateDerived : StatCalculations {
    //just to make the previous shorter
    protected void CalculateDerivedShorten(bool randomNpcMonster, DerivedStatTypes statType, byte createrType) {
        if(!randomNpcMonster) {
            //collect all the stats
            GetGear(statType, createrType);
        }
        GetBuffs(statType, createrType);
    }
    //deriving Mana
    protected void CalcDerived(byte statValInt, byte statValSpi) {
        byte low = 6, high = 100, mod = 10;
        float modInt = .52f, modSpi = .42f, stats = 0;
        int statsInt = 0, statsSpi = 0, deriv = 0;

        statsInt = gearInt + buffInt + statValInt;
        statsSpi = gearSpi + buffSpi + statValSpi;
        stats = statsInt * modInt + statsSpi * modSpi;
        if(stats < 1) {
            stats = 1;
        }
        deriv = gearMP + buffMP;

        modifer = (long)(Mathf.Round(((1 - stats) / high * low + stats)) * mod) + deriv;
        if(modifer < 1) {
            modifer = 1;
        }
        else if(modifer > 9999) {
            modifer = 9999;
        }
    }
    //deriving other stats
    protected void CalcDerived(byte statVal, DerivedStatTypes statType) {
        byte low = 5, high = 100, mod = 1;
        bool isHP = false;
        int stats = 0, deriv = 0;

        switch(statType) {
            case (DerivedStatTypes.AttackPower):
                stats = statVal + gearStr + gearStr;
                deriv = gearAttPow + buffAttPow;
                low = 5;
                high = 100;
                mod = 1;
                break;
            case (DerivedStatTypes.MagicPower):
                stats = statVal + gearInt + buffInt;
                deriv = gearMagPow + buffMagPow;
                low = 5;
                high = 100;
                mod = 1;
                break;
            case (DerivedStatTypes.Speed):
                stats = statVal + gearAgi + buffAgi;
                deriv = gearSpe + buffSpe;
                low = 40;
                high = 100;
                mod = 1;
                break;
            case (DerivedStatTypes.PhyDmgNeg):
                stats = statVal + gearVit + buffVit;
                deriv = gearPhyDmgNeg + buffPhyDmgNeg;
                low = 20;
                high = 100;
                mod = 1;
                break;
            case (DerivedStatTypes.MagDmgNeg):
                stats = statVal + gearSpi + buffSpi;
                deriv = gearMagDmgNeg + buffMagDmgNeg;
                low = 20;
                high = 100;
                mod = 1;
                break;
            case (DerivedStatTypes.HealthPoints):
                stats = statVal + gearSta + buffSta;
                deriv = gearHP + buffHP;
                low = 6;
                high = 100;
                mod = 10;
                isHP = true;
                break;
        }
        if(stats < 1) {
            stats = 1; //just a safety net 2 * -10 + stats, might be lower
        }

        modifer = (long)(Mathf.Round(((1 - stats) / high * low + stats)) * mod) + deriv;
        if(modifer < 1) {
            modifer = 1;
        }

        if(isHP) {
            if(modifer > 9999) {
                modifer = 9999;
            }
        }
        else if(modifer > 255) {
            modifer = 255;
        }
    }
    
    //gear for none randoms
    private void GetGear(DerivedStatTypes statType, byte createrType) {
        if(createrType == 0) {
            GetGearPlayer(statType);
        }
        else if(createrType == 1) {
            GetGearNpc(statType);
        }
        else if(createrType == 2) {
            
        }
    }
    //need to work on these, but not sure how to do it yet
    protected void GetGearPlayer(DerivedStatTypes statType) {
        switch(statType) {
            case (DerivedStatTypes.AttackPower):

            case (DerivedStatTypes.Speed):

            case (DerivedStatTypes.PhyDmgNeg):

            case (DerivedStatTypes.HealthPoints):

            case (DerivedStatTypes.ManaPoints):
            case (DerivedStatTypes.MagicPower):

            case (DerivedStatTypes.MagDmgNeg):

                break;
        }
    }
    protected void GetGearNpc(DerivedStatTypes statType) {
        switch(statType) {
            case (DerivedStatTypes.AttackPower):

            case (DerivedStatTypes.Speed):

            case (DerivedStatTypes.PhyDmgNeg):

            case (DerivedStatTypes.HealthPoints):

            case (DerivedStatTypes.ManaPoints):
            case (DerivedStatTypes.MagicPower):

            case (DerivedStatTypes.MagDmgNeg):

                break;
        }
    }
    //buffs for all
    //need to work on this, but not sure how to do it yet
    protected void GetBuffs(DerivedStatTypes statType, byte createrType) {

    }
    protected void GetBuffsPlayer(DerivedStatTypes statType) {
        switch(statType) {
            case (DerivedStatTypes.AttackPower):

            case (DerivedStatTypes.Speed):

            case (DerivedStatTypes.PhyDmgNeg):

            case (DerivedStatTypes.HealthPoints):

            case (DerivedStatTypes.ManaPoints):
            case (DerivedStatTypes.MagicPower):

            case (DerivedStatTypes.MagDmgNeg):

                break;
        }
    }
    protected void GetBuffsNpc(DerivedStatTypes statType) {
        switch(statType) {
            case (DerivedStatTypes.AttackPower):

            case (DerivedStatTypes.Speed):

            case (DerivedStatTypes.PhyDmgNeg):

            case (DerivedStatTypes.HealthPoints):

            case (DerivedStatTypes.ManaPoints):
            case (DerivedStatTypes.MagicPower):

            case (DerivedStatTypes.MagDmgNeg):

                break;
        }
    }
    protected void GetBuffsMonster(DerivedStatTypes statType) {
        switch(statType) {
            case (DerivedStatTypes.AttackPower):

            case (DerivedStatTypes.Speed):

            case (DerivedStatTypes.PhyDmgNeg):

            case (DerivedStatTypes.HealthPoints):

            case (DerivedStatTypes.ManaPoints):
            case (DerivedStatTypes.MagicPower):

            case (DerivedStatTypes.MagDmgNeg):

                break;
        }
    }
    //acts as gear for the randoms and monsters
    protected void GetRndBuffs(byte level, DerivedStatTypes statType) {
        switch(statType) {
            case (DerivedStatTypes.AttackPower):
            case (DerivedStatTypes.MagicPower):
            case (DerivedStatTypes.PhyDmgNeg):
            case (DerivedStatTypes.MagDmgNeg):
                modifer = (long)Random.Range(modifer - .75f * level, modifer + 1.5f * level);
                if(modifer > 255) {
                    modifer = 255;
                }
                break;
            case (DerivedStatTypes.Speed):
                modifer = (long)Random.Range(modifer - .15f * level, modifer + .3f * level);
                if(modifer > 255) {
                    modifer = 255;
                }
                break;
            case (DerivedStatTypes.HealthPoints):
            case (DerivedStatTypes.ManaPoints):
                modifer = (long)Random.Range(modifer - 5 * level, modifer + 10 * level);
                if(modifer > 9999)
                    modifer = 9999;
                break;
        }
        if(modifer < 1) {
            modifer = 1;
        }
    }
}