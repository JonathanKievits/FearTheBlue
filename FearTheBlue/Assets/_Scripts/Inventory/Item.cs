using UnityEngine;
using System.Collections;

public enum ItemType{cassette, key, thing};
public class Item
{
	private string name;
	public string Name{get{return name;}}

	private ItemType type;
	public ItemType Type{get{return type;}}

	public Item(string name, ItemType type)
	{
		this.name = name;
		this.type = type;
	}
}
