using UnityEngine;

public class CalcDerivedOther : CalculateDerived {
    //other derived stats
    public byte CalculateDerivedStatByte(byte statVal, byte createrType, DerivedStatTypes statType) {
        CalculateDerivedShorten(false, statType, createrType);
        CalcDerived(statVal, statType);
        return (byte)modifer;
    }
    public byte CalculateRndDerivedStatByte(byte statVal, byte level, byte createrType, DerivedStatTypes statType) {
        CalculateDerivedShorten(true, statType, createrType);
        CalcDerived(statVal, statType);
        GetRndBuffs(level, statType);
        return (byte)modifer;
    }
}

public class CalcDerivedMP: CalculateDerived {
    //max mana
    public ushort CalculateDerivedStatUshort(byte statValInt, byte statValSpi, byte createrType) {
        CalculateDerivedShorten(true, DerivedStatTypes.ManaPoints, createrType);
        CalcDerived(statValInt, statValSpi);
        return (ushort)modifer;
    }
    public ushort CalculateRndDerivedStatUshort(byte statValInt, byte statValSpi, byte level, byte createrType) {
        CalculateDerivedShorten(true, DerivedStatTypes.ManaPoints, createrType);
        CalcDerived(statValInt, statValSpi);
        GetRndBuffs(level, DerivedStatTypes.ManaPoints);
        return (ushort)modifer;
    }
}

public class CalcDerivedHP: CalculateDerived {
    //max health
    public ushort CalculateDerivedStatUshort(byte statValSta, byte createrType, DerivedStatTypes statType) {
        CalculateDerivedShorten(false, statType, createrType);
        CalcDerived(statValSta, statType);
        return (ushort)modifer;
    }
    public ushort CalculateRndDerivedStatUshort(byte statValSta, byte level, byte createrType, DerivedStatTypes statType) {
        CalculateDerivedShorten(true, statType, createrType);
        CalcDerived(statValSta, statType);
        GetRndBuffs(level, statType);
        return (ushort)modifer;
    }
}

public class CalcExpMoney : CalculateDerived {
    //exp starts out lower and ends higher than money
    const float exp = 3.9f, money = 3.4f;
    //exp normal
    public ushort CalcRndExp(byte level) {
        modifer = (ushort)Mathf.Pow(level, exp) + 10;
        return (ushort)modifer;
    }
    public ushort CalcRndExpLow(byte level) {
        modifer = (ushort)(CalcRndExp(level) / exp);
        return (ushort)modifer;
    }
    public ushort CalcRndExpHigh(byte level) {
        modifer = (ushort)(CalcRndExp(level) * exp);
        return (ushort)modifer;
    }

    //money normal
    public ushort CalcRndMoney(byte level) {
        modifer = (ushort)(Mathf.Pow(level, money) + level * money) + 100;
        return (ushort)modifer;
    }
    public ushort CalcRndMoneyLow(byte level) {
        modifer = (ushort)(CalcRndMoney(level) / money);
        return (ushort)modifer;
    }
    public ushort CalcRndHigh(byte level) {
        modifer = (ushort)(CalcRndMoney(level) * money);
        return (ushort)modifer;
    }
}