using UI.Services.Windows;
using UI.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Inventory
{
	public class ItemCell : MonoBehaviour
	{
		[SerializeField] private Button _openItemCellButton;

		private IWindowsService _windowsService;

		[Inject]
		public void Constructor(IWindowsService windowsService) => 
			_windowsService = windowsService;

		private void Awake() => 
			_openItemCellButton.onClick.AddListener(OpenItemInformationWindow);

		private void OpenItemInformationWindow() => 
			_windowsService.Open(WindowType.ItemInformation);
	}
}