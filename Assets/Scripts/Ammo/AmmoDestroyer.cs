using Cysharp.Threading.Tasks;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoDestroyer : MonoBehaviour
	{
		
		private bool _isDestroyed;

		private int _lifetime;

		private IAmmoDeath _ammoDeath;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IAmmoDeath ammoDeath, IStaticDataService staticDataService)
		{
			_ammoDeath = ammoDeath;
			_staticDataService = staticDataService;
		}

		private void Awake() =>
			_lifetime = _staticDataService.AmmoStaticData.Lifetime;

		private async void Start() => 
			await DestroyAmmo();

		private void OnDestroy() => 
			_isDestroyed = true;

		private async UniTask DestroyAmmo()
		{
			await UniTask.Delay(_lifetime);

			if(_isDestroyed)
				return;

			_ammoDeath.Die(gameObject);
		}
	}
}