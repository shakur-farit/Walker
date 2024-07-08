using Cysharp.Threading.Tasks;
using Infrastructure.FactoryBase;
using Infrastructure.Services.AssetsManagement;
using Infrastructure.Services.ObjectCreator;
using UnityEngine;

namespace Camera.Factory
{
	public class VirtualCameraFactory : FactoryBase, IVirtualCameraFactory
	{
		public VirtualCameraFactory(IAssetsProvider assetsProvider, IObjectCreatorService objectsCreator) :
			base(assetsProvider, objectsCreator)
		{
		}

		public async UniTask Create()
		{
			AssetsReference reference = await InitReference();
			await CreateObject(reference.VirtualCameraAddress);
		}

		public void Destroy(GameObject gameObject) => 
			Object.Destroy(gameObject);
	}
}