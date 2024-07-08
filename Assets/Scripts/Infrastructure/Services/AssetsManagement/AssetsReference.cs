using UnityEngine;

namespace Infrastructure.Services.AssetsManagement
{
	[CreateAssetMenu(fileName = "AssetsReference", menuName = "Scriptable Objects/Assets Reference")]
	public class AssetsReference : ScriptableObject
	{
		public string VirtualCameraAddress;
		public string CharacterAddress;
		public string EnemyAddress;
		public string TilemapAddress;
		public string AmmoAddress;
		public string DropAddress;
		public string HudAddress;
		public string UIRootAddress;
		public string InventoryWindowAddress;
		public string ItemInformationWindowAddress;
		public string GameCompleteWindowAddress;
		public string GameOverWindowAddress;
	}
}