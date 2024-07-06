using UnityEngine;

namespace Ammo
{
	public class AmmoMover : MonoBehaviour
	{
		private float _movementSpeed;

		private void Awake() => 
			SetupMovementSpeed();

		private void SetupMovementSpeed() =>
			_movementSpeed = 0.05f;

		private void Update() => 
			transform.Translate(_movementSpeed, 0, 0);
	}
}
