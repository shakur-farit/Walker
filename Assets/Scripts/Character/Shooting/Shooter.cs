using System.Threading.Tasks;
using Ammo.Factory;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Character.Shooting
{
	public class Shooter : MonoBehaviour
	{
		private bool _isShooted;

		private IFireInputService _fireInputSystem;
		private IAmmoFactory _ammoFactory;

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
			if (_isShooted)
				return;

			_isShooted = true;

			
			await Shoot();

			_isShooted = false;
		}

		private async UniTask Shoot()
		{
			await CreateAmmo();
			await UniTask.Delay(1000);
		}

		private async Task CreateAmmo()
		{
			await _ammoFactory.Create(transform);
		}
	}
}