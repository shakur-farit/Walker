using Code.Infrastructure.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Meta.Features.Hud.HeroHeartHolder.Factory
{
	public class HeartUIFactory : IHeartUIFactory
	{
		public const string HeartUIAddress = "HeartUI";

		private readonly IInstantiator _instantiator;
		private readonly IAssetProvider _assetProvider;

		public HeartUIFactory(IInstantiator instantiator, IAssetProvider assetProvider)
		{
			_instantiator = instantiator;
			_assetProvider = assetProvider;
		}

		public async UniTask<GameObject> CreateHeartUI(Transform parent)
		{
			GameObject prefab = await _assetProvider.Load<GameObject>(HeartUIAddress);

			return _instantiator.InstantiatePrefab(prefab, parent);
		}
	}
}