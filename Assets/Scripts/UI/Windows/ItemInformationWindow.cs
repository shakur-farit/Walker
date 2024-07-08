using Character;
using Infrastructure.Services.PersistentProgress;
using Inventory;
using UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class ItemInformationWindow : WindowBass
	{
		[SerializeField] private Button _itemDeleteButton;
		[SerializeField] private Image _itemImage;

		private DropStaticData _dropStaticData;

		private IWindowsService _windowsService;
		private IItemProvider _provider;
		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IWindowsService windowsService, IItemProvider provider, IPersistentProgressService persistentProgressService)
		{
			_windowsService = windowsService;
			_provider = provider;
			_persistentProgressService = persistentProgressService;
		}

		protected override void OnAwake()
		{
			_dropStaticData = _provider.DropStaticData;

			_itemDeleteButton.onClick.AddListener(CleanItemCell);

			_itemImage.sprite = _dropStaticData.Sprite;
		}

		private void CleanItemCell()
		{
			_itemImage.sprite = null;
			_itemImage.gameObject.SetActive(false);
			_persistentProgressService.Progress.InventoryData.DropsStaticDataList.Remove(_dropStaticData);
		}

		protected override void CloseWindow()
		{
			_windowsService.Open(WindowType.Inventory);

			_windowsService.Close(WindowType.ItemInformation);
		}
	}
}