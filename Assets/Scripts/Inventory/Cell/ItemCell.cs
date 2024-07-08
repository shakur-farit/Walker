using Character;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using UI.Services.Windows;
using UI.Windows;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Inventory
{
	public class ItemCell : MonoBehaviour
	{
		[SerializeField] private Image _spriteImage;
		[SerializeField] private TextMeshProUGUI _countText;
		[SerializeField] private Button _itemCellButton;

		private DropStaticData _dropStaticData;

		private IWindowsService _windowsService;
		private IItemProvider _provider;

		public bool IsFool { get; private set; }

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService, IWindowsService windowsService, IItemProvider provider)
		{
			_windowsService = windowsService;
			_provider  = provider;
		}

		private void Awake()
		{
			_itemCellButton.onClick.AddListener(OpenItemInformationWindow);
			HideComponents();

			if (IsFool)
				SetupItemCell();
		}

		public void SetDropStaticData(DropStaticData dropStaticData)
		{
			_dropStaticData = dropStaticData;

			IsFool = true;
		}

		private void SetupItemCell()
		{
			_spriteImage.gameObject.SetActive(true);
			_spriteImage.sprite = _dropStaticData.Sprite;

			if (_dropStaticData.PackCount > 1)
			{
				_countText.gameObject.SetActive(true);
				_countText.text = _dropStaticData.PackCount.ToString();
			}
				
		}

		private async void OpenItemInformationWindow()
		{
			_provider.DropStaticData = _dropStaticData;

			await _windowsService.Open(WindowType.ItemInformation);

			_windowsService.Close(WindowType.Inventory);
		}

		private void HideComponents()
		{
			_spriteImage.gameObject.SetActive(false);
			_countText.gameObject.SetActive(false);
		}
	}
}