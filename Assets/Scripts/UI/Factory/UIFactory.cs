using Cysharp.Threading.Tasks;
using Infrastructure.FactoryBase;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace UI.Factory
{
	public class UIFactory : FactoryBase, IUIFactory
	{
		private GameObject _uiRoot;
		private GameObject _levelCompleteWindow;
		private GameObject _gameOverWindow;
		private GameObject _inventoryWindow;
		private GameObject _itemInformationWindow;

		protected UIFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask CreateUIRoot()
		{
			AssetsReference reference = await InitReference();
			_uiRoot = await CreateObject(reference.UIRootAddress);
		}

		public async UniTask CreateInventoryWindow()
		{
			AssetsReference reference = await InitReference();
			_inventoryWindow = await CreateObject(reference.InventoryWindowAddress, _uiRoot.transform);
		}

		public async UniTask CreateItemInformationWindow()
		{
			AssetsReference reference = await InitReference();
			_itemInformationWindow = await CreateObject(reference.ItemInformationWindowAddress, _uiRoot.transform);
		}

		public async UniTask CreateLevelCompleteWindow()
		{
			AssetsReference reference = await InitReference();
			_levelCompleteWindow = await CreateObject(reference.LevelCompleteWindowAddress, _uiRoot.transform);
		}

		public async UniTask CreateGameOverWindow()
		{
			AssetsReference reference = await InitReference();
			_gameOverWindow = await CreateObject(reference.GameOverWindowAddress, _uiRoot.transform);
		}

		public void DestroyInventoryWindow() => 
			Object.Destroy(_inventoryWindow);

		public void DestroyItemInformationWindow() => 
			Object.Destroy(_itemInformationWindow);

		public void DestroyLevelCompleteWindow() =>
			Object.Destroy(_levelCompleteWindow);

		public void DestroyGameOVerWindow() =>
			Object.Destroy(_gameOverWindow);
	}
}
