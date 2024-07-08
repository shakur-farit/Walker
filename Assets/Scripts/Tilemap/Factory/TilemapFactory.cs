using Cysharp.Threading.Tasks;
using Infrastructure.FactoryBase;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Enemy.Factory
{
	public class TilemapFactory : FactoryBase, ITilemapFactory
	{
		private GameObject _tilemap;

		protected TilemapFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) : 
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create()
		{
			AssetsReference reference = await InitReference();
			_tilemap = await CreateObject(reference.TilemapAddress);
		}

		public void Destroy() =>
			Object.Destroy(_tilemap);
	}
}