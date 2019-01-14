using UnityEngine;
using System.Collections;

public class BaseItems {
    public enum ItemTypes { //types are catagories overall
        WEAPON, //stat based
        ITEM, //usable and none usable items
        ARMOR, //stat based
        ERROR
    }
    
    private bool quest, inventoryBattle, stackable;
    private ItemTypes itemType = new ItemTypes();

    //item name, for player reference
    public string ItemName {
        get;
        protected set;
    }
    //some random text to talk about the item
    public string ItemDescription {
        get;
        protected set;
    }
    //how we look at our items
    public int ItemID {
        get;
        protected set;
    }
    //one of the types from above
    public ItemTypes ItemType {
        get {
            return itemType;
        }
        protected set {
            itemType = value;
        }
    }
    //is it stackable
    public bool Stackable {
        get {
            return stackable;
        }
        protected set {
            stackable = value;
        }
    }
    //prevention of certain things, just to stop from being sold or other things like dropped
    public bool Quest {
        get {
            return quest;
        }
        protected set {
            quest = value;
        }
    }
    //usable in the battle inventory
    public bool InventoryBattle {
        get {
            return inventoryBattle;
        }
        protected set {
            inventoryBattle = value;
        }
    }
    //findable tag
    public string ItemTag {
        get;
        protected set;
    }
    public int Cost {
        get; protected set;
    }

    //empty slot/error
    public BaseItems() {
        this.ItemID = 0;
    }
}
