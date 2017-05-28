using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Inventory class.
/// </summary>
public class Inventory : MonoBehaviour 
{
    /// <summary>
    /// Holds the items.
    /// </summary>
    private Dictionary <ItemType,List<Item>> inventory;
	public Dictionary <ItemType, List<Item>> Inventroy{get{return inventory;}}
    /// <summary>
    /// Reference to the Audiomanager.
    /// </summary>
    private AudioManager audioManager;
    private int _pickup;

    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        inventory = new Dictionary<ItemType,List<Item>>();
        inventory.Add (ItemType.cassette, new List<Item> ());
        inventory.Add (ItemType.key, new List<Item> ());
        inventory.Add (ItemType.puzzleItem, new List<Item> ());
        audioManager = this.GetComponent<AudioManager>();
        _pickup = audioManager.audioToID("Pickup");
    }

    /// <summary>
    /// Adds item to the inventory.
    /// </summary>
    /// <param name="item">Item.</param>
	public void AddItem (Item item)
	{
        audioManager.playSound(_pickup);
		inventory[item.Type].Add(item);
		return;
	}

    /// <summary>
    /// Removes item from the inventory.
    /// </summary>
    /// <param name="itemType">Item type.</param>
    /// <param name="itemName">Item name.</param>
	public void removeItem(ItemType itemType, string itemName)
    {	
		for (int i = 0; i < inventory [itemType].Count; i++)
		{
			if (inventory [itemType] [i].Name == itemName)
			{
				inventory [itemType].RemoveAt (i);
				break;
			}
		}
		return;
	}

    /// <summary>
    /// Gets the all items of a type.
    /// </summary>
    /// <returns>The all items of type.</returns>
    /// <param name="type">Type.</param>
	public List<Item> getAllItemsOfType(ItemType type)
	{	
		return inventory[type];
	}

    /// <summary>
    /// Gets an tem with the name.
    /// </summary>
    /// <returns>The item.</returns>
    /// <param name="type">Type.</param>
    /// <param name="name">Name.</param>
	public Item getItem(ItemType type, string name)
	{
		for (int i = 0; i < inventory [type].Count; i++)
		{
			if (inventory [type] [i].Name == name)
			{
				return inventory [type] [i];
			}
		}
		return null;
	}

    /// <summary>
    /// Gets and item with the index.
    /// </summary>
    /// <returns>The item.</returns>
    /// <param name="type">Type.</param>
    /// <param name="index">Index.</param>
	public Item getItem(ItemType type, int index)
	{
		for (int i = 0; i < getAllItemsOfType (type).Count; i++)
		{
			if (inventory [type] [i].Name == name)
			{
				return inventory [type] [i];
			}
		}
		return null;
	}

    /// <summary>
    /// Gets the amount of items.
    /// </summary>
    /// <returns>The amount of items.</returns>
    /// <param name="type">Type.</param>
    /// <param name="name">Name.</param>
	public int getAmountOfItems(ItemType type, string name)
	{
		var temp = 0;
		for (int i = 0; i < inventory [type].Count; i++)
		{
			if (inventory [type] [i].Name == name)
			{
				temp++;
			}
		}
		return temp;
	}
}
