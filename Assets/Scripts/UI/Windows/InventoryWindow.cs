using Infrastructure.Services.PersistentProgress;
using Inventory;
using UI.Factory;
using UI.Services.Windows;
using UnityEngine;
using Zenject;

namespace UI.Windows
{
	public class InventoryWindow : WindowBass
	{
		[SerializeField] private Transform _gridParent;

		private IWindowsService _windowsService;
		private IItemCellFactory _itemCellFactory;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IWindowsService windowsService, IItemCellFactory itemCellFactory,
			IPersistentProgressService persistentProgressService)
		{
			_windowsService = windowsService;
			_itemCellFactory = itemCellFactory;
			_persistentProgressService = persistentProgressService;
		}

		protected override void OnAwake()
		{
			
		}

		private void Start() => 
			CreateGrid();

		protected override void CloseWindow()
		{
			_windowsService.Close(WindowType.Inventory);

			_persistentProgressService.Progress.InventoryData.ItemCellsList.Clear();
		}

		private async void CreateGrid()
		{
			Vector2 position = new Vector2(-350f, 200f);
			float XStep = 125f;
			float YStep = 125f;

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					ItemCell cell = await _itemCellFactory.Create(_gridParent, position);

					_persistentProgressService.Progress.InventoryData.ItemCellsList.Add(cell);

					position.x += XStep;
				}
				position.y += YStep;
			}
		}
	}
}