using System;
using System.Collections.Generic;
using Drop;
using Inventory;

namespace Data
{
	[Serializable]
	public class InventoryData
	{
		public List<DropData> DropsList = new();
		public List<ItemCell> ItemCellsList = new();
	}
}