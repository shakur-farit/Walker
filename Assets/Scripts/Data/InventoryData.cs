using System;
using System.Collections.Generic;
using Character;
using Inventory;

namespace Data
{
	[Serializable]
	public class InventoryData
	{
		public List<DropStaticData> DropsStaticDataList = new();
		public List<ItemCell> ItemCellsList = new();
	}
}