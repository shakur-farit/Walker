using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Character.Shooting
{
	public class Shooter : MonoBehaviour
	{
		private IFireInputService _fireInputSystem;

		[Inject]
		public void Constructor(IFireInputService fireInputSystem) => 
			_fireInputSystem = fireInputSystem;

		private void Awake() => 
			_fireInputSystem.RegisterFireInputAction();

		private void Update()
		{
			if (_fireInputSystem.IsFireButtonPressed)
				Shoot();
		}

		private void Shoot()
		{
			Debug.Log("Shoot");
		}

	}
}