using System;
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

		public void PickupDrop(DropData dropData)
		{
			_persistentProgressService.Progress.InventoryData.DropsList.Add(dropData);
			DestroyDrop(dropData.gameObject);
		}

		private void DestroyDrop(GameObject drop) => 
			_dropDeath.Die(drop);
	}
}