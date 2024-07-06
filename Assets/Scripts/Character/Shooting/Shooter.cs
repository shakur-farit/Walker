using Ammo.Factory;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Character.Shooting
{
	public class Shooter : MonoBehaviour
	{
		private bool _isShoot;

		private IFireInputService _fireInputSystem;
		private IAmmoFactory _ammoFactory;

		public bool CanShoot { get; set; }

		[Inject]
		public void Constructor(IFireInputService fireInputSystem, IAmmoFactory ammoFactory)
		{
			_fireInputSystem = fireInputSystem;
			_ammoFactory = ammoFactory;
		}

		private void Awake() => 
			_fireInputSystem.RegisterFireInputAction();

		private void Update()
		{
			if (_fireInputSystem.IsFireButtonPressed)
				TryToShoot();
		}

		private async void TryToShoot()
		{
			if(CanShoot == false)
				return;

			if (_isShoot)
				return;

			_isShoot = true;

			
			await Shoot();

			_isShoot = false;
		}

		private async UniTask Shoot()
		{
			await CreateAmmo();
			await UniTask.Delay(1000);
		}

		private async UniTask CreateAmmo() => 
			await _ammoFactory.Create(transform);
	}
}