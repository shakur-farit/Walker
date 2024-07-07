using Cysharp.Threading.Tasks;
using Infrastructure.FactoryBase;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using Inventory;
using UnityEngine;

namespace UI.Factory
{
	public class ItemCellFactory : FactoryBase, IItemCellFactory
	{
		protected ItemCellFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask<ItemCell> Create(Transform parent, Vector2 position)
		{
			AssetsReference reference = await InitReference();
			GameObject cellGameObject = await CreateObject(reference.ItemCellAddress, parent, position);

			if (cellGameObject.TryGetComponent(out ItemCell cell))
				return cell;

			return null;
		}
	}
}