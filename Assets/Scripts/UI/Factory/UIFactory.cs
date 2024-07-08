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
		private GameObject _gameCompleteWindow;
		private GameObject _inventoryWindow;
		private GameObject _itemInformationWindow;
		private GameObject _gameOverWindow;

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

		public async UniTask CreateGameCompleteWindow()
		{
			AssetsReference reference = await InitReference();
			_gameCompleteWindow = await CreateObject(reference.GameCompleteWindowAddress, _uiRoot.transform);
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

		public void DestroyGameCompleteWindow() =>
			Object.Destroy(_gameCompleteWindow);

		public void DestroyGameOverWindow() =>
			Object.Destroy(_gameOverWindow);
	}
}
