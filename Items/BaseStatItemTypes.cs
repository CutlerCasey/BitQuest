using UnityEngine;
using System.Collections;

public class BaseWeapons: BaseStatItems {
    //needs public
    public enum WeaponTypes { //can add as much as we want really
        //pierce
        KNIFE,
        DAGGER,
        SPEAR,
        //cut
        SHORTSWORD,
        SWORD,
        LONGSWORD,
        //blunts
        WAND,
        MACE,
        STAFF,
        HAMMER,
        POLEARM,
        //ranged
        SLING,
        BOW,
        CROSSBOW,
        //joking, but whatever
        PISTOL,
        SHOTGUN,
        RIFLE,
        LASERPISTOL,
        LASERSHOTGUN,
        LASERRIFLE,
        OHTER,
        NONE
    }
    private WeaponTypes weaponType = new WeaponTypes();
    private bool phyOrMag = true;

    public WeaponTypes WeaponType {
        get {
            return weaponType;
        }
        private set {
            weaponType = value;
        }
    }
    //can be a physical based attack or magical type? might remove this, but would allow a mage to use a wand to do damage based on magical attack
    public bool PhyOrMag {
        get {
            return phyOrMag;
        }
        private set {
            phyOrMag = value;
        }
    }

    //empty slot/error
    public BaseWeapons() {
        this.ItemID = 0;
    }
    public BaseWeapons(int num, string name, string description, bool stackable, ItemTypes itemType, bool quest, bool inventoryBattle, int cost, string tag,
        bool equipable, WhoCanEquips whoCanEquip,
        int str, int inte, int agi, int sta, int vit, int spi,
        int attPow, int magPow, int spe, int phyDmgRed, int magDmgRed, int hp, int mp,
        int spellEffectInventoryID, bool spellEffectsEquipedID, int spellEffectEquipedPercent,
        WeaponTypes weaponType, bool phyOrMag) {
        this.ItemID = num;
        this.ItemName = name;
        this.ItemDescription = description;
        this.Stackable = stackable;
        this.ItemType = itemType;
        this.Quest = quest;
        this.InventoryBattle = InventoryBattle;
        this.Cost = cost;
        this.ItemTag = tag;

        this.Equipable = equipable;
        this.WhoCanEquip = whoCanEquip;

        this.Strength = str;
        this.Intellect = inte;
        this.Agility = agi;
        this.Stamina = sta;
        this.Vitality = vit;
        this.Spirit = spi;

        this.AttackPower = attPow;
        this.MagicPower = magPow;
        this.Speed = spe;
        this.PhyDmgNeg = phyDmgRed;
        this.MagDmgNeg = magDmgRed;
        this.HitPoints = hp;
        this.ManaPoints = mp;

        this.SpellEffectsInventoryID = spellEffectInventoryID;
        this.SpellEffectsEquipedID = spellEffectsEquipedID;
        this.SpellEffectEquipedPercent = spellEffectEquipedPercent / 100.0f;

        this.weaponType = weaponType;
        this.PhyOrMag = phyOrMag;
    }
}

//will want to go deeper, but later
public class BaseArmors: BaseStatItems {
    //needs public
    public enum ArmorTypes { //can add as much as we want really
        //civil ocasions, but also under
        PANTS,
        SHIRT,
        //armor
        HEAD,
        ROBE,
        CAPE,
        CHEST,
        SHOULDER, //could just be one shoulder
        ARM, //arm gaurd
        LEG, //leg gaurd
        FEET,
        EARRING,
        RING,
        NEKLACE,
        OFFHAND, //does not mean that can not use a single hand weapon in the off hand
        OTHER,
        NONE
    }
    private ArmorTypes armorType = new ArmorTypes();

    public ArmorTypes ArmorType {
        get {
            return armorType;
        }
        private set {
            armorType = value;
        }
    }

    //empty slot/error
    public BaseArmors() {
        this.ItemID = 0;
    }
    public BaseArmors(int num, string name, string description, bool stackable, ItemTypes itemType, bool quest, bool inventoryBattle, int cost, string tag,
        bool equipable, WhoCanEquips whoCanEquip,
        int str, int inte, int agi, int sta, int vit, int spi,
        int attPow, int magPow, int spe, int phyDmgRed, int magDmgRed, int hp, int mp,
        int spellEffectInventoryID, bool spellEffectsEquipedID, double spellEffectEquipedPercent,
        ArmorTypes armorType) {
        this.ItemID = num;
        this.ItemName = name;
        this.ItemDescription = description;
        this.Stackable = stackable;
        this.ItemType = itemType;
        this.Quest = quest;
        this.InventoryBattle = InventoryBattle;
        this.Cost = cost;
        this.ItemTag = tag;

        this.Equipable = equipable;
        this.WhoCanEquip = whoCanEquip;

        this.Strength = str;
        this.Intellect = inte;
        this.Agility = agi;
        this.Stamina = sta;
        this.Vitality = vit;
        this.Spirit = spi;

        this.AttackPower = attPow;
        this.MagicPower = magPow;
        this.Speed = spe;
        this.PhyDmgNeg = phyDmgRed;
        this.MagDmgNeg = magDmgRed;
        this.HitPoints = hp;
        this.ManaPoints = mp;

        this.SpellEffectsInventoryID = spellEffectInventoryID;
        this.SpellEffectsEquipedID = spellEffectsEquipedID;
        this.SpellEffectEquipedPercent = spellEffectEquipedPercent / 100.0f;

        this.ArmorType = armorType;
    }
}