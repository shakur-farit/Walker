using System;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using UI.Services.Windows;
using UI.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Hud
{
	public class Hud : MonoBehaviour
	{
		[SerializeField] private Button _inventoryButton;
		[SerializeField] private Button _saveButton;

		private IWindowsService _windowService;
		private ISaveService _saveService;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IWindowsService windowService, ISaveService saveService,
			IPersistentProgressService persistentProgressService)
		{
			_windowService = windowService;
			_saveService = saveService;
			_persistentProgressService = persistentProgressService;
		}

		private void Awake()
		{
			_inventoryButton.onClick.AddListener(OpenInventoryWindow);
			_saveButton.onClick.AddListener(SaveProgress);
		}

		private void SaveProgress() => 
			_saveService.SaveProgress(_persistentProgressService.Progress);

		private void OpenInventoryWindow() => 
			_windowService.Open(WindowType.Inventory);
	}
}