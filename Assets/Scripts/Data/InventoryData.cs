using System;
using System.Collections.Generic;
using Drop;
using Inventory;
using UnityEngine;

namespace Data
{
	[Serializable]
	public class InventoryData
	{
		public Queue<DropStruct> DropsQueue = new();
		public List<ItemCell> ItemCellsList = new();

		public void SetItemInDropsQueue(DropType dropType, Sprite sprite, int packCount, int value)
		{
			DropStruct newDrop = new DropStruct();

			newDrop.DropType = dropType;
			newDrop.Sprite = sprite;
			newDrop.PackCount = packCount;
			newDrop.Value = value;

			DropsQueue.Enqueue(newDrop);
		}

		public DropStruct GetItemFromDropsQueue() => 
			DropsQueue.Dequeue();
	}

	[Serializable]
	public struct DropStruct
	{
		public DropType DropType;
		public Sprite Sprite;
		public int PackCount;
		public int Value;
	}
}