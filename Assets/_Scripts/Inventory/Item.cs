using UnityEngine;
using System.Collections;

public enum ItemType{cassette, key, puzzleItem};
/// <summary>
/// Holds the item information.
/// </summary>
public class Item
{
    /// <summary>
    /// The name of the item.
    /// </summary>
	private string name;
	public string Name{get{return name;}}

    /// <summary>
    /// The type of the item.
    /// </summary>
	private ItemType type;
	public ItemType Type{get{return type;}}

    /// <summary>
    /// Initializes a new instance of the <see cref="Item"/> class.
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="type">Type.</param>
	public Item(string name, ItemType type)
	{
		this.name = name;
		this.type = type;
	}
}
