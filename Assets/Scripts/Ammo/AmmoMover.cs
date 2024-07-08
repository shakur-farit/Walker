using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Ammo
{
	public class AmmoMover : MonoBehaviour
	{
		private float _movementSpeed;
		private IStaticDataService _staticDataService;

		[Inject]
		public void Constructor(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Awake() => 
			SetupMovementSpeed();

		private void SetupMovementSpeed() =>
			_movementSpeed = _staticDataService.AmmoStaticData.Speed;

		private void Update() => 
			transform.Translate(_movementSpeed, 0, 0);
	}
}
