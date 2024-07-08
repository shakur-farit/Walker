using Drop;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Character
{
	public class CharacterDropPickuper : MonoBehaviour
	{
		private IDropDeath _dropDeath;
		private IPersistentProgressService _persistentProgressService;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IDropDeath dropDeath, IPersistentProgressService persistentProgressService,
			IStaticDataService staticDataService)
		{
			_dropDeath = dropDeath;
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
		}

		public void PickupDrop(GameObject drop, DropType dropType)
		{
			foreach (DropStaticData dropData in _staticDataService.DropsList.DropsList)
			{
				if(dropType == dropData.Type)
					_persistentProgressService.Progress.InventoryData.DropsStaticDataList.Add(dropData);
			}

			DestroyDrop(drop);
		}

		private void DestroyDrop(GameObject drop) => 
			_dropDeath.Die(drop);
	}
}