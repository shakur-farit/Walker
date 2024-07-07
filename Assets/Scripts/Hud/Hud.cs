using System;
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

		private IWindowsService _windowService;

		[Inject]
		public void Constructor(IWindowsService windowService) =>
			_windowService = windowService;

		private void Awake() => 
			_inventoryButton.onClick.AddListener(OpenInventoryWindow);

		private void OpenInventoryWindow() => 
			_windowService.Open(WindowType.Inventory);
	}
}