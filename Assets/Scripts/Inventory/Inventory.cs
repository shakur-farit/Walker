using System.Collections.Generic;
using Character;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Inventory
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField] private List<ItemCell> _items;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService prePersistentProgressService) =>
			_persistentProgressService = prePersistentProgressService;

		private void Awake() => 
			SetupItemCells();

		private void SetupItemCells()
		{
			List<DropStaticData> dataList = _persistentProgressService.Progress.InventoryData.DropsStaticDataList;

			foreach (DropStaticData dropStaticData in dataList)
			{
				foreach (ItemCell itemCell in _items)
					if (itemCell.IsFool == false)
					{
						itemCell.SetDropStaticData(dropStaticData);
						break;
					}
			}
		}
	}
}