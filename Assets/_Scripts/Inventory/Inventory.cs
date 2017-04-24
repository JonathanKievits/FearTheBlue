using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	private Dictionary <ItemType,List<Item>> inventory = new Dictionary<ItemType,List<Item>>();
	public Dictionary <ItemType, List<Item>> Inventroy{get{return inventory;}}

	public void AddItem (Item item)
	{
		if (!inventory.ContainsKey (item.Type))
			inventory.Add (item.Type, new List<Item> ());
		inventory[item.Type].Add(item);
		return;
	}

	public void removeItem(ItemType itemType, string itemName)
	{
		if (!inventory.ContainsKey (itemType))
			return;
		
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

	public List<Item> getAllItemsOfType(ItemType type)
	{
		if (!inventory.ContainsKey (type))
			return null;
		return inventory[type];
	}

	public Item getItem(ItemType type, string name)
	{
		if (!inventory.ContainsKey (type))
			return null;

		for (int i = 0; i < inventory [type].Count; i++)
		{
			if (inventory [type] [i].Name == name)
			{
				return inventory [type] [i];
			}
		}
		return null;
	}

	public int getAmountOfItems(ItemType type, string name)
	{
		var temp = 0;
		if (!inventory.ContainsKey (type))
			return temp;

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
