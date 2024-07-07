using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure.Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "AssetsReference", menuName = "Scriptable Object/Assets Reference")]
	public class AssetsReference : ScriptableObject
	{ 
		public string CharacterAddress;
		public string EnemyAddress;
		public string AmmoAddress;
		public string DropAddress;
		public string HudAddress;
		public string UIRootAddress;
		public string InventoryWindowAddress;
		public string ItemCellAddress;
		public string ItemInformationWindowAddress;
		public string LevelCompleteWindowAddress;
		public string GameOverWindowAddress;
	}
}