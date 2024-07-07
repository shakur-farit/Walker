using Drop;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterDropPickuper : MonoBehaviour
	{
		private IDropDeath _dropDeath;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IDropDeath dropDeath, IPersistentProgressService persistentProgressService)
		{
			_dropDeath = dropDeath;
			_persistentProgressService = persistentProgressService;
		}

		public void PickupDrop(GameObject drop, DropType dropType, Sprite dropSprite, int dropPackCount, int dropValue)
		{
			_persistentProgressService.Progress.InventoryData
				.SetItemInDropsQueue(dropType,dropSprite,dropPackCount,dropValue);

			DestroyDrop(drop);
		}

		private void DestroyDrop(GameObject drop) => 
			_dropDeath.Die(drop);
	}
}