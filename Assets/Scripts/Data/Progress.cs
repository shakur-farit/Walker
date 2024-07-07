using System;

namespace Data
{
	[Serializable]
	public class Progress
	{
		public InventoryData InventoryData = new();
		public CharacterData CharacterData= new();
	}
}