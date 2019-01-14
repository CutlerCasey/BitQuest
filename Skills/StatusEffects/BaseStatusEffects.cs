using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseStatusEffects {
    public enum StatChanges {
        NONE,
        STRENGTH,
        AGILITY,
        STAMINA,
        INTELLECT,
        VITALITY,
        SPIRIT,
        ATTACKPOWER,
        MAGICPOWER,
        SSPEED,
        PHYDMNEG,
        MAGDMGNEG,
        HITPOINTS,
        MANAPOINTS,
        POWERPOINTS
    }

    public BaseStatusEffects() {
        StatusEffectID = -1;
    }

    public string StatusEffectName {
        get;
        protected set;
    }

    public string StatucEffectDescription {
        get; protected set;
    }

    public int StatusEffectID {
        get; protected set;
    }

    private float statusEffectApplyPercent = 0;
    public float StatusEffectApplyPercent {
        get {
            return statusEffectApplyPercent;
        }
        protected set {
            statusEffectApplyPercent = value;
        }
    }

    private int statusEffectDmg = 0;
    public int StatusEffectDmg {
        get {
            return statusEffectDmg;
        }
        protected set {
            statusEffectDmg = value;
        }
    }

    private float statusEffectStayAppliedPercent = 0;
    public float StatusEffectStayAppliedPercent {
        get {
            return statusEffectStayAppliedPercent;
        }
        protected set {
            statusEffectStayAppliedPercent = value;
        }
    }

    private bool stunEffect = false;
    public bool StunEffect {
        get {
            return stunEffect;
        }
        set {
            stunEffect = value;
        }
    }

    private int statusEffectMinTurns = 1;
    public int StatusEffectMinTurns {
        get {
            return statusEffectMinTurns;
        }
        protected set {
            statusEffectMinTurns = value;
        }
    }

    private int statusEffectMaxTurns = 1;
    public int StatusEffectMaxTurns {
        get {
            return statusEffectMaxTurns;
        }
        protected set {
            statusEffectMaxTurns = value;
        }
    }

    public StatChanges StatChange1 {
        get; protected set;
    }
    private float statChangeMultiple1 = 0;
    public float StatChangeMultiple1 {
        get {
            return statChangeMultiple1;
        }
        protected set {
            statChangeMultiple1 = value;
        }
    }

    public StatChanges StatChange2 {
        get; protected set;
    }
    private float statChangeMultiple2 = 0;
    public float StatChangeMultiple2 {
        get {
            return statChangeMultiple2;
        }
        protected set {
            statChangeMultiple2 = value;
        }
    }

    public BaseStatusEffects(int id, string name, string description,
        int applyPercent, int effectDmg, int stayPercent, int minTurn, int maxTurn,
        StatChanges statChange1, int statMulti1, StatChanges statChange2, int statMulti2) {
        this.StatusEffectName = name;
        this.StatucEffectDescription = description;
        this.StatusEffectID = id;
        if(applyPercent > 100)
            this.StatusEffectApplyPercent = 1.0f;
        else if(applyPercent < 0)
            this.StatusEffectApplyPercent = 0.0f;
        else
            this.StatusEffectApplyPercent = applyPercent / 100.0f;

        this.StatusEffectDmg = effectDmg;
        if(stayPercent > 100)
            this.StatusEffectStayAppliedPercent = 1.0f;
        else if(stayPercent < 0)
            this.StatusEffectStayAppliedPercent = 0.0f;
        else
            this.StatusEffectStayAppliedPercent = stayPercent / 100.0f;

        this.StatusEffectMinTurns = minTurn;
        this.StatusEffectMaxTurns = maxTurn;
        this.StatChange1 = statChange1;
        if(statMulti1 < 0)
            this.StatChangeMultiple1 = 0.0f;
        else
            this.StatChangeMultiple1 = statMulti1 / 100.0f;
        this.StatChange2 = statChange2;
        if(statMulti2 < 0)
            this.StatChangeMultiple2 = 0.0f;
        else
            this.StatChangeMultiple2 = statMulti2 / 100.0f;
    }
}
