using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	private Dictionary <ItemType,List<Item>> inventory = new Dictionary<ItemType,List<Item>>();
	public Dictionary <ItemType, List<Item>> Inventroy{get{return inventory;}}

	/*
	private void Awake()
	{
		Item cas1 = new Item ("cassette1", ItemType.cassette);
		Item cas2 = new Item ("cassette2", ItemType.cassette);
		AddItem (cas1);
		AddItem (cas2);
	}
	*/

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

	/*
	public void useItem(string name, ItemType type, bool keepItem)
	{
		if (!inventory.ContainsKey (type))
			return;

		for (var i = 0; i < inventory [type].Count; i++)
		{
			if (inventory [type] [i].Name == name)
			{
				inventory [type] [i].use ();

				if(!keepItem)
					removeItem (type, name);
				break;
			}
		}
	}
	*/

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
