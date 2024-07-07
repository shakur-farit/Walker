using Data;
using Infrastructure.Services.PersistentProgress;
using TMPro;
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
		[SerializeField] private Button _itemDeleteButton;

		private bool _isFool;

		private IPersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(IPersistentProgressService persistentProgressService)
		{
			_persistentProgressService = persistentProgressService;
		}

		private void Awake()
		{
			_itemCellButton.onClick.AddListener(ShowDeleteButton);

			HideComponents();

			SetupItemCell();
		}

		private void SetupItemCell()
		{
			InventoryData inventoryData = _persistentProgressService.Progress.InventoryData;

			if (_isFool == false && inventoryData.DropsQueue.Count > 0)
			{
				_spriteImage.gameObject.SetActive(true);
				_countText.gameObject.SetActive(true);

				DropStruct drop = inventoryData.GetItemFromDropsQueue();

				_spriteImage.sprite = drop.Sprite;
				_countText.text = drop.PackCount.ToString();

				_isFool = true;

				_itemCellButton.interactable = true;
			}
		}

		private void ShowDeleteButton()
		{
			if(_isFool == false)
				return;

			_itemDeleteButton.gameObject.SetActive(true);
			_itemDeleteButton.onClick.AddListener(DeleteItem);
		}

		private void DeleteItem()
		{
			ClearItemCell();

			_isFool = false;
		}

		private void ClearItemCell()
		{
			_spriteImage.sprite = null;
			_countText.text = string.Empty;

			HideComponents();
		}

		private void HideComponents()
		{
			_spriteImage.gameObject.SetActive(false);
			_countText.gameObject.SetActive(false);
			_itemDeleteButton.gameObject.SetActive(false);

			_itemCellButton.interactable = false;

		}
	}
}