using UnityEngine;
using System.Collections;

//for things like armor and weapons
public class BaseStatItems : BaseItems {
    public enum WhoCanEquips {
        //ONE CLASS
        WARRIOR,
        ROUGE,
        BMAGE,
        WMAGE,
        //TWO CLASSES
        WARROUGE,
        WARWMAGE,
        WARBMAGE,
        ROUGBMAGE,
        ROUGWMAGE,
        BWMAGE,
        //THREE CLASSES
        WARROUGBMAG,
        WARROUGWMAG,
        WARBMAGWMAG,
        ROUGBMAGWMAG,
        ALL,
        OTHER
    }
    //what is saved is positive stats so we can use smaller types like byte, but since this could be neg values this has to be ints
    private int strength, intellect, agility, stamina, vitality, spirit;
    private int attackPower, magicPower, speed, phyDmgNeg, magDmgNeg, hitPoints, manaPoints;
    private WhoCanEquips whoCanEquip = new WhoCanEquips();
    private bool equipable = true;
    private double spellEffectEquipedPercent;

    public WhoCanEquips WhoCanEquip {
        get {
            return whoCanEquip;
        }
        protected set {
            whoCanEquip = value;
        }
    }
    //cast from inventory in battle
    public int SpellEffectsInventoryID {
        get;
        protected set;
    }
    //effects phyiscal attack
    public int Strength {
        get {
            return strength;
        }
        protected set {
            strength = value;
        }
    }
    //effects magical attack & magic points
    public int Intellect {
        get {
            return intellect;
        }
        protected set {
            intellect = value;
        }
    }
    //effects speed
    public int Agility {
        get {
            return agility;
        }
        protected set {
            agility = value;
        }
    }
    //effects max HP
    public int Stamina {
        get {
            return stamina;
        }
        protected set {
            stamina = value;
        }
    }
    //effects physical resistance
    public int Vitality {
        get {
            return vitality;
        }
        protected set {
            vitality = value;
        }
    }
    //effects magical resistance
    public int Spirit {
        get {
            return spirit;
        }
        protected set {
            spirit = value;
        }
    }
    //the rest are the derived from stats, but can add or sub this way
    public int AttackPower {
        get {
            return attackPower;
        }
        protected set {
            attackPower = value;
        }
    }
    public int MagicPower {
        get {
            return magicPower;
        }
        protected set {
            magicPower = value;
        }
    }
    public int Speed {
        get {
            return speed;
        }
        protected set {
            speed = value;
        }
    }
    public int HitPoints {
        get {
            return hitPoints;
        }
        protected set {
            hitPoints = value;
        }
    }
    public int ManaPoints {
        get {
            return manaPoints;
        }
        protected set {
            manaPoints = value;
        }
    }
    public int PhyDmgNeg {
        get {
            return phyDmgNeg;
        }
        protected set {
            phyDmgNeg = value;
        }
    }
    public int MagDmgNeg {
        get {
            return magDmgNeg;
        }
        protected set {
            magDmgNeg = value;
        }
    }
    //is it equipbalbe, might not want something to be equipable till a certain part of the story?
    public bool Equipable {
        get {
            return equipable;
        }
        protected set {
            equipable = value;
        }
    }
    //cast while doing basic attack
    public bool SpellEffectsEquipedID {
        get;
        protected set;
    }
    //chance for the equiped effect to go off
    public double SpellEffectEquipedPercent {
        get {
            return spellEffectEquipedPercent;
        }
        protected set {
            spellEffectEquipedPercent = value;
        }
    }

    //empty slot/error
    public BaseStatItems() {
        this.ItemID = 0;
    }
}

//for things that can not be equiped
public class BaseInvoItems: BaseItems { //items
    public enum InvoItemTypes { //can add as much as we want really
        SCROLL,
        POTION,
        KEY, //required to get somewhere does not have to be quest: example buyable/sellable lock picks, but could be a none buyable/sellable pick
        GOODS, //market if we want it
        OTHER //rock for example
    }
    public enum PotionTypes { //base for now, but should add something to max health, mana, & Vigor all at once maybe
        HEALTH,
        MANA,
        ATTACKPOINTS,
        STRENGTH,
        AGILITY,
        STAMINA,
        VITALITY,
        SPIRIT,
        INTELECT,
        MIX,
        OTHER,
        NONE
    }
    private InvoItemTypes invoItemType = new InvoItemTypes();
    private bool inventoryField, infinteUsage;
    private int spellEffectsID;
    private PotionTypes potionType = new PotionTypes();

    public PotionTypes PotionType {
        get {
            return potionType;
        }
        private set {
            potionType = value;
        }
    }
    public InvoItemTypes InvoItemType {
        get {
            return invoItemType;
        }
        protected set {
            invoItemType = value;
        }
    }
    //usable in the field inventory, do not think equipment should have this capablity
    public bool InventoryField {
        get {
            return inventoryField;
        }
        protected set {
            inventoryField = value;
        }
    }
    public int SpellEffectsID { //if you use it, it does this 
        get {
            return spellEffectsID;
        }
        protected set {
            spellEffectsID = value;
        }
    }
    //week items, but infinite usage so does not get rid after use
    public bool InfinteUsage {
        get {
            return infinteUsage;
        }
        protected set {
            infinteUsage = value;
        }
    }

    //empty slot/error
    public BaseInvoItems() {
        this.ItemID = 0;
    }
    public BaseInvoItems(int num, string name, string description, bool stackable, ItemTypes itemType, bool quest, bool inventoryBattle, int cost, string tag,
        InvoItemTypes invoItemType, bool inventoryField, int spellEffectId, PotionTypes potionType, bool infinteUsage) {
        this.ItemID = num;
        this.ItemName = name;
        this.ItemDescription = description;
        this.Stackable = stackable;
        this.ItemType = itemType;
        this.Quest = quest;
        this.InventoryBattle = InventoryBattle;
        this.Cost = cost;
        this.ItemTag = tag;

        this.InvoItemType = invoItemType;
        this.InventoryField = inventoryField;
        this.SpellEffectsID = spellEffectId;
        this.PotionType = potionType;
        this.InfinteUsage = infinteUsage;
    }
}