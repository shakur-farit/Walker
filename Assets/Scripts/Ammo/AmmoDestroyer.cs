using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoDestroyer : MonoBehaviour
	{
		
		private bool _isDestroyed;

		private int _livetime;

		private IAmmoDeath _ammoDeath;

		[Inject]
		public void Constructor(IAmmoDeath ammoDeath)
		{
			_ammoDeath = ammoDeath;
		}

		private void Awake() =>
			_livetime = 1000;

		private async void Start() => 
			await DestroyAmmo();

		private void OnDestroy() => 
			_isDestroyed = true;

		private async UniTask DestroyAmmo()
		{
			await UniTask.Delay(_livetime);

			if(_isDestroyed)
				return;

			_ammoDeath.Die(gameObject);
		}
	}
}